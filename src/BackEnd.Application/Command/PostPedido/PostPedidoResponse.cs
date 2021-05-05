using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace BackEnd.Application.Command.Generic
{
    public class PostPedidoResponse
    {
        [JsonPropertyNameAttribute("mensagem")]
        public string mensagem { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int statusCode { get; set; }

        
    }
}