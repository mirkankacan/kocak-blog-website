using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.UI.ViewComponents.HomeViewComponents
{
    public class _HomeFeaturedViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}