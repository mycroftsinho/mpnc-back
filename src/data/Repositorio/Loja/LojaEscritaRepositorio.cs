using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using usecase.Repositorio.Loja;

namespace data.Repositorio.Loja
{
    public class LojaEscritaRepositorio : ILojaEscritaRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public LojaEscritaRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AtualizarLoja(dominio.Modelo.Loja loja)
        {
            _contexto.Update(loja);
            await _contexto.SaveChangesAsync();
        }

        public async Task GravarLoja(dominio.Modelo.Loja loja)
        {
            await _contexto.AddAsync(loja);
            await _contexto.SaveChangesAsync();
        }

        public async Task RemoverLoja(dominio.Modelo.Loja loja)
        {
            _contexto.Remove(loja);
            await _contexto.SaveChangesAsync();
        }
    }
}