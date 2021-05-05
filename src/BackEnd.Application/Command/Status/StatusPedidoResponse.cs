using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace BackEnd.Application.Command.Generic
{
    public class StatusPedidoResponse
    {
        [JsonPropertyNameAttribute("pedido")]
        public string pedido { get; set; }
        [JsonPropertyNameAttribute("status")]
        public string status { get; set; }

         [JsonPropertyNameAttribute("statusCode")]
        public int statusCode { get; set; }
    }
}