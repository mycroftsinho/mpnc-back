using System.Collections.Generic;
using dominio.Scopers;
using FluentValidation.Results;

namespace dominio.Modelo
{
    public class Loja
    {
        public Loja(string nome, string email, string telefone, string cnpj, string empresa)
        {
            AlterarDadosBasicos(nome, email, telefone);
            AlterarDadosLegais(cnpj,empresa);
            StatusDeAtualizacaoCadastral = false;
        }

        protected Loja()
        {

        }

        public int Id { get; private set; }
        
        public string Representante { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; protected set; }

        public byte[] Fachada { get; private set; }

        public string Cnpj { get; private set; }

        public string Empresa { get; private set; }

        public bool StatusDeAtualizacaoCadastral { get; private set; }

        public Cota Cota { get; private set; }

        public ICollection<Produto> Produtos { get; private set; }

        public ICollection<Endereco> Enderecos { get; private set; }

        public ValidationResult Validar()
        {
            return new ValidacaoDoCadastroDaLoja().Validate(this);
        }

        public void AlterarSituacaoCadastral(bool intencaoDeAprovacao)
        {
            StatusDeAtualizacaoCadastral = intencaoDeAprovacao;
        }

        public void AlterarDadosLegais(string cnpj, string empresa)
        {
            Cnpj = cnpj;
            Empresa = empresa;
        }

        public void AlterarDadosBasicos(string nome, string email, string telefone)
        {
            DefinirEmail(email);
            DefinirTelefone(telefone);
            DefinirRepresentante(nome);
        }

        public void AlterarDocumentos(byte[] fachada)
        {
            Fachada = fachada;
        }

        protected void DefinirTelefone(string telefone)
        {
            if (!string.IsNullOrWhiteSpace(telefone)) Telefone = telefone;
        }

        protected void DefinirRepresentante(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome)) Representante = nome;
        }

        protected void DefinirEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email)) Email = email;
        }
    }
}