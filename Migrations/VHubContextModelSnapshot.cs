﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Context;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(VHubContext))]
    partial class VHubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Modelos.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Idade")
                        .HasColumnType("integer")
                        .HasColumnName("idade");

                    b.Property<bool>("MenorDeIdade")
                        .HasColumnType("boolean")
                        .HasColumnName("menor_de_idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("NomeMae")
                        .HasColumnType("text")
                        .HasColumnName("nome_mae");

                    b.HasKey("Id")
                        .HasName("pk_cliente");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Modelos.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cidade");

                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint")
                        .HasColumnName("cliente_id");

                    b.Property<string>("Complemento")
                        .HasColumnType("text")
                        .HasColumnName("complemento");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("estado");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("logradouro");

                    b.Property<int>("Numero")
                        .HasColumnType("integer")
                        .HasColumnName("numero");

                    b.HasKey("Id")
                        .HasName("pk_endereco");

                    b.HasIndex("ClienteId")
                        .HasDatabaseName("ix_endereco_cliente_id");

                    b.ToTable("endereco", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Modelos.Endereco", b =>
                {
                    b.HasOne("WebApplication1.Modelos.Cliente", null)
                        .WithMany("enderecos")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("fk_endereco_cliente_cliente_id");
                });

            modelBuilder.Entity("WebApplication1.Modelos.Cliente", b =>
                {
                    b.Navigation("enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
