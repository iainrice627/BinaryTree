using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PracticeMVC.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace PracticeMVC.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppService _service;

        public HomeController(ILogger<HomeController> logger, AppService service)  
        {
            _logger = logger;
            _service = service;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputText)
        {
            var dictionary = _service.ProccessString(inputText);
            
            ViewBag.ShowMessage = true;

            return View(dictionary);
      
            
        }

        //[HttpPost]
        //public IActionResult SearchWord(string searchText)
        //{

            

        //    traverse the tree
            // at each node check if the value is same as word inserted.
            //if yes then get the element count value.
            // send the value name and the count to a partial view - that shows a <p> element 
            //insert the values into the <p>
            //return the view index with this new partial view inserted. 
        //    


        //}
        

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
