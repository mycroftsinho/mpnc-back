namespace core.Gateways
{
    public interface ILimiteDeSaida<T>
    {
        T Saida { get; }

        void Popular(T resposta);
    }
}