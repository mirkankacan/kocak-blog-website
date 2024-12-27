using KocakBlog.UI.DTOs.BlogDTOs;
using KocakBlog.UI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.UI.ViewComponents.HomeViewComponents
{
    public class _HomeBlogViewComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _httpClient.GetFromJsonAsync<List<ResultBlogDTO>>("blogs");
            return View(blogs);
        }
    }
}