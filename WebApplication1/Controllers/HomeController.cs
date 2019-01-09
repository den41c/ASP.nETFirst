using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	using WebApplication1.Util;

	public class MyController : IController
	{
		public void Execute(RequestContext requestContext)
		{
			string ip = requestContext.HttpContext.Request.UserHostAddress;
			var response = requestContext.HttpContext.Response;
			response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");
		}
	}

	public class HomeController : Controller
	{
		// создаем контекст данных
		BookContext db = new BookContext();

		public ActionResult Index()
		{
			
			//db.Books.Add(new Book() { Name = "Война и мир", Author = "Толстой" });
			//db.Books.Add(new Book() { Name = "Война и мир 3", Author = "Толстой 3" });
			//db.SaveChanges();

			var purtch = new List<Purchase>();
			foreach (var pur in this.db.Purchases)
			{
				purtch.Add(pur);
			}
			//string res = "";
			//foreach (var one in purtch)
			//{
			//	res+= Adress one.Address 
			//}
			// получаем из бд все объекты Book
			IEnumerable<Book> books = db.Books;
			// передаем все объекты в динамическое свойство Books в ViewBag
			ViewBag.Books = books;
			
			// возвращаем представление
			return View();
		}

		private string ShowList(IEnumerable<object> list)
		{
			foreach (var obj in list)
			{
				
			}
			return "";
		}

		[HttpGet]
		public ActionResult Buy(int id)
		{
			
			ViewBag.BookId = id;
			ViewBag.Name = this.db.Books.Find(id)?.Name;
			return View();
		}
		[HttpPost]
		public string Buy(Purchase purchase)
		{
			purchase.Date = DateTime.Now;
			// добавляем информацию о покупке в базу данных
			db.Purchases.Add(purchase);
			// сохраняем в бд все изменения
			db.SaveChanges();
			return "Спасибо, " + purchase.Person + ", за покупку!";
		}

		public ActionResult GetHtml()
		{
			return new HtmlResult("<h2>Привет мир!</h2>");
		}
		public ActionResult GetImage()
		{
			string path = "../Images/visualstudio.png";
			return new ImageResult(path);
		}

		public ActionResult GetSquare()
		{
			return Content(ImageResult.Square(4,3));
		}

		public FileResult GetFile()
		{
			// Путь к файлу
			string file_path = Server.MapPath("~/Files/PDFIcon.pdf");
			// Тип файла - content-type
			string file_type = "application/pdf";
			// Имя файла - необязательно
			string file_name = "PDFIcon2.pdf";
			return File(file_path, file_type, file_name);
		}

	}
}