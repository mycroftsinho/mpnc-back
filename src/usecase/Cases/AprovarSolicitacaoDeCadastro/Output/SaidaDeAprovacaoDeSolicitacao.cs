using System.Collections.Generic;

namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Output
{
    public class SaidaDeAprovacaoDeSolicitacao
    {
        public SaidaDeAprovacaoDeSolicitacao(bool situacao, ICollection<SaidaDeLojas> lojas = null, SaidaDeLojas cadastro = null)
        {
            Situacao = situacao;
            Solicitacao = cadastro;
            ListagemDeSolicitacoes = lojas;
        }

        public bool Situacao { get; private set; }

        public SaidaDeLojas Solicitacao { get; private set; }

        public ICollection<SaidaDeLojas> ListagemDeSolicitacoes { get; private set; }
    }
}