namespace webapi.UseCases.AprovarSolicitacaoDeCadastro
{
    public class AprovacaoRequest
    {
        
        public int LojaId { get; set; }
        
        public bool IntencaoDeAprovacao { get; set; }

        public string Cnpj { get; set; }

        public string Email { get; set; }
    }
}