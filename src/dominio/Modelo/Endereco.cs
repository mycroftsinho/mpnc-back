using System;
using dominio.Scopers;
using FluentValidation.Results;

namespace dominio.Modelo
{
    public class Endereco
    {
        public Endereco(int lojaId, string rua, string numero, string bairro, string cep, string contentType = null, byte[] imagem = null)
        {
            LojaId = lojaId;
            Imagem = imagem;
            ContentType = contentType;
            AlterarRua(rua);
            AlterarBairro(bairro);
            AlterarCep(cep);
            AlterarNumero(numero);
        }

        protected Endereco()
        {
            
        }

        public int Id { get; private set; }

        public int LojaId { get; private set; }

        public string Rua { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public string ContentType { get; private set; }

        public byte[] Imagem { get; private set; }

        public Loja Loja { get; private set; }
        
        public ValidationResult Validar()
        {
            return new ValidacaoDoEndereco().Validate(this);
        }

        public void AlterarCep(string cep)
        {
            Cep = cep;
        }

        public void AlterarRua(string rua)
        {
            Rua = rua;
        }

        public void AlterarBairro(string bairro)
        {
            Bairro = bairro;
        }

        public void AlterarNumero(string numero)
        {
            Numero = numero;
        }

        public void AlterarImagem(byte[] imagem, string contentType)
        {
            if(imagem != null)
            {
                Imagem = imagem;
                ContentType = contentType;
            }
        }
    }
}