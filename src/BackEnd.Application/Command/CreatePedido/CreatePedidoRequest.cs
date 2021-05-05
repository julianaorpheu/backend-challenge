using System.Text.Json.Serialization;
using MediatR;
using System.Collections.Generic;

namespace BackEnd.Application.Command.Generic
{
     public class CreatePedidoRequest : IRequest<CreatePedidoResponse>
    {
        [JsonPropertyNameAttribute("pedido")]
        public string pedido { get; set; }

        [JsonPropertyNameAttribute("itens")]
        public List<itens> itens { get; set; }
    }
}