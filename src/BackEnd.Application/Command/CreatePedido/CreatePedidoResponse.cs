using System.Text.Json.Serialization;

namespace BackEnd.Application.Command.Generic
{
      public class CreatePedidoResponse
    {
          [JsonPropertyNameAttribute("mensagem")]
         public string mensagem {get; set;}

         [JsonPropertyNameAttribute("statusCode")]
         public int statusCode {get; set;}
    }
}