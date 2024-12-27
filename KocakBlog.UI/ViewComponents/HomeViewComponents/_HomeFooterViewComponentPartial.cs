using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.UI.ViewComponents.HomeViewComponents
{
    public class _HomeFooterViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}