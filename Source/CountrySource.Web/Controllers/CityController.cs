using CountrySource.Application.Countries;
using CountrySource.Web.ViewModels.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountrySource.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly CountryAppService service;
        public CityController(CountryAppService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public ActionResult List(CityListViewModel viewModel)
        {
            var cities = service.FindCityBy(viewModel.SearchText);

            viewModel.Load(cities);

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var states = service.FindAllStates();

            return View(new CityCreateViewModel(states));
        }

        [HttpPost]
        public JsonResult Create(CityCreateViewModel viewModel)
        {
            try
            {
                service.CreateCity(viewModel.ToCommand());

                return Json(new { Success = true, Message = "Cidade cadastrada com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult Update(int? id)
        {
            var states = service.FindAllStates();
            var city = service.GetCityBy(id);

            return View(new CityUpdateViewModel(states, city));
        }

        [HttpPost]
        public JsonResult Update(CityUpdateViewModel viewModel)
        {
            try
            {
                service.UpdateCity(viewModel.ToCommand());

                return Json(new { Success = true, Message = "Cidade atualizada com sucesso." });

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
                service.DeleteCity(id);

                return Json(new { Success = true, Message = "Cidade removida com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

    }
}