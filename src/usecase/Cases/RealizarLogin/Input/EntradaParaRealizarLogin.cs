namespace usecase.Cases.RealizarLogin.Input
{
    public class EntradaParaRealizarLogin
    {
        public EntradaParaRealizarLogin(string userName, string accessKey)
        {
            UserName = userName;
            AccessKey = accessKey;
        }

        public string UserName { get; private set; }
        public string AccessKey { get; private set; }
    }
}