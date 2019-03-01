using System.Threading.Tasks;

namespace core.Gateways
{
    public interface ILimiteDeEntrada<T>
    {
        Task Executar(T entrada);
    }
}