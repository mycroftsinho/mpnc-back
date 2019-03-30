using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using usecase.Repositorio.Usuario;

namespace data.Repositorio.Produto
{
    public class UsuarioEscritaRepositorio : IUsuarioEscritaRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public UsuarioEscritaRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task GravarUsuario(Usuario usuario)
        {
            await _contexto.AddAsync(usuario);
            await _contexto.SaveChangesAsync();
        }
    }
}