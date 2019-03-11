namespace usecase.Cases.ManterLojas.Input
{
    public class EntradaParaInativarLoja
    {
        public EntradaParaInativarLoja(int lojaId)
        {
            LojaId = lojaId;
            InativarLoja = false;
        }

        public int LojaId { get; private set; }
        
        public bool InativarLoja { get; private set; }
    }
}