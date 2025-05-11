using SimuladorInvestimentos.Core.Models;
using SimuladorInvestimentos.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SimuladorInvestimentos.Core.Services
{
    public class InvestimentoService
    {
        private readonly AppDbContext _context;

        public InvestimentoService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Investimento> ObterTodos()
        {
            // Retorna todos os investimentos do banco de dados
            return _context.Investimentos.ToList();
        }

        public Investimento Criar(Investimento investimento)
        {
            Console.WriteLine($"Criando investimento: Nome={investimento.Nome}, ValorInicial={investimento.ValorInicial}, PrazoMeses={investimento.PrazoMeses}, TaxaJurosMensal={investimento.TaxaJurosMensal}");
            _context.Investimentos.Add(investimento);
            _context.SaveChanges();
            return investimento;
        }


        public Investimento ObterPorId(int id)
        {
            // Busca um investimento pelo ID
            return _context.Investimentos.Find(id);
        }

        public bool Atualizar(int id, Investimento investimentoAtualizado)
        {
            var investimento = ObterPorId(id);
            if (investimento == null) return false;

            // Atualiza os campos do investimento
            investimento.Nome = investimentoAtualizado.Nome;
            investimento.ValorInicial = investimentoAtualizado.ValorInicial;
            investimento.PrazoMeses = investimentoAtualizado.PrazoMeses;
            investimento.TaxaJurosMensal = investimentoAtualizado.TaxaJurosMensal;

            _context.Investimentos.Update(investimento);
            _context.SaveChanges();
            return true;
        }

        public bool Remover(int id)
        {
            var investimento = ObterPorId(id);
            if (investimento == null) return false;

            // Remove o investimento do banco de dados
            _context.Investimentos.Remove(investimento);
            _context.SaveChanges();
            return true;
        }
    }
}
