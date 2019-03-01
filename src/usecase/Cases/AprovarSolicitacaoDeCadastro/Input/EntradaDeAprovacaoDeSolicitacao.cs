namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Input
{
    public class EntradaDeAprovacaoDeSolicitacao
    {
        public EntradaDeAprovacaoDeSolicitacao(int lojaId, bool intencaoDeAprovacao)
        {
            LojaId = lojaId;
            IntencaoDeAprovacao = intencaoDeAprovacao;
        }

        public int LojaId { get; private set; }
        public bool IntencaoDeAprovacao { get; private set; }
    }
}