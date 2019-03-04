namespace dominio.Modelo
{
    public abstract class Usuario
    {
        protected Usuario(string nome, string email, string telefone)
        {
            DefinirNome(nome);
            DefinirEmail(email);
            DefinirTelefone(telefone);
        }

        protected Usuario()
        {

        }

        public int Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Email { get; protected set; }

        public string Telefone { get; protected set; }

        protected void DefinirTelefone(string telefone)
        {
            if (!string.IsNullOrWhiteSpace(telefone)) Telefone = telefone;
        }

        protected void DefinirEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email)) Email = email;
        }

        protected void DefinirNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome)) Nome = nome;
        }
    }
}