namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Output
{
    public class SaidaDeAprovacaoDeSolicitacao
    {
        public SaidaDeAprovacaoDeSolicitacao(bool situacao)
        {
            Situacao = situacao;
        }

        public bool Situacao { get; private set; }
    }
}