namespace EnergyAwareness.Models
{
    public class Consulta
    {
        public int IdConsultas { get; set; }   // Chave primária
        public int NrHorasUtilizadas { get; set; } // Número de horas de uso
        public decimal NrTaxa { get; set; }        // Taxa de consumo
        public string NmRegiao { get; set; }      // Região onde foi feita a consulta
        public int IdUsuario { get; set; }        // Relacionamento com Usuario (Chave estrangeira)
    }
}