using CountrySource.Application.Countries;
using CountrySource.Web.ViewModels.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountrySource.Web.Controllers
{
    public class StateController : Controller
    {
        private readonly CountryAppService service;
        public StateController(CountryAppService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }


        public ActionResult List(StateListViewModel viewModel)
        {
            var states = service.FindStateBy(viewModel.SearchText);

            viewModel.Load(states);

            return View(viewModel);
        }

        public ActionResult Detail(int? id)
        {
            var state = service.GetStateBy(id);

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
                service.CreateState(viewModel.ToCommand());

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
            var state = service.GetStateBy(id);

            return View(new StateUpdateViewModel(state, countries));
        }

        [HttpPost]
        public JsonResult Update(StateUpdateViewModel viewModel)
        {
            try
            {
                service.UpdateState(viewModel.ToCommand());

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
                service.DeleteState(id);

                return Json(new { Success = true, Message = "Estado removido com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}