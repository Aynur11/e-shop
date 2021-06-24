using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.ViewComponent
{
    public class LogoutViewViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}