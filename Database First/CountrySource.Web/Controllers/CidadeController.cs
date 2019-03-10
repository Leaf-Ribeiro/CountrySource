using CountrySource.Platform.Services;
using CountrySource.Web.ViewModels.Cidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountrySource.Web.Controllers
{
    public class CidadeController : CommonController
    {
        private readonly CountrySourceService service;
        public CidadeController(CountrySourceService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public ActionResult List(CityListViewModel viewModel)
        {
            var cidades = service.FindCidadeBy(viewModel.SearchText);

            viewModel.Load(cidades);

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var estados = service.FindAllEstados();

            return View(new CityCreateViewModel(estados));
        }

        [HttpPost]
        public JsonResult Create(CityCreateViewModel viewModel)
        {
            try
            {
                service.CreateCidade(viewModel.ToCommand());

                return Json(new { Success = true, Message = "Cidade cadastrada com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult Update(int? id)
        {
            var estados = service.FindAllEstados();
            var cidade = service.GetCidadeBy(id);

            return View(new CityUpdateViewModel(estados, cidade));
        }

        [HttpPost]
        public JsonResult Update(CityUpdateViewModel viewModel)
        {
            try
            {
                service.UpdateCidade(viewModel.ToCommand());

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
                service.DeleteCidade(id);

                return Json(new { Success = true, Message = "Cidade removida com sucesso." });

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

    }
}