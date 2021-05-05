using System.Text.Json.Serialization;
using MediatR;

namespace BackEnd.Application.Command.Generic
{
    public class FindPedidoRequest : IRequest<FindPedidoResponse>
    {
        [JsonPropertyNameAttribute("pedido")]
        public string pedido { get; set; }

    }
}