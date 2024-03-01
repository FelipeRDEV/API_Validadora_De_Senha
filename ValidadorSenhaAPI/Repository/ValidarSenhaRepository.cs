using System.Text.RegularExpressions;
using ValidadorSenhaAPI.IRepository;

namespace ValidadorSenhaAPI.Repository
{
    public class ValidarSenhaRepository : IValidarSenhaRepository
    {

        List<string> errosAoValidarSenha = new List<string>();

        public List<string> VerificarTamanhoDaSenha (string senha)
        {

            errosAoValidarSenha.Clear();

            if (string.IsNullOrWhiteSpace(senha))
            {
                errosAoValidarSenha.Add("A Senha não pode estar vazia, ela deve possuir ao menos um digito.");

            }

            if (senha.Length < 9)
            {
                errosAoValidarSenha.Add("O tamanho da senha deve ser maior que 9 caracteres.");
            }

            return errosAoValidarSenha;

        }

        public List<string> VerificarMaiusculasEminusculas(string senha) 
        {
            errosAoValidarSenha.Clear();

            if (!senha.Any(char.IsUpper))
            {
                errosAoValidarSenha.Add("A senha deve conter pelo menos uma letra maiúscula.");

            }

            if (!senha.Any(char.IsLower))
            {
                errosAoValidarSenha.Add("A senha deve conter pelo menos uma letra minúscula.");

            }

            return errosAoValidarSenha;
        }

        public List<string> VerificarCaracteresEspeciais(string senha)
        {
            errosAoValidarSenha.Clear();

            string caracteresEspeciais = @"[!@#$%^&*()-+]";

            if(!Regex.IsMatch(senha, caracteresEspeciais))
            {
                errosAoValidarSenha.Add("A senha deve possuir pelo menos um caractere especial.");

            }

            return errosAoValidarSenha;
        }

        public List<string> VerificarRepetidosEespacoEmBranco(string senha)
        {
            errosAoValidarSenha.Clear();

            if (senha.GroupBy(c => c).Any(g => g.Count() > 1))
            {

                errosAoValidarSenha.Add("A senha não pode conter caracteres repetidos.");

            }

            if (senha.Contains(' '))
            {
                errosAoValidarSenha.Add("A senha não pode conter espaços em branco.");

            }

            return errosAoValidarSenha;
        }


    }
}
