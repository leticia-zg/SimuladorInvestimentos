namespace SimuladorInvestimentos.Core.Models;

using System.ComponentModel.DataAnnotations;

public class Investimento
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor inicial deve ser maior que zero.")]
    public decimal ValorInicial { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O prazo deve ser de no mínimo 1 mês.")]
    public int PrazoMeses { get; set; }

    [Range(0, 1, ErrorMessage = "A taxa de juros deve estar entre 0 e 1.")]
    public double TaxaJurosMensal { get; set; }
}
