using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Debts.Controllers
{
    public class BaseController : Controller
    {
        public string UserName => User.Identity.Name;
        public string UserId => User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
    }
}