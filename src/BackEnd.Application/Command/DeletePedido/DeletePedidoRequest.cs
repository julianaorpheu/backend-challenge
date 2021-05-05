using System.Text.Json.Serialization;
using MediatR;

namespace BackEnd.Application.Command.Generic
{
     public class DeletePedidoRequest : IRequest<DeletePedidoResponse>
    {
        [JsonPropertyNameAttribute("pedido")]
         public string pedido {get; set;}
    }
}