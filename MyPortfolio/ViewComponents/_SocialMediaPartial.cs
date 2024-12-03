using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
	public class _SocialMediaPartial : ViewComponent
    {
		MyPortfolioContext context = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
            var values = context.SocialMedias.ToList();
            return View(values);
        }
	}
}
