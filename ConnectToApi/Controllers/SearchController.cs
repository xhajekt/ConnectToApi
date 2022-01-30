using ConnectToApi.BL.Result;
using ConnectToApi.Models;
using ConnectToApi.Orchestrator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchOrchestrator _searchOrchestrator;

        public SearchController(ISearchOrchestrator searchOrchestrator)
        {
            _searchOrchestrator = searchOrchestrator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchViewModel model)
        {
            if (string.IsNullOrEmpty(model.WatchlistName))
            {
                ViewBag.Error = "wrong input from view";
                return View("ResultError");
            }

            byte[] fileBytes = null;
            using (var ms = new MemoryStream())
            {
                model.ImageFile.CopyTo(ms);
                fileBytes = ms.ToArray();
                //string s = Convert.ToBase64String(fileBytes);
            }

            if (fileBytes == null)
            {
                ViewBag.Error = "wrong input from view";
                return View("ResultError");
            }

            ResultSpecificOrchestrator<SearchResultViewModel> result = await _searchOrchestrator.SearchByParamsAsync(fileBytes, model.WatchlistName, model.Treshold, model.MaxFaceSize, model.MinFaceSize);

            if (result.IsSuccess)
            {
                return View("Result", result.ReturnValue);
            }
            else
            {
                ViewBag.Error = result.ErrorMessage;
                return View("ResultError");
            }
        }
    }
}
