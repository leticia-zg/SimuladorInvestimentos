namespace SimuladorInvestimentos.Core.Models;

public class Investimento
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Valor { get; set; }
    public int PrazoMeses { get; set; }
    public double TaxaJurosAnual { get; set; }
}

