using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projekti_TI_2_Posta.Domain.Repository;
using Projekti_TI_2_Posta.Infrastructure.Identity;
using Projekti_TI_2_Posta.Infrastructure.Presistence;
using Projekti_TI_2_Posta.Infrastructure.Presistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddUserManager<UserManager<AppUser>>()
                .AddEntityFrameworkStores<PostaDbContext>();

            services.AddScoped<IPorosiaRepository, PorosiaRepository>();


            return services;
        }
    }
}