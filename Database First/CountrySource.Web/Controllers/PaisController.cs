using CountrySource.Platform.Services;
using CountrySource.Web.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountrySource.Web.Controllers.Countries
{
    public class PaisController : CommonController
    {
        private readonly CountrySourceService service;
        public PaisController(CountrySourceService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }


        public ActionResult List(CountryListViewModel viewModel)
        {
            var countries = service.FindBy(viewModel.SearchText);

            viewModel.Load(countries);

            return View(viewModel);
        }

        public ActionResult Detail(int? id)
        {
            var country = service.GetById(id);

            return View(new CountryDetailViewModel(country));

        }

        public ActionResult Create()
        {
            return View(new CountryCreateViewModel());
        }

        [HttpPost]
        public JsonResult Create(CountryCreateViewModel viewModel)
        {
            try
            {
                service.Create(viewModel.ToCommand());

                return Json(new { Success = true, Message = "Pais cadastrado com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult Update(int? id)
        {
            var country = service.GetById(id);

            return View(new CountryUpdateViewModel(country));
        }

        [HttpPost]
        public JsonResult Update(CountryUpdateViewModel viewModel)
        {
            try
            {
                service.Update(viewModel.ToCommand());

                return Json(new { Success = true, Message = "Pais atualizado com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                service.Delete(id);

                return Json(new { Success = true, Message = "Pais removido com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}