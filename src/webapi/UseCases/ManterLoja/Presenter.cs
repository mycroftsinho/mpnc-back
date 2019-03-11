using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.ManterLojas.Output;

namespace webapi.UseCases.ManterLoja
{
    public class Presenter : ILimiteDeSaida<SaidaDeAlteracaoDeLojas>
    {
        public SaidaDeAlteracaoDeLojas Saida { get; private set; }
        
        public IActionResult ViewModel { get; private set; }

        public void Popular(SaidaDeAlteracaoDeLojas resposta)
        {
            if(resposta == null)
            {
                ViewModel = new BadRequestResult();
                return;
            }

            if(resposta.Loja != null)
            {
                ViewModel = new JsonResult(resposta.Loja);
                return;
            }

            if(resposta.Lojas != null)
            {
                ViewModel = new JsonResult(resposta.Lojas);
                return;
            }

            if(resposta.Erros != null)
            {
                ViewModel = new JsonResult(resposta.Erros);
                return;
            }

            if(resposta.Situacao)
                ViewModel = new OkResult();
            else
                ViewModel = new NoContentResult();
        }
    }
}