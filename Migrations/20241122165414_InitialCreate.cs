using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyAwareness.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_EA_CONSULTAS",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NrHorasUtilizadas = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NrTaxa = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NmRegiao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EA_CONSULTAS", x => x.IdConsulta);
                });

            migrationBuilder.CreateTable(
                name: "T_EA_ELETRONICOS",
                columns: table => new
                {
                    IdEletronico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmEletronico = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NmMarca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EA_ELETRONICOS", x => x.IdEletronico);
                });

            migrationBuilder.CreateTable(
                name: "T_EA_USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NrCpf = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DsEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NmUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NrSenha = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EA_USUARIO", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "T_EA_VALORES",
                columns: table => new
                {
                    NrPotencia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NrEletronicos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EA_VALORES", x => x.NrPotencia);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_EA_CONSULTAS");

            migrationBuilder.DropTable(
                name: "T_EA_ELETRONICOS");

            migrationBuilder.DropTable(
                name: "T_EA_USUARIO");

            migrationBuilder.DropTable(
                name: "T_EA_VALORES");
        }
    }
}
