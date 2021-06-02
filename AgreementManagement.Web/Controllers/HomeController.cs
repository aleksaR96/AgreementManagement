namespace AgreementManagement.Web.Controllers
{
    using AgreementManagement.Web.Controllers.Helpers;
    using AgreementManagement.Web.Data;
    using AgreementManagement.Web.Data.Repository;
    using AgreementManagement.Web.Models;
    using AgreementManagement.Web.Models.Home;
    using AgreementManagement.Web.Service;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Diagnostics;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<ProductGroup> _productGroupRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Agreement> _agreementRepository;
        private readonly IRepository<AspNetUsers> _aspNetUsersRepository;
        private readonly IMapper _mapper;
        private HomeHelper _helper;

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
            _helper = new HomeHelper(
                productGroupRepository,
                productRepository,
                agreementRepository,
                aspNetUsersRepository,
                mapper);
        }

        public IActionResult Index()
        {
            return View(_helper.PrepareAgreementManagerModel());
        }

        [HttpGet]
        public JsonResult AgreementTable()
        {
            List<AgreementTableModel> list = _helper.PrepareAgreementTableModel();
            return Json(new { data = list });
        }

        [HttpPost]
        public IActionResult AddAgreement(AgreementModel agreement)
        {
            new AgreementService(_agreementRepository, _mapper)
                .AddAgreementFromForm(agreement, _aspNetUsersRepository, _productRepository, _agreementRepository);
            return Ok();
        }

        [HttpGet]
        public IActionResult Agreement(AgreementModel agreement)
        {
            if (agreement?.Id == null)
            {
                return Json(agreement);
            }

            //get agreement
            return Json(agreement);
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
