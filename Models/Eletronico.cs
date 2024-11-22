namespace EnergyAwareness.Models
{
    public class Eletronico
    {
        public int IdEletronico { get; set; }   // Chave primária
        public string NmEletronico { get; set; } // Nome do eletrônico
        public string NmMarca { get; set; }     // Marca do eletrônico
        public int Potencia { get; set; }       // Potência em watts
        public int HorasDeUso { get; set; }     // Quantidade de horas de uso diário
    }
}