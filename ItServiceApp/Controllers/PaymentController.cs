using ItServiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            //var result = _paymentService.CheckInstallments
            //    ("4157920000000002", 1000);
            


            return View();
        }
        [HttpPost]
        public IActionResult CheckInstallment(string binNumber)
        {
            var result = _paymentService.CheckInstallments(binNumber, 1000);
        }
    }
}
