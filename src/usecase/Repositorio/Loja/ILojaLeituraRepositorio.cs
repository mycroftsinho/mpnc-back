using System.Collections.Generic;
using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Loja
{
    public interface ILojaLeituraRepositorio
    {
        Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasComCadastrosPendentes();
        
        Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasCadastradas();

        Task<dominio.Modelo.Loja> BuscarLoja(string email, string nome);
        
        Task<dominio.Modelo.Loja> BuscarLojaPorId(int lojaId);
    }
}