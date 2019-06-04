using System.Linq;
using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;

namespace webapi.UseCases.AprovarSolicitacaoDeCadastro
{
    public class Presenter : ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao>
    {
        public IActionResult ViewModel { get; set; }

        public SaidaDeAprovacaoDeSolicitacao Saida { get; set; }

        public void Popular(SaidaDeAprovacaoDeSolicitacao resposta)
        {
            if (resposta == null)
            {
                ViewModel = new BadRequestObjectResult("Erro ao encontrar a(s) loja(s)!");
                return;
            }

            if (resposta.Solicitacao != null)
            {
                ViewModel = new JsonResult(resposta.Solicitacao);
                return;
            }

            if (resposta.ListagemDeSolicitacoes != null && resposta.ListagemDeSolicitacoes.Any())
            {
                ViewModel = new JsonResult(resposta.ListagemDeSolicitacoes);
                return;
            }

            if (resposta.Situacao)
                ViewModel = new OkResult();
            else
                ViewModel = new BadRequestObjectResult("Falha no cadastro da loja. Tente novamente!");
        }
    }
}