using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class ContactController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult ContactList()
		{
			var values = context.Contacts.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult UpdateContact(int id) 
		{
			var value = context.Contacts.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateContact(Contact contact) 
		{
			context.Contacts.Update(contact);
			context.SaveChanges();
			return RedirectToAction("ContactList");
		}
	}
}
