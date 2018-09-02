using MNS.Translator.Application.Interfaces;
using MNS.Translator.Application.Models;
using MNS.Translator.Application.ValueObjects;
using MNS.Translator.UI.Site.Helpers;
using System.Web.Mvc;

namespace MNS.Translator.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITranslationRequestAppService _translationRequestAppService;

        public HomeController(ITranslationRequestAppService translationRequestAppService)
        {
            _translationRequestAppService = translationRequestAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new HomeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Translate(HomeViewModel homeViewModel)
        {
            var response = new ResponseResult();

            if (ModelState.IsValid)
            {
                response =_translationRequestAppService.GetTranslation(homeViewModel.Text);
                return Json(response, JsonRequestBehavior.AllowGet); 
            }

            Response.StatusCode = 422; 
            Response.Write(Helper.GetModelErrors(ModelState));
            return null;
        }


    }
}