namespace usecase.Cases.RealizarLogin.Output
{
    public class DadosDoUsuario
    {
        public DadosDoUsuario(int id, string userName, string perfil)
        {
            Id = id;
            UserName = userName;
            Perfil = perfil;
        }

        public int Id { get; private set; }

        public string UserName { get; set; }

        public string Perfil { get; private set; }
    }
}