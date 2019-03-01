namespace core.Gateways
{
    public interface IConverterSaida
    {
        T Map<T>(object source);
    }
}