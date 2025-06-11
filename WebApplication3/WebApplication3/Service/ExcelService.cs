using WebApplication3.Controllers;
using WebApplication3.Models;
using WebApplication3.Interfaces;
using ClosedXML.Excel;
using static Azure.Core.HttpHeader;
using System.Linq;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using DocumentFormat.OpenXml.CustomProperties;
using System.ComponentModel.Design;


namespace WebApplication3.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcelService
    {
        static List<string> names = new List<string>() { "Database", "ChangeTracker", "Model", "ContextId" };

        ApplicationContext dataBaseContext;
        /// <summary>
        /// конструктор сервиса 
        /// </summary>
        /// <param name="dataBaseContext"></param>
        public ExcelService(ApplicationContext dataBaseContext) 
        {
            this.dataBaseContext = dataBaseContext;
        }
        /// <summary>
        /// Метод для формирования класса XLWorkbook
        /// </summary>
        /// <returns>Класс для формирования xls файла</returns>
        /// <exception cref="ArgumentNullException">Если контекст базы данных равен null</exception>
        public async Task<XLWorkbook> GetXlsFile() 
        {
            if (dataBaseContext == null) { throw new ArgumentNullException(); }

            XLWorkbook book = new XLWorkbook();

            Type type = dataBaseContext.GetType();
            var DBproperties = type.GetProperties();

            //Перебираем свойства(DbSet) контекста 
            foreach (var i in DBproperties)
            {
                if (!names.Contains(i.Name))
                {
                    // Console.WriteLine(" " + i.PropertyType+ "");
                    Type entityType = i.PropertyType.GetGenericArguments()[0];//Тип для заголовка
                    var dbSet = i.GetValue(dataBaseContext);

                    var toListMethod = typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(entityType);
                    var list = toListMethod.Invoke(null, new object[] { dbSet }) as IEnumerable<object>;

                    var bookSheet = book.Worksheets.Add(entityType.Name);//Создаем лист


                    //Заполняем заголовки таблицы 
                    var parametrs = entityType.GetProperties();
                    for (int collumn = 0; collumn < parametrs.Length; collumn++)
                    {
                        if (!names.Contains(parametrs[collumn].Name))
                        {
                            bookSheet.Cell(1, collumn + 1).Value = parametrs[collumn].Name;
                        }
                    }
                    //Альтернатива через foreach
                    /* int collumnForTittle = 1;
                     foreach (var j in entityType.GetProperties()) 
                     {
                         bookSheet.Cell(1, collumnForTittle).Value = j.Name;
                         collumnForTittle++;
                     }*/
                    
                    //Заполняем тело таблицы
                    for (int row1 = 2; row1 <= list.Count() + 1; row1++)
                    {
                        var type1 = list.ToArray()[row1 - 2];
                        var property = type1.GetType().GetProperties();
                        for (int collumn = 1; collumn <= property.Length; collumn++)
                        {
                            var prop = property[collumn - 1].GetValue(type1);
                            bookSheet.Cell(row1, collumn).Value = prop != null ?
                                prop.ToString()
                                : "null";
                        }
                    }


                    //Альтернатива через foreach
                    /*int row = 2;
                    foreach (var h in list)
                    {
                        int collumn = 1;
                        foreach (var n in h.GetType().GetProperties())
                        {
                            bookSheet.Cell(row, collumn).Value = n.GetValue(h) != null ? n.GetValue(h).ToString() : "null";
                            collumn++;
                        }
                        row++;
                    }
                    */

                }
            }
            return book;
        }
    }
}
