using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;
using System.Diagnostics;

namespace PracticeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputText)
        {
            
            
            BinaryTree<string> binaryTree;

            bool confirmed = binaryTree.ReadString(inputText);

            ViewBag.Success = confirmed;
            ViewBag.Message = "Text succesfully proceesed";

            if (confirmed ==true) {
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
