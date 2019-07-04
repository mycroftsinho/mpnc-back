using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using usecase.Repositorio.Endereco;

namespace data.Repositorio.Endereco
{
    public class EnderecoLeituraRepositorio : IEnderecoLeituraRepositorio
    {
        private readonly BuscadorContexto contexto;

        public EnderecoLeituraRepositorio(BuscadorContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<dominio.Modelo.Endereco> BuscarEnderecoPorId(int enderecoId)
        {
            return await contexto.Endereco.FindAsync(enderecoId);
        }

        public async Task<IEnumerable<dominio.Modelo.Endereco>> BuscarEnderecosDaLoja(int lojaId)
        {
            return await contexto.Endereco.AsNoTracking().Where(x => x.LojaId == lojaId).ToListAsync();
        }

        public async Task<IEnumerable<dominio.Modelo.Endereco>> BuscarEnderecosDaLoja(int lojaId, string email)
        {
            return lojaId > 0
                ? await contexto.Endereco.AsNoTracking().Where(x => x.LojaId == lojaId).ToListAsync()
                : await contexto.Endereco.AsNoTracking().Where(x => x.Loja.Email.Equals(email)).ToListAsync();
        }
    }
}