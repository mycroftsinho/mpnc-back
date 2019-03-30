using core.Gateways;
using data.Contexto;
using data.Repositorio.Cota;
using data.Repositorio.Loja;
using data.Repositorio.Produto;
using usecase.Repositorio.Loja;
using usecase.Repositorio.Cota;
using usecase.Cases.ManterLojas;
using usecase.Cases.DefinirCotas;
using usecase.Repositorio.Produto;
using usecase.Repositorio.Usuario;
using usecase.Cases.RealizarLogin;
using usecase.Cases.ManterProdutos;
using usecase.Cases.SolicitarCadastro;
using usecase.Cases.ManterLojas.Input;
using usecase.Cases.ManterLojas.Output;
using usecase.Cases.DefinirCotas.Input;
using usecase.Cases.DefinirCotas.Output;
using usecase.Cases.RealizarLogin.Input;
using usecase.Cases.RealizarLogin.Output;
using usecase.Cases.ManterProdutos.Input;
using usecase.Cases.ManterProdutos.Output;
using usecase.Cases.SolicitarCadastro.Input;
using usecase.Cases.SolicitarCadastro.Output;
using Microsoft.Extensions.DependencyInjection;
using usecase.Cases.AprovarSolicitacaoDeCadastro;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Input;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;
using usecase.Cases.RegistrarUsuario.Input;
using usecase.Cases.RegistrarUsuario;
using usecase.Cases.RegistrarUsuario.Output;

namespace webapi.Models
{
    public static class RegisterServicesExtension
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<BuscadorContexto>();

            // Solicitar Cadastro
            services.AddScoped<ILimiteDeEntrada<EntradaDeSolicitacaoDeCadastro>, SolicitarCadastroPelaLoja>();
            services.AddScoped<ILimiteDeSaida<SaidaDaSolicitacaoDeCadastro>, UseCases.SolicitarCadastro.Presenter>();

            // Realizar Login
            services.AddScoped<ILimiteDeEntrada<EntradaParaRealizarLogin>, RealizarLogin>();
            services.AddScoped<ILimiteDeSaida<SaidaDeRealizacaoDeLogin>, UseCases.RealizarLogin.Presenter>();

            // Registrar Usuarios
            services.AddScoped<ILimiteDeEntrada<EntradaParaRegistrarUsuario>, RegistrarUsuario>();
            services.AddScoped<ILimiteDeSaida<SaidaParaRegistrarUsuario>, UseCases.RegistrarUsuario.Presenter>();

            // Aprovar Solicitacao de Cadastro
            services.AddScoped<ILimiteDeEntrada<EntradaDeAprovacaoDeSolicitacao>, AprovarSolicitacaoDeCadastroPeloAdministrador>();
            services.AddScoped<ILimiteDeEntrada<EntradaDeListagemDeSolicitacoes>, ListagemDeSolicitacaoDeCadastro>();
            services.AddScoped<ILimiteDeEntrada<EntradaParaObterSolicitacao>, ObterSolicitacaoDaLoja>();
            services.AddScoped<ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao>, UseCases.AprovarSolicitacaoDeCadastro.Presenter>();

            // Definir Cotas
            services.AddScoped<ILimiteDeEntrada<EntradaParaDefinicaoDeCota>, DefinirCotaDaLoja>();
            services.AddScoped<ILimiteDeEntrada<EntradaParaListagemDeCota>, ListagemDeCotas>();
            services.AddScoped<ILimiteDeSaida<SaidaDeDefinicaoDeCota>, UseCases.DefinirCota.Presenter>();

            // Manter Lojas
            services.AddScoped<ILimiteDeEntrada<EntradaDeListagemDasLojas>, ListagemDasLojasCadastradas>();
            services.AddScoped<ILimiteDeEntrada<EntradaParaAlterarDadosDaLoja>, AlterarDadosDaLoja>();
            services.AddScoped<ILimiteDeEntrada<EntradaParaInativarLoja>, InativarLoja>();
            services.AddScoped<ILimiteDeSaida<SaidaDeAlteracaoDeLojas>, UseCases.ManterLoja.Presenter>();

            // Manter Produtos
            services.AddScoped<ILimiteDeEntrada<EntradaParaRemoverProduto>, RemoverProduto>();
            services.AddScoped<ILimiteDeEntrada<EntradaParaGravarOuAlterarProduto>, GravarOuAlterarProduto>();
            services.AddScoped<ILimiteDeEntrada<EntradaParaListarProdutos>, ListarProdutosDaLoja>();
            services.AddScoped<ILimiteDeEntrada<EntradaParaObterProduto>, ObterProduto>();
            services.AddScoped<ILimiteDeSaida<SaidaDeAlteracoesDeProdutos>, UseCases.ManterProdutos.Presenter>();

            // Repositorio
            services.AddScoped<ICotaLeituraRepositorio, CotaLeituraRepositorio>();
            services.AddScoped<ICotaEscritaRepositorio, CotaEscritaRepositorio>();
            services.AddScoped<ILojaLeituraRepositorio, LojaLeituraRepositorio>();
            services.AddScoped<ILojaEscritaRepositorio, LojaEscritaRepositorio>();
            services.AddScoped<IProdutoLeituraRepositorio, ProdutoLeituraRepositorio>();
            services.AddScoped<IProdutoEscritaRepositorio, ProdutoEscritaRepositorio>();
            services.AddScoped<IUsuarioLeituraRepositorio, UsuarioLeituraRepositorio>();
            services.AddScoped<IUsuarioEscritaRepositorio, UsuarioEscritaRepositorio>();

            return services;
        }
    }
}