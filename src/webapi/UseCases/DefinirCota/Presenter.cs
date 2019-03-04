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
            throw new System.NotImplementedException();
        }
    }
}