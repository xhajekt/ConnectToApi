using ConnectToApi.BL.Result;
using ConnectToApi.Models;
using ConnectToApi.Orchestrator;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ConnectToApi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterOrchestrator _registerOrchestrator;
        private readonly IWebHostEnvironment _webhostEnvironment;

        public RegisterController(IRegisterOrchestrator registerOrchestrator, IWebHostEnvironment webhostEnvironment)
        {
            _registerOrchestrator = registerOrchestrator;
            _webhostEnvironment = webhostEnvironment;
        }

        //register to watchlist
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([Bind("MemberName", "WatchListName", "ImageFile")] RegisterViewModel model)
        {
            if (string.IsNullOrEmpty(model.MemberName) || string.IsNullOrEmpty(model.WatchListName))
            {
                return View("ResultSuccess", new ResultOrchestrator() { ErrorMessage = "wrong input from view" });
            }

            string wwwRootPath = _webhostEnvironment.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            model.ImageName =  filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath , filename);
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    await model.ImageFile.CopyToAsync(fileStream);
            //}


            byte[] fileBytes = null;
            using (var ms = new MemoryStream())
            {
                model.ImageFile.CopyTo(ms);
                fileBytes = ms.ToArray();
                //string s = Convert.ToBase64String(fileBytes);
            }

            if (fileBytes == null)
            {
                return View("ResultSuccess", new ResultOrchestrator() { ErrorMessage = "wrong input from view" });
            }

            ResultOrchestrator result =  await _registerOrchestrator.RegisterAsync(fileBytes, model.MemberName, model.WatchListName);

            return View("ResultSuccess", result);
            //return View("Index");
        }

        //[HttpGet]
        //public IActionResult ResultSuccess()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
