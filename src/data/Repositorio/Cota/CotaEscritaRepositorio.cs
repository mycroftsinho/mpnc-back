using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using usecase.Repositorio.Cota;

namespace data.Repositorio.Cota
{
    public class CotaEscritaRepositorio : ICotaEscritaRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public CotaEscritaRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AtualizarCota(dominio.Modelo.Cota cotaDaLoja)
        {
            _contexto.Update(cotaDaLoja);
            await _contexto.SaveChangesAsync();
        }

        public async Task GravarCota(dominio.Modelo.Cota cotaDaLoja)
        {
            await _contexto.AddAsync(cotaDaLoja);
            await _contexto.SaveChangesAsync();
        }
    }
}