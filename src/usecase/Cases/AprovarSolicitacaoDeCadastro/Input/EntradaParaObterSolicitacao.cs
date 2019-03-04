namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Input
{
    public class EntradaParaObterSolicitacao
    {
        public EntradaParaObterSolicitacao(int lojaId, string nome)
        {
            LojaId = lojaId;
            Nome = nome;
        }

        public int LojaId { get; private set; }

        public string Nome { get; private set; }
    }
}