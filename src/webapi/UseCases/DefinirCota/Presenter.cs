using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.DefinirCotas.Output;

namespace webapi.UseCases.DefinirCota
{
    public class Presenter : ILimiteDeSaida<SaidaDeDefinicaoDeCota>
    {
        public SaidaDeDefinicaoDeCota Saida { get; private set; }
        
        public IActionResult ViewModel { get; internal set; }

        public void Popular(SaidaDeDefinicaoDeCota resposta)
        {
            if(resposta == null)
            {
                ViewModel = new BadRequestResult();
                return;
            }

            if(resposta.Cotas != null)
            {
                ViewModel = new JsonResult(resposta.Cotas);
                return;
            }

            if(resposta.Situacao)
                ViewModel = new OkResult();
            else
                ViewModel = new ConflictResult();
        }
    }
}