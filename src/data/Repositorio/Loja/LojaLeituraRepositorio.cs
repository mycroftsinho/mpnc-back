using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using usecase.Repositorio.Loja;

namespace data.Repositorio.Loja
{
    public class LojaLeituraRepositorio : ILojaLeituraRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public LojaLeituraRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<dominio.Modelo.Loja> BuscarLoja(string nome)
        {
            return await _contexto.Loja.AsNoTracking().FirstOrDefaultAsync(x => x.Nome.Equals(nome));
        }

        public async Task<dominio.Modelo.Loja> BuscarLojaPorId(int lojaId)
        {
            return await _contexto.Loja.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(lojaId));
        }
    }
}