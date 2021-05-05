using System.Text.Json.Serialization;

namespace BackEnd.Application.Command.Generic
{
    public class itens
    {
        [JsonPropertyNameAttribute("id")]
        public string id { get; set; }
        
        [JsonPropertyNameAttribute("descricao")]
        public string descricao { get; set; }

        [JsonPropertyNameAttribute("precoUnitario")]
        public int precoUnitario { get; set; }

        [JsonPropertyNameAttribute("qtd")]
        public int qtd { get; set; }
        
    }
}