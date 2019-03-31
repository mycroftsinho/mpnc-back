﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data.Contexto;

namespace data.Migrations
{
    [DbContext(typeof(BuscadorContexto))]
    partial class BuscadorContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dominio.Modelo.Cota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LojaId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("LojaId")
                        .IsUnique();

                    b.ToTable("Cota");
                });

            modelBuilder.Entity("dominio.Modelo.Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<byte[]>("Fachada");

                    b.Property<string>("NomeDaLoja")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Rua")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("StatusDeAtualizacaoCadastral");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Loja");
                });

            modelBuilder.Entity("dominio.Modelo.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("LojaId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("LojaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("dominio.Modelo.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PerfilDeAcesso")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("dominio.Modelo.Cota", b =>
                {
                    b.HasOne("dominio.Modelo.Loja", "Loja")
                        .WithOne("Cota")
                        .HasForeignKey("dominio.Modelo.Cota", "LojaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("dominio.Modelo.Produto", b =>
                {
                    b.HasOne("dominio.Modelo.Loja", "Loja")
                        .WithMany("Produtos")
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
