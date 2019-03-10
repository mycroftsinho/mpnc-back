namespace usecase.Cases.DefinirCotas.Output
{
    public class SaidaDeCota
    {
        public SaidaDeCota(int lojaId, int? quantidade, string nome, string email, string telefone)
        {
            LojaId = lojaId;
            Quantidade = quantidade ?? 0;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public int LojaId { get; private set; }
        public int Quantidade { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
}