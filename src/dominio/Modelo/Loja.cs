using System.Collections.Generic;
using dominio.Scopers;
using FluentValidation.Results;

namespace dominio.Modelo
{
    public class Loja
    {
        public Loja(string nome, string email, string telefone, string rua, string numero, string bairro, string cep)
        {
            AlterarEndereco(cep, rua, bairro, numero);
            AlterarDadosBasicos(nome, email, telefone);
            StatusDeAtualizacaoCadastral = false;
        }

        protected Loja()
        {

        }

        public int Id { get; private set; }
        
        public string NomeDaLoja { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; protected set; }

        public byte[] Fachada { get; private set; }

        public string Rua { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public bool StatusDeAtualizacaoCadastral { get; private set; }

        public Cota Cota { get; private set; }

        public ICollection<Produto> Produtos { get; private set; }

        public ValidationResult Validar()
        {
            return new ValidacaoDoCadastroDaLoja().Validate(this);
        }

        public void AlterarSituacaoCadastral(bool intencaoDeAprovacao)
        {
            StatusDeAtualizacaoCadastral = intencaoDeAprovacao;
        }

        public void AlterarEndereco(string cep, string rua, string bairro, string numero)
        {
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }

        public void AlterarDadosBasicos(string nome, string email, string telefone)
        {
            DefinirNome(nome);
            DefinirEmail(email);
            DefinirTelefone(telefone);
        }

        public void AlterarDocumentos(byte[] fachada)
        {
            Fachada = fachada;
        }

        protected void DefinirTelefone(string telefone)
        {
            if (!string.IsNullOrWhiteSpace(telefone)) Telefone = telefone;
        }

        protected void DefinirNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome)) NomeDaLoja = nome;
        }

        protected void DefinirEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email)) Email = email;
        }
    }
}