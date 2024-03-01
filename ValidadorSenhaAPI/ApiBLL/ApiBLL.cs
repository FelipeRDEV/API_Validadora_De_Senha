using ValidadorSenhaAPI.Models;
using ValidadorSenhaAPI.Repository;

namespace ValidadorSenhaAPI.ApiBLL
{
    public class ValidadorSenhaApiBLL
    {
        public SenhaRetornoAPIModel VerificarParametrosSenhaValida(string senha)
        {
            var retornoVerificacaoSenha = new SenhaRetornoAPIModel();

            var repo = new ValidarSenhaRepository();

            List<string> errosVerificacaoSenha = new List<string>();

            bool senhaValida = false;

            errosVerificacaoSenha.AddRange(repo.VerificarTamanhoDaSenha(senha));
            errosVerificacaoSenha.AddRange(repo.VerificarMaiusculasEminusculas(senha));
            errosVerificacaoSenha.AddRange(repo.VerificarCaracteresEspeciais(senha));
            errosVerificacaoSenha.AddRange(repo.VerificarRepetidosEespacoEmBranco(senha));

            if (!errosVerificacaoSenha.Any())
            {
                senhaValida = true;

            }

            retornoVerificacaoSenha.SenhaValida = senhaValida;

            retornoVerificacaoSenha.Erros = errosVerificacaoSenha.ToArray();

            return retornoVerificacaoSenha;
        }
    }
}
