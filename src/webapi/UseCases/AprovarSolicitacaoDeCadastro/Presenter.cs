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
            if(resposta == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            if(resposta.Situacao)
                ViewModel = new OkResult();
            else
                ViewModel = new BadRequestResult();
        }
    }
}