using System.Linq;
using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.SolicitarCadastro.Output;

namespace webapi.UseCases.SolicitarCadastro
{
    public class Presenter : ILimiteDeSaida<SaidaDaSolicitacaoDeCadastro>
    {
        public IActionResult ViewModel { get; private set; }

        public SaidaDaSolicitacaoDeCadastro Saida { get; private set; }

        public void Popular(SaidaDaSolicitacaoDeCadastro resposta)
        {
            if (resposta == null)
            {
                ViewModel = new NotFoundResult();
                return;
            }

            if(resposta.Erros != null && resposta.Erros.Any())
            {
                ViewModel = new BadRequestObjectResult(resposta.Erros.Select(x => $"{x.ErrorMessage} -"));
                return;
            }

            if (resposta.Resultado)
            {
                ViewModel = new OkResult();
                return;
            }
            else
            {
                ViewModel = new BadRequestResult();
                return;
            }
        }
    }
}