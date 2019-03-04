using System.Threading.Tasks;

namespace usecase.Repositorio.Cota
{
    public interface ICotaLeituraRepositorio
    {
        Task<dominio.Modelo.Cota> BuscarCotaDaLoja(int lojaId);
    }
}