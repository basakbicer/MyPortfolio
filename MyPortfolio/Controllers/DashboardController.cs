using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class DashboardController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Dashboard()
		{
			// Session'dan kullanıcı adını alıyoruz
			var loginName = HttpContext.Session.GetString("loginName");

			if (string.IsNullOrEmpty(loginName))
			{
				// Oturum açılmamışsa login sayfasına yönlendir
				return RedirectToAction("LoginForm", "Login");
			}

			// Kullanıcı adı ile veritabanından ilgili kullanıcıyı al
			var user = context.Logins.FirstOrDefault(u => u.loginName == loginName);

			if (user != null)
			{
				// Kullanıcı bulundu, dashboard'u render et
				return View("~/Views/Login/Dashboard.cshtml", user); // veya diğer işlemleri yapabilirsiniz
			}

			// Kullanıcı bulunamazsa login sayfasına yönlendir
			return RedirectToAction("LoginForm", "Login");
		}
		[HttpGet]
		public IActionResult UpdateLogin(int id)
		{
            if (HttpContext.Session.GetString("loginName") == null)
            {
                return RedirectToAction("LoginForm", "Login");
            }

            var value = context.Logins.Find(id);
			return View("~/Views/Login/UpdateLogin.cshtml", value);
		}
		[HttpPost]
		public IActionResult UpdateLogin(Login login)
		{
            if (HttpContext.Session.GetString("loginName") == null)
            {
                return RedirectToAction("LoginForm", "Login");
            }

            context.Logins.Update(login);
			context.SaveChanges();
			return RedirectToAction("Dashboard");
		}
	}
}
