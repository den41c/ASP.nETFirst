using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	using System.Data.Entity;

	public class BookContext: DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Purchase> Purchases { get; set; }
		public DbSet<Customer> Customer { get; set; }
	}

	//public class BookDbInit : DropCreateDatabaseAlways<BookContext>
	//{
	//	protected override void Seed(BookContext db)
	//	{
	//		db.Books.Add(new Book() { Name = "Война и мир", Author = "Толстой"});
	//		db.Books.Add(new Book() { Name = "Война и мир 2", Author = "Толстой 2" });
	//		base.Seed(db);
	//	}
	//}

}