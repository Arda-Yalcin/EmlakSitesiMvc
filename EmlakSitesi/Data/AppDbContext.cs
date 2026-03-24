using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmlakSitesi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmlakSitesi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Ilan> Ilanlar {get; set;}
    }
}