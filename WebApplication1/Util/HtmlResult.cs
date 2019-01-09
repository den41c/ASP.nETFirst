using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Util
{
	public class HtmlResult : ActionResult
	{
		private string _htmlCode;
		public HtmlResult(string html)
		{
			_htmlCode = html;
		}
		public override void ExecuteResult(ControllerContext context)
		{
			string fullHtmlCode = "<!DOCTYPE html><html><head>";
			fullHtmlCode += "<title>Главная страница</title>";
			fullHtmlCode += "<meta charset=utf-8 />";
			fullHtmlCode += "</head> <body>";
			fullHtmlCode += _htmlCode;
			fullHtmlCode += "</body></html>";
			context.HttpContext.Response.Write(fullHtmlCode);
		}
	}
	public class ImageResult : ActionResult
	{
		private string path;
		public ImageResult(string path)
		{
			this.path = path;
		}
		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Write("<div style='width:100%;text-align:center;'>" +
			                                   "<img style='max-width:600px;' src='" + path + "' /></div>");
		}


		public static string Square(int a = 3, int h = 4)
		{
			int s = a * h / 2;
			return "<h2>Площадь треугольника с основанием " + a +
			       " и высотой " + h + " равна " + s + "</h2>";
		}

		


	}

}