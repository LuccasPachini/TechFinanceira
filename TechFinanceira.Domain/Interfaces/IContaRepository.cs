using System;
using System.Threading.Tasks;

namespace TechFinanceira.Domain.Interfaces
{
    public interface IContaRepository
    {
        // Precisamos buscar uma conta pelo ID para poder debitar/creditar
        // Retorna a Entidade 'Conta' que criamos antes
        Task<Conta> ObterPorIdAsync(Guid id);

        // Precisamos salvar uma conta nova (quando criar cadastro)
        Task AdicionarAsync(Conta conta);

        // Precisamos salvar as mudanças de saldo (depois de um débito/crédito)
        Task AtualizarAsync(Conta conta);
    }
}