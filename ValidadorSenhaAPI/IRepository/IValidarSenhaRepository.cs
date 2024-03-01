namespace ValidadorSenhaAPI.IRepository
{
    public interface IValidarSenhaRepository
    {
        public List<string> VerificarTamanhoDaSenha(string senha);
        public List<string> VerificarMaiusculasEminusculas(string senha);
        public List<string> VerificarCaracteresEspeciais(string senha);
        public List<string> VerificarRepetidosEespacoEmBranco(string senha);

    }
}
