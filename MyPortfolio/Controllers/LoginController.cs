using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace MyPortfolio.Controllers
{
	public class LoginController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();

		[HttpGet]
		public IActionResult LoginForm()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LoginForm(string loginName, string password)
		{
            // Veritabanından kullanıcıyı kontrol et
            var user = context.Logins
                .FirstOrDefault(u => u.loginName == loginName && u.password == password);

            if (user != null)
            {
                // Kullanıcı bulundu, oturum aç
                HttpContext.Session.SetString("loginName", user.loginName);

				// Logins tablosundaki tüm kullanıcıları alıyoruz
				var allUsers = context.Logins.ToList();

				return View("~/Views/Login/Dashboard.cshtml", allUsers);
			}

            // Kullanıcı adı veya şifre hatalı
            ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre.";
            return View();
        }
	}
}
