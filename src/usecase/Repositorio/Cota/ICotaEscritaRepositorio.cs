using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Cota
{
    public interface ICotaEscritaRepositorio
    {
        Task GravarCota(dominio.Modelo.Cota cotaDaLoja);
        Task AtualizarCota(dominio.Modelo.Cota cotaDaLoja);
    }
}