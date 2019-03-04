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
            throw new System.NotImplementedException();
        }
    }
}