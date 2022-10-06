//using CalculadoraROI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CalculadoraROI.Controllers
//{
//    public class CalculadoraController : Controller
//    {
       
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // POST: CalculadoraController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Index([FromForm] Calculadora calculadora)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    return View();
//                }
//            }
//            catch
//            {
//                return View();
//            }
//        }

       
//    }
//}
