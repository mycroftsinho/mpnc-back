using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using usecase.Repositorio.Usuario;

namespace data.Repositorio.Produto
{
    public class UsuarioLeituraRepositorio : IUsuarioLeituraRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public UsuarioLeituraRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario> BuscarUsuario(string userName, string password)
        {
            return await _contexto.Usuario.FirstOrDefaultAsync(x => x.Nome.Equals(userName) && x.Password.Equals(password));
        }

        public async Task<Usuario> BuscarUsuarioPorEmail(string email)
        {
            return await _contexto.Usuario.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}