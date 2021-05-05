using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.CrossCutting.DependencyInjection
{
   public class Itens  
      {    
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string idItem { get; set; }
            public string idIPedido { get; set; }
            public string descricao { get; set; }
            public int precoUnitario { get; set; }
            public int qtd { get; set; }
      }  
}