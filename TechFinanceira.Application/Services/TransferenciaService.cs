using System;
using System.Threading.Tasks;
using TechFinanceira.Application.DTOs;
using TechFinanceira.Application.Interfaces;
using TechFinanceira.Domain.Interfaces; // Importante: Referência ao Domínio

namespace TechFinanceira.Application.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly IContaRepository _contaRepository;

        // Injeção de Dependência via Construtor
        public TransferenciaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task RealizarTransferenciaAsync(TransferenciaDto dto)
        {
            // 1. Buscar as contas
            var contaOrigem = await _contaRepository.ObterPorIdAsync(dto.IdContaOrigem);
            var contaDestino = await _contaRepository.ObterPorIdAsync(dto.IdContaDestino);

            // 2. Validar existência
            if (contaOrigem == null) 
                throw new ArgumentException("Conta de origem não encontrada.");
            
            if (contaDestino == null) 
                throw new ArgumentException("Conta de destino não encontrada.");

            // 3. Executar Regra de Negócio (Domínio)
            contaOrigem.Debitar(dto.Valor);
            contaDestino.Creditar(dto.Valor);

            // 4. Persistir alterações
            await _contaRepository.AtualizarAsync(contaOrigem);
            await _contaRepository.AtualizarAsync(contaDestino);
        }
    }
}