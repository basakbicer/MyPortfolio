using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using System.Linq;

namespace MyPortfolio.ViewComponents
{
    public class _ContactCompenetPartial : ViewComponent
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.contactTitle = portfolioContext.Contacts.Select(x => x.Title).FirstOrDefault();
            ViewBag.contactDescription = portfolioContext.Contacts.Select(x => x.Description).FirstOrDefault();
            ViewBag.contactPhone1 = portfolioContext.Contacts.Select( x => x.Phone1).FirstOrDefault();
            ViewBag.contactPhone2 = portfolioContext.Contacts.Select( x => x.Phone2).FirstOrDefault();
            ViewBag.contactEmail1 = portfolioContext.Contacts.Select( x => x.Email1).FirstOrDefault();
            ViewBag.contactEmail2 = portfolioContext.Contacts.Select(x => x.Email2).FirstOrDefault();
            ViewBag.contactAddress = portfolioContext.Contacts.Select(x => x.Address).FirstOrDefault();

            return View();
        }
    }
}
