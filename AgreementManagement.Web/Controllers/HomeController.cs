namespace AgreementManagement.Web.Controllers
{
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Models;
    using AgreementManagement.Web.Service;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<ProductGroup> _productGroupRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Agreement> _agreementRepository;
        private readonly IRepository<AspNetUsers> _aspNetUsersRepository;
        private readonly IMapper _mapper;

        public HomeController(
            IRepository<ProductGroup> productGroupRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository,
            IRepository<AspNetUsers> aspNetUsersRepository,
            IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _productRepository = productRepository;
            _agreementRepository = agreementRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var agrService = new AgreementService(_agreementRepository, _mapper);
            var list = agrService.GetAgreements();
            return View();
        }

        [HttpGet]
        public JsonResult Agreements()
        {
            return Json(new Agreement());
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
