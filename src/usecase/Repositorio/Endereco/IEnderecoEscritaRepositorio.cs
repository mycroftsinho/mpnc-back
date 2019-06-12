using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Endereco
{
    public interface IEnderecoEscritaRepositorio
    {
        Task Atualizar(dominio.Modelo.Endereco endereco);
        
        Task Remover(dominio.Modelo.Endereco endereco);
        
        Task Gravar(dominio.Modelo.Endereco novoEndereco);
    }
}