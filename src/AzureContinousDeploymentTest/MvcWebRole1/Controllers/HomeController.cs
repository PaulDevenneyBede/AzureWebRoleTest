using Bede.Middleware.Clients.Security;
using Bede.Middleware.Clients.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebRole1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembershipClient _membershipClient;

        public HomeController(IMembershipClient membershipClient)
        {
            _membershipClient = membershipClient;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestWebApi()
        {
            GetUserRequest request = new GetUserRequest(Guid.NewGuid().ToString()) {UserName = "OrchardAdmin"};
            var result = _membershipClient.GetUser(request);


            return View(result);
        }

    }
}
