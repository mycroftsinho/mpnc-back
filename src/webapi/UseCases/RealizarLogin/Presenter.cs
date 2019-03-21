using System;
using core.Gateways;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using usecase.Cases.RealizarLogin.Output;
using Microsoft.AspNetCore.Authorization;
using webapi.Models;
using Microsoft.IdentityModel.Tokens;

namespace webapi.UseCases.RealizarLogin
{
    public class Presenter : ILimiteDeSaida<SaidaDeRealizacaoDeLogin>
    {
        SigningConfigurations signingConfigurations;
        TokenConfigurations tokenConfigurations;

        public Presenter([FromServices] SigningConfigurations signingConfigurations, [FromServices] TokenConfigurations tokenConfigurations)
        {
            this.signingConfigurations = signingConfigurations;
            this.tokenConfigurations = tokenConfigurations;
        }

        public SaidaDeRealizacaoDeLogin Saida { get; private set; }

        public IActionResult ViewModel { get; private set; }

        public void Popular(SaidaDeRealizacaoDeLogin resposta)
        {
            if (resposta == null)
            {
                ViewModel = new BadRequestResult();
                return;
            }

            if (resposta.Situacao)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(resposta.UserName, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, resposta.UserName)
                    }
                );
                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                var resultado = new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };

                ViewModel = new JsonResult(resultado);
            }
            else
            {
                var resultado = new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
                 ViewModel = new JsonResult(resultado);
            }
        }
    }
}