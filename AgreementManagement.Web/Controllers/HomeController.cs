using AgreementManagement.Web.Data;
using AgreementManagement.Web.Data.Repository;
using AgreementManagement.Web.Models;
using AgreementManagement.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AgreementManagement.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<ProductGroup> _productGroupRepository;

        public HomeController(IRepository<ProductGroup> productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public IActionResult Index()
        {
            ProductGroupService pgs = new ProductGroupService(_productGroupRepository);

            return View(pgs.GetProductGroups());
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
