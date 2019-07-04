using System.Collections.Generic;
using System.Threading.Tasks;

namespace usecase.Repositorio.Loja
{
    public interface ILojaLeituraRepositorio
    {
        Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasComCadastrosPendentes();
        
        Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasCadastradas();
        
        Task<IEnumerable<dominio.Modelo.Loja>> BuscarLojasAtivas();

        Task<dominio.Modelo.Loja> BuscarLoja(string email, string cnpj);
        
        Task<dominio.Modelo.Loja> BuscarLojaPorId(int lojaId);
        
        Task<dominio.Modelo.Loja> BuscarLojaPorEmail(string email);
    }
}