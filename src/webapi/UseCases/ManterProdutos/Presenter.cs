using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.ManterProdutos.Output;

namespace webapi.UseCases.ManterProdutos
{
    public class Presenter : ILimiteDeSaida<SaidaDeAlteracoesDeProdutos>
    {
        public SaidaDeAlteracoesDeProdutos Saida { get; private set; }
        public IActionResult ViewModel { get; private set; }

        public void Popular(SaidaDeAlteracoesDeProdutos resposta)
        {
            throw new System.NotImplementedException();
        }
    }
}