using System.Collections.Generic;
using System.Threading.Tasks;

namespace usecase.Repositorio.Endereco
{
    public interface IEnderecoLeituraRepositorio
    {
        Task<IEnumerable<dominio.Modelo.Endereco>> BuscarEnderecosDaLoja(int lojaId, string email);
        Task<dominio.Modelo.Endereco> BuscarEnderecoPorId(int enderecoId);
    }
}