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

        public async Task<Login> BuscarUsuario(string userName, string accessKey)
        {
            return await _contexto.Login.FirstOrDefaultAsync(x => x.UserName.Equals(userName) && x.AccessKey.Equals(accessKey));
        }
    }
}