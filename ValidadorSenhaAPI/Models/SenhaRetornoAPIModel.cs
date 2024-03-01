namespace ValidadorSenhaAPI.Models
{
    public class SenhaRetornoAPIModel
    {
         public bool SenhaValida { get; set; }
         public string[]? Erros { get; set; }
    }
}
