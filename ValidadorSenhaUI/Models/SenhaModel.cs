using System.Text.Json.Serialization;

namespace ValidadorSenhaUI.Models
{
    public class SenhaModel
    {
        public string? Senha { get; set; }
        
        [JsonPropertyName("senhaValida")]
        public bool SenhaValida { get; set; }
       
        [JsonPropertyName("erros")]
        public string[]? Erros { get; set; }
        public string? JsonRecebidoPelaAPI { get; set; }


    }
}
