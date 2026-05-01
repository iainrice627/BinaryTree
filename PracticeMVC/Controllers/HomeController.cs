using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;
using System.Diagnostics;

namespace PracticeMVC.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BinaryTree<string> _binaryTree;

        public HomeController(ILogger<HomeController> logger, BinaryTree<string> binaryTree)
        {
            _logger = logger;
            _binaryTree = binaryTree;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputText)
        {

            var text = _binaryTree.CleanedString(inputText); // returns a list of strings
            ViewBag.Success = _binaryTree.ReadValues(text);
            ViewBag.Message = "Text succesfully proceesed";

            if (ViewBag.Success ==true) {
                
                //send the 
                //traverse the Binary tree nodes and 
                // chnage the view so that when succusefful the list of words and their couunts appear in this next view. 
                // the user can then manually look through the list of words and count.
                
                
                return View();




            }
            return View("Error");
            
        }

        [HttpPost]
        public IActionResult SearchWord(string searchText)
        {

            

            // call the sorting method to show first 10 key pairs
            // send this list to the view 


        }
        

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
