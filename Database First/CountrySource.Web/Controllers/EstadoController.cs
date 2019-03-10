using CountrySource.Platform.Services;
using CountrySource.Web.ViewModels.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountrySource.Web.Controllers
{
    public class EstadoController : CommonController
    {
        private readonly CountrySourceService service;
        public EstadoController(CountrySourceService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }


        public ActionResult List(StateListViewModel viewModel)
        {
            var states = service.FindEstadoBy(viewModel.SearchText);

            viewModel.Load(states);

            return View(viewModel);
        }

        public ActionResult Detail(int? id)
        {
            var state = service.GetEstadoBy(id);

            return View(new StateDetailViewModel(state));

        }

        public ActionResult Create()
        {
            var countries = service.FindAll();

            return View(new StateCreateViewModel(countries));
        }

        [HttpPost]
        public JsonResult Create(StateCreateViewModel viewModel)
        {
            try
            {
                service.CreateEstado(viewModel.ToCommand());

                return Json(new { Success = true, Message = "Estado cadastrado com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult Update(int? id)
        {
            var countries = service.FindAll();
            var state = service.GetEstadoBy(id);

            return View(new StateUpdateViewModel(state, countries));
        }

        [HttpPost]
        public JsonResult Update(StateUpdateViewModel viewModel)
        {
            try
            {
                service.UpdateEstado(viewModel.ToCommand());

                return Json(new { Success = true, Message = "Estado atualizado com sucesso." });

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
                service.DeleteEstado(id);

                return Json(new { Success = true, Message = "Estado removido com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}