using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Loja
{
    public interface ILojaLeituraRepositorio
    {
        Task<dominio.Modelo.Loja> BuscarLoja(string nome);
        Task<dominio.Modelo.Loja> BuscarLojaPorId(int lojaId);
    }
}