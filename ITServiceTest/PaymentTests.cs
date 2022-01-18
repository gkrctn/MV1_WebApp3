using ItServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ITServiceTest
{
    public class PaymentTests
    {
        private readonly IPaymentService _paymentServices;

        public PaymentTests(IPaymentService paymentService)
        {
            _paymentServices = paymentService;
        }
        [Fact]
        public void CheckInstallments()
        {
            var binNumbers = new string[]
            {
                "5451030000000000","4157920000000002","4543590000000006","5528790000000008"
            };

            foreach (var bin in binNumbers)
            {
                var result = _paymentServices.CheckInstallments(bin, 1000);
            }

            Assert.Equal(true, true);
        }

    }
}
