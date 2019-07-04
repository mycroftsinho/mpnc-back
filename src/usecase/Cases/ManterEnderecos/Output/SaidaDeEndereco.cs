using dominio.Modelo;

namespace usecase.Cases.ManterEnderecos.Output
{
    public class SaidaDeEndereco
    {
        public SaidaDeEndereco(Endereco endereco)
        {
            Id = endereco.Id;
            LojaId = endereco.LojaId;
            Rua = endereco.Rua;
            Numero = endereco.Numero;
            Bairro = endereco.Bairro;
            Cep = endereco.Cep;
            Imagem = endereco.Imagem;
            ContentType = endereco.ContentType;
        }

        public int Id { get; private set; }

        public int LojaId { get; private set; }

        public string Rua { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public byte[] Imagem { get; private set; }

        public string ContentType { get; private set; }
    }
}