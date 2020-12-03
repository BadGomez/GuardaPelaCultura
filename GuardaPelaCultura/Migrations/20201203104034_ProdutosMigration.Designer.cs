﻿// <auto-generated />
using GuardaPelaCultura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuardaPelaCultura.Migrations
{
    [DbContext(typeof(GuardaPelaCulturaContext))]
    [Migration("20201203104034_ProdutosMigration")]
    partial class ProdutosMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuardaPelaCultura.Models.Produtos", b =>
                {
                    b.Property<int>("ProdutosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProduto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdutosId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("GuardaPelaCultura.Models.ReservasTakeAway", b =>
                {
                    b.Property<int>("ReservasTakeAwayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("NomeRestaurante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservasTakeAwayId");

                    b.ToTable("ReservasTakeAway");
                });
#pragma warning restore 612, 618
        }
    }
}
