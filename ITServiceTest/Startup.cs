using ItServiceApp.MapperProfiles;
using ItServiceApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITServiceTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddScoped<IPaymentService, IyzicoPaymentService>();
            service.AddAutoMapper(options =>
            {
                options.AddProfile(typeof(PeymentProfile));
            });



        }

    }
}
