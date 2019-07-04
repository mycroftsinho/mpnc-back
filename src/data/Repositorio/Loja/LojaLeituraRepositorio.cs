using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasCadastradas()
        {
            return await _contexto.Loja.AsNoTracking().Where(x => x.StatusDeAtualizacaoCadastral).ToListAsync();
        }

        public async Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasComCadastrosPendentes()
        {
            return await _contexto.Loja.AsNoTracking().Where(x => !x.StatusDeAtualizacaoCadastral).ToListAsync();
        }

        public async Task<dominio.Modelo.Loja> BuscarLoja(string email, string cnpj)
        {
            return await _contexto.Loja.AsNoTracking().FirstOrDefaultAsync(x => x.Cnpj.Equals(cnpj) && x.Email.Equals(email));
        }

        public async Task<dominio.Modelo.Loja> BuscarLojaPorId(int lojaId)
        {
            return await _contexto.Loja.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(lojaId));
        }

        public async Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasAtivas()
        {
            return await _contexto.Loja.Include(x => x.Cota).AsNoTracking().Where(x => x.StatusDeAtualizacaoCadastral).ToListAsync();
        }

        public async Task<dominio.Modelo.Loja> BuscarLojaPorEmail(string email)
        {
            return await _contexto.Loja.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}