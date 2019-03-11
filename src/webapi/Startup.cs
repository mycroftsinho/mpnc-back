using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Gateways;
using data.Contexto;
using data.Repositorio.Cota;
using data.Repositorio.Loja;
using data.Repositorio.Produto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using usecase.Cases.AprovarSolicitacaoDeCadastro;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Input;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;
using usecase.Cases.DefinirCotas;
using usecase.Cases.DefinirCotas.Input;
using usecase.Cases.DefinirCotas.Output;
using usecase.Cases.ManterLojas;
using usecase.Cases.ManterLojas.Input;
using usecase.Cases.ManterLojas.Output;
using usecase.Cases.ManterProdutos;
using usecase.Cases.ManterProdutos.Input;
using usecase.Cases.ManterProdutos.Output;
using usecase.Cases.SolicitarCadastro;
using usecase.Cases.SolicitarCadastro.Input;
using usecase.Cases.SolicitarCadastro.Output;
using usecase.Repositorio.Cota;
using usecase.Repositorio.Loja;
using usecase.Repositorio.Produto;

namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDbContext<BuscadorContexto>();

            // Solicitar Cadastro
            services.AddScoped<ILimiteDeEntrada<EntradaDeSolicitacaoDeCadastro>, SolicitarCadastroPelaLoja>();
            services.AddScoped<ILimiteDeSaida<SaidaDaSolicitacaoDeCadastro>, UseCases.SolicitarCadastro.Presenter>();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for 
                // production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
