namespace usecase.Cases.ManterLojas.Input
{
    public class EntradaParaInativaLoja
    {
        public EntradaParaInativaLoja(int lojaId)
        {
            LojaId = lojaId;
            InativarLoja = false;
        }

        public int LojaId { get; private set; }
        
        public bool InativarLoja { get; private set; }
    }
}