using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.CrossCutting.DependencyInjection
{
   public class Pedido  
{    
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int id {get; set;}
      public string pedido { get; set; }
}  
}