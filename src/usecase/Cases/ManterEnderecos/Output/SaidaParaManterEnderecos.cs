using System.Collections.Generic;
using FluentValidation.Results;

namespace usecase.Cases.ManterEnderecos.Output
{
    public class SaidaParaManterEnderecos
    {
        public SaidaParaManterEnderecos(bool situacao)
        {
            Situacao = situacao;
        }

        public SaidaParaManterEnderecos(bool situacao, SaidaDeEndereco resposta)
        {
            Situacao = situacao;
            Resposta = resposta;
        }

        public SaidaParaManterEnderecos(bool situacao, ICollection<SaidaDeEndereco> listaDeRespostas)
        {
            Situacao = situacao;
            ListaDeResposta = listaDeRespostas;
        }

        public SaidaParaManterEnderecos(bool situacao, ICollection<ValidationFailure> listaDeErros)
        {
            Situacao = situacao;
            ListaDeErros = listaDeErros;
        }

        public bool Situacao { get; private set; }

        public SaidaDeEndereco Resposta { get; private set; }

        public ICollection<SaidaDeEndereco> ListaDeResposta { get; private set; }

        public ICollection<ValidationFailure> ListaDeErros { get; private set; }
    }
}