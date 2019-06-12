using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using usecase.Repositorio.Endereco;

namespace data.Repositorio.Endereco
{
    public class EnderecoEscritaRepositorio : IEnderecoEscritaRepositorio
    {
        private readonly BuscadorContexto contexto;

        public EnderecoEscritaRepositorio(BuscadorContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task Gravar(dominio.Modelo.Endereco novoEndereco)
        {
            await contexto.AddAsync(novoEndereco);
            await contexto.SaveChangesAsync();
        }

        public async Task Atualizar(dominio.Modelo.Endereco endereco)
        {
            contexto.Update(endereco);
            await contexto.SaveChangesAsync();
        }

        public async Task Remover(dominio.Modelo.Endereco endereco)
        {
            contexto.Remove(endereco);
            await contexto.SaveChangesAsync();
        }
    }
}