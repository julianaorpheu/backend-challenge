using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.CrossCutting.DependencyInjection
{
   [ExcludeFromCodeCoverage]
 public class ApplicationDbContext:DbContext  
  {  
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context):base(context)  
    {  
    }
    public DbSet<Pedido> Pedido { get; set; } 
     public DbSet<Itens> Itens { get; set; } 
  }
}