namespace usecase.Cases.ManterLojas.Input
{
    public class EntradaDeListagemDasLojas
    {
        public EntradaDeListagemDasLojas(int? id = null)
        {
            Id = id;
        }

        public int? Id { get; private set; }
    }
}