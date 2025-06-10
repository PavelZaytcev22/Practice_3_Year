using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using WebApplication3.Models;
using DocumentFormat.OpenXml.Bibliography;
using System.Reflection;
using DocumentFormat.OpenXml.CustomProperties;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для выгрузки xls файла 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExсelController:ControllerBase
    {
        ApplicationContext dataBaseContext;
        /// <summary>
        /// Конструктор контроллера 
        /// </summary>
        /// <param name="dataBaseContext">Контекст БД</param>
        public ExсelController(ApplicationContext dataBaseContext) 
        {
            this. dataBaseContext=dataBaseContext;
        }

        static List<string> names = new List<string>() { "Database", "ChangeTracker", "Model", "ContextId" };
        [HttpGet("getXLS")]
        public async Task<FileStreamResult> GetXlsFile()
        {
            if (dataBaseContext==null) { throw new ArgumentNullException(); }

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
                    var dbSet = i.GetValue(dataBaseContext) as IEnumerable<object>;

                    var bookSheet = book.Worksheets.Add(entityType.Name);//Создаем лист
                    int zz = 1;

                    //Заполняем заголовки таблицы 
                    foreach (var b in entityType.GetProperties())
                    {
                        if (!names.Contains(b.Name))
                        {
                            bookSheet.Cell(1, zz).Value = b.Name;
                            zz++;
                        }
                    }
                    //Заполняем тело таблицы
                    zz = 2;                    
                    foreach (var h in dbSet) 
                    {
                        int bb = 1;
                        foreach (var n in h.GetType().GetProperties())
                        {
                            bookSheet.Cell(zz, bb).Value = n.GetValue(h) != null? n.GetValue(h).ToString():"null";
                            bb++;
                        }
                        zz++;
                    }
                }
            }

            var memoryStream = new MemoryStream();
            book.SaveAs(memoryStream);
            memoryStream.Position = 0;

            return File(memoryStream, "application/vnd.ms-excel", "DataBase.xls");

           /* var sheet = book.Worksheets.Add("Клиент");
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Номер телефона";
            int j = 2;
            foreach (var i in dataBaseContext.Client)
            {
                sheet.Cell(j, 1).Value = i.ClientId.ToString();
                sheet.Cell(j, 2).Value = i.PhoneNumber;
                j++;
            }

            sheet = book.Worksheets.Add("Производитель");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Название";
            foreach (var i in dataBaseContext.Manufacturer)
            {
                sheet.Cell(j, 1).Value = i.ManufacturerId.ToString();
                sheet.Cell(j, 2).Value = i.ManufacturerName;
                j++;
            }

            sheet = book.Worksheets.Add("Поставщик");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Название";
            foreach (var i in dataBaseContext.Supplier)
            {
                sheet.Cell(j, 1).Value = i.SupplierId.ToString();
                sheet.Cell(j, 2).Value = i.SupplierName;
                j++;
            }

            sheet = book.Worksheets.Add("Должность");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Название";
            foreach (var i in dataBaseContext.Post)
            {
                sheet.Cell(j, 1).Value = i.PostId.ToString();
                sheet.Cell(j, 2).Value = i.PostName;
                j++;
            }

            sheet = book.Worksheets.Add("Лекарство");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Название";
            sheet.Cell(1, 3).Value = "Производитель";
            var table = dataBaseContext.Medicine.Select(o => new
            {
                id = o.MedicineId.ToString(),
                Name = o.MedicineName,
                Manufacturer = o.Manufacturer.ManufacturerName//По навигационному свойству 
            });
            foreach (var i in table)
            {
                sheet.Cell(j, 1).Value =i.id;
                sheet.Cell(j, 2).Value = i.Name;
                sheet.Cell(j, 3).Value = i.Manufacturer;
                j++;
            }

            sheet = book.Worksheets.Add("Работник");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "ФИО";
            sheet.Cell(1, 3).Value = "Номер телефона";
            sheet.Cell(1, 4).Value = "Должность";
            var table2 = dataBaseContext.Employer.Select(o => new
            {
                id = o.EmployerId.ToString(),
                Name = o.Fio,
                Phone = o.PhoneNumber,
                Post=o.Post.PostName//По навигационному свойству 
            });
            foreach (var i in table2)
            {
                sheet.Cell(j, 1).Value = i.id;
                sheet.Cell(j, 2).Value =i.Name;
                sheet.Cell(j, 3).Value = i.Phone;
                sheet.Cell(j, 4).Value = i.Post;
                j++;
            }


            sheet = book.Worksheets.Add("Поставка");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Поставщик";
            sheet.Cell(1, 3).Value = "Дата";
            sheet.Cell(1, 4).Value = "Контрольная сумма";
            var table3 = dataBaseContext.Supplie.Select(o => new
            {
                id = o.SupplieId.ToString(),
                Supplier = o.Supplier.SupplierName,//По навигационному свойству 
                Date = o.Date,
                Sum = o.TotalSum.ToString()
            });
            foreach (var i in table3)
            {
                sheet.Cell(j, 1).Value = i.id;
                sheet.Cell(j, 2).Value =i.Supplier;
                sheet.Cell(j, 3).Value = i.Date;
                sheet.Cell(j, 4).Value = i.Sum;
                j++;
            }

            sheet = book.Worksheets.Add("Чек");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Работник";
            sheet.Cell(1, 3).Value = "Номер клиента";
            sheet.Cell(1, 4).Value = "Дата";
            sheet.Cell(1, 5).Value = "Контрольная сумма";
            sheet.Cell(1, 6).Value = "Контрольная сумма со скидкой";
            var table4 = dataBaseContext.Cheque.Select(o => new
            {
                id = o.ChequeId.ToString(),
                Employer = o.Employer.Fio,//По навигационному свойству 
                Client =o.Client.PhoneNumber,//По навигационному свойству 
                Date = o.Date,
                Sum = o.TotalSum.ToString(),
                SumDisc=o.SumDiscount.ToString()
            });
            foreach (var i in table4)
            {
                sheet.Cell(j, 1).Value = i.id;
                sheet.Cell(j, 2).Value = i.Employer;
                sheet.Cell(j, 3).Value = i.Client;
                sheet.Cell(j, 4).Value = i.Date;
                sheet.Cell(j, 5).Value = i.Sum;
                sheet.Cell(j, 6).Value = i.SumDisc;
                j++;
            }

            sheet = book.Worksheets.Add("Продажа");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Чек";
            sheet.Cell(1, 3).Value = "Лекарство";
            sheet.Cell(1, 4).Value = "Количество";
            sheet.Cell(1, 5).Value = "Цена за 1 шт.";
            var table5 = dataBaseContext.SaleMedicine.Select(o => new
            {
                id = o.ChequeId.ToString(),
                Cheque = o.Cheque.ToString(),//По навигационному свойству 
                Medicine = o.Medicine.MedicineName,//По навигационному свойству 
                Count = o.Count,
                Price = o.PriceSellOne.ToString()
            });
            foreach (var i in table5)
            {
                sheet.Cell(j, 1).Value = i.id;
                sheet.Cell(j, 2).Value = i.Cheque;
                sheet.Cell(j, 3).Value = i.Medicine;
                sheet.Cell(j, 4).Value = i.Count;
                sheet.Cell(j, 5).Value = i.Price;
                j++;
            }


            sheet = book.Worksheets.Add("Часть поставки");
            j = 2;
            sheet.Cell(1, 1).Value = "ID";
            sheet.Cell(1, 2).Value = "Поставка";
            sheet.Cell(1, 3).Value = "Лекарство";
            sheet.Cell(1, 4).Value = "Количество";
            sheet.Cell(1, 5).Value = "Цена за 1 шт.";
            var table6 = dataBaseContext.SupplieMedicine.Select(o => new
            {
                id = o.SuplieMedicineId.ToString(),
                Supplie = o.Supplie.ToString(),//По навигационному свойству 
                Medicine = o.Medicine.MedicineName,//По навигационному свойству 
                Count = o.Count,
                Price = o.PricePayOne.ToString()
            });
            foreach (var i in table6)
            {
                sheet.Cell(j, 1).Value = i.id;
                sheet.Cell(j, 2).Value = i.Supplie;
                sheet.Cell(j, 3).Value = i.Medicine;
                sheet.Cell(j, 4).Value = i.Count;
                sheet.Cell(j, 5).Value = i.Price;
                j++;
            }*/

        }
    }
}
