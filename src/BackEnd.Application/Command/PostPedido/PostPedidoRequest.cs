using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace BackEnd.Application.Command.Generic
{
    public class PostPedidoRequest : IRequest<PostPedidoResponse>
    {
        [JsonPropertyNameAttribute("pedido")]
        public string pedido { get; set; }

        [JsonPropertyNameAttribute("itens")]
        public List<itens> itens { get; set; }
    }
}