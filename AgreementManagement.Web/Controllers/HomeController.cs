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
    using Microsoft.Extensions.Logging;
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
        private ILogger _logger;

        public HomeController(
            IRepository<ProductGroup> productGroupRepository,
            IRepository<Product> productRepository,
            IRepository<Agreement> agreementRepository,
            IRepository<AspNetUsers> aspNetUsersRepository,
            IMapper mapper,
            ILogger<HomeController> logger)
        {
            _productGroupRepository = productGroupRepository;
            _productRepository = productRepository;
            _agreementRepository = agreementRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
            _logger = logger;
            _helper = new HomeHelper(
                productGroupRepository,
                productRepository,
                agreementRepository,
                aspNetUsersRepository,
                mapper,
                logger);
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
            if (ModelState.IsValid)
            {
                new AgreementService(_agreementRepository, _mapper, _logger)
                .AddAgreementFromForm(agreement, _aspNetUsersRepository, _productRepository, _agreementRepository);
                return Ok();
            }

            IEnumerable<ModelError> modelErrors = ModelState.AllErrors();
            return BadRequest(modelErrors);
        }

        [HttpPut]
        public IActionResult EditAgreement(AgreementModel agreement)
        {
            if (ModelState.IsValid)
            {
                new AgreementService(_agreementRepository, _mapper, _logger)
                .EditAgreementFromForm(agreement, _aspNetUsersRepository, _productRepository, _agreementRepository);
                return Ok();
            }

            IEnumerable<ModelError> modelErrors = ModelState.AllErrors();
            return BadRequest(modelErrors);
        }

        [HttpDelete]
        public IActionResult RemoveAgreement(int id)
        {
            AgreementService service = new AgreementService(_agreementRepository, _mapper, _logger);
            service.RemoveAgreement(id);
            return Ok();
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
