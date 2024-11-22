﻿// <auto-generated />
using EnergyAwareness.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EnergyAwareness.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnergyAwareness.Models.Consulta", b =>
                {
                    b.Property<int>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsulta"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NmRegiao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("NrHorasUtilizadas")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("NrTaxa")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("IdConsulta");

                    b.ToTable("T_EA_CONSULTAS", (string)null);
                });

            modelBuilder.Entity("EnergyAwareness.Models.Eletronico", b =>
                {
                    b.Property<int>("IdEletronico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEletronico"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NmEletronico")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NmMarca")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdEletronico");

                    b.ToTable("T_EA_ELETRONICOS", (string)null);
                });

            modelBuilder.Entity("EnergyAwareness.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NmUsuario")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<long>("NrCpf")
                        .HasColumnType("NUMBER(19)");

                    b.Property<int>("NrSenha")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("IdUsuario");

                    b.ToTable("T_EA_USUARIO", (string)null);
                });

            modelBuilder.Entity("EnergyAwareness.Models.Valor", b =>
                {
                    b.Property<int>("NrPotencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NrPotencia"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("NrEletronicos")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("NrPotencia");

                    b.ToTable("T_EA_VALORES", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
