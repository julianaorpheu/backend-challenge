using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace BackEnd.Application.Command.Generic
{
    public class StatusPedidoRequest : IRequest<StatusPedidoResponse>
    {
        [JsonPropertyNameAttribute("status")]
        public string status { get; set; }

        [JsonPropertyNameAttribute("itensAprovados")]
        public int itensAprovados { get; set; }

        [JsonPropertyNameAttribute("valorAprovado")]
        public int valorAprovado { get; set; }

        [JsonPropertyNameAttribute("pedido")]
        public string pedido { get; set; }
        
    }
}