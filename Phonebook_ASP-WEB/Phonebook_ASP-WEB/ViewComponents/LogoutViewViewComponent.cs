using Microsoft.AspNetCore.Mvc;

namespace Phonebook_ASP_WEB.Component
{
    
    public class LogoutViewViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
 }
