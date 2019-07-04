using System.IO;
using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.ManterEnderecos.Output;

namespace webapi.UseCases.ManterEnderecos
{
    public class Presenter : ILimiteDeSaida<SaidaParaManterEnderecos>
    {
        public IActionResult ViewModel { get; set; }

        public IActionResult File { get; set; }

        public SaidaParaManterEnderecos Saida { get; set; }

        public void Popular(SaidaParaManterEnderecos resposta)
        {
            if (resposta.Situacao)
            {
                if (resposta.Resposta != null)
                {
                    ViewModel = new JsonResult(resposta.Resposta);
                    return;
                }

                if (resposta.ListaDeResposta != null)
                {
                    ViewModel = new JsonResult(resposta.ListaDeResposta);
                    return;
                }

                ViewModel = new OkResult();
            }
            else
            {
                if (resposta.ListaDeErros != null)
                {
                    ViewModel = new BadRequestObjectResult(resposta.ListaDeResposta);
                    return;
                }

                ViewModel = new NotFoundResult();
            }
        }
    }
}