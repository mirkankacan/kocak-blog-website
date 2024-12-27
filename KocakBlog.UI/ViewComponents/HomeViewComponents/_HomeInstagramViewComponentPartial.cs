using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.UI.ViewComponents.HomeViewComponents
{
    public class _HomeInstagramViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}