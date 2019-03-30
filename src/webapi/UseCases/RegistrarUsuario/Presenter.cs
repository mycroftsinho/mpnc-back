using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.RegistrarUsuario.Output;

namespace webapi.UseCases.RegistrarUsuario
{
    public class Presenter : ILimiteDeSaida<SaidaParaRegistrarUsuario>
    {
        public SaidaParaRegistrarUsuario Saida { get; private set; }
        public IActionResult ViewModel { get; private set; }

        public void Popular(SaidaParaRegistrarUsuario resposta)
        {
            if(resposta == null)
            {
                ViewModel = new BadRequestResult();
                return;
            }

            if(resposta.Situacao)
            {
                ViewModel = new OkResult();
                return;
            }
            ViewModel = new BadRequestResult();
        }
    }
}