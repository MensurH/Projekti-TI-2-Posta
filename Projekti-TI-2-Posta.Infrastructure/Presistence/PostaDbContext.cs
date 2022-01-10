using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekti_TI_2_Posta.Domain.Entities;
using Projekti_TI_2_Posta.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Infrastructure.Presistence
{
    public class PostaDbContext:IdentityDbContext<AppUser>
    {
        public PostaDbContext(DbContextOptions<PostaDbContext> options):base(options)
        {

        }
        public DbSet<Porosia> Porosias { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
