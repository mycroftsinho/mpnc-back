using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using usecase.Repositorio.Cota;

namespace data.Repositorio.Cota
{
    public class CotaLeituraRepositorio : ICotaLeituraRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public CotaLeituraRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<dominio.Modelo.Cota> BuscarCotaDaLoja(int lojaId)
        {
            return  await _contexto.Cota.FirstOrDefaultAsync(x => x.LojaId == lojaId);
        }
    }
}