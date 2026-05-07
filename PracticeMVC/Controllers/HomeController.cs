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
       // private readonly BinaryTree<string> _binaryTree;
        private readonly AppService _service;

        public HomeController(ILogger<HomeController> logger, AppService service)  //BinaryTree<string> binaryTree
        {
            _logger = logger;
            //_binaryTree = binaryTree;
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

            

        //    // call the sorting method to show first 10 key pairs
        //    // send this list to the view 


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
