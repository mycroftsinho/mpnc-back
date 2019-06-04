using dominio.Modelo;

namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Output
{
    public class SaidaDeLojas
    {
        public SaidaDeLojas(Loja loja)
        {
            LojaId = loja.Id;
            Cnpj = loja.Cnpj;
            Representante = loja.Representante;
            Empresa = loja.Empresa;
            Email = loja.Email;
            Telefone = loja.Telefone;
        }

        public int LojaId { get; private set; }
        
        public string Empresa { get; private set; }

        public string Cnpj { get; private set; }

        public string Representante { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }
    }
}