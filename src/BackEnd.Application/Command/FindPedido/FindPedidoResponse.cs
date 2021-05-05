using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace BackEnd.Application.Command.Generic
{
    public class FindPedidoResponse
    {
        [JsonPropertyNameAttribute("mensagem")]
        public string mensagem { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int statusCode { get; set; }

        [JsonPropertyNameAttribute("pedido")]
        public string pedido { get; set; }

        [JsonPropertyNameAttribute("id")]
        public int id { get; set; }

        [JsonPropertyNameAttribute("itens")]
        public List<itens> itens { get; set; }


        
    }
}