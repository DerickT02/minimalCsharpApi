using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace apifromscratch.Models{
    public class CarsDBContext : DbContext{
    public CarsDBContext(DbContextOptions<CarsDBContext> options) : base(options)
    {
        
    }
    public DbSet<CarsModel> GetCars {get; set;}
}
}
