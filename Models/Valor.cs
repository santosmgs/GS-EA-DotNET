namespace EnergyAwareness.Models
{
    public class Valor
    {
        public int NrPotencia { get; set; }     // Chave primária
        public int NrEletronico { get; set; }   // Relacionamento com Eletronico (Chave estrangeira)
        public int IdUsuario { get; set; }      // Relacionamento com Usuario (Chave estrangeira)
    }
}