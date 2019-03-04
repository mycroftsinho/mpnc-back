namespace usecase.Cases.DefinirCotas.Input
{
    public class EntradaParaDefinicaoDeCota
    {
        public EntradaParaDefinicaoDeCota(int lojaId, int quantidade)
        {
            LojaId = lojaId;
            Quantidade = quantidade;
        }

        public int LojaId { get; private set; }
        
        public int Quantidade { get; private set; }
    }
}