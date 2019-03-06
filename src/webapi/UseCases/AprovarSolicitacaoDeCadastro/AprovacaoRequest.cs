namespace webapi.UseCases.AprovarSolicitacaoDeCadastro
{
    public class AprovacaoRequest
    {
        public int LojaId { get; set; }
        
        public bool IntencaoDeSolicitacao { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
    }
}