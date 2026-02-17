using System;

namespace TechFinanceira.Application.DTOs
{
    // DTO: Objeto simples para transportar dados da API para o Serviço
    public record TransferenciaDto(Guid IdContaOrigem, Guid IdContaDestino, decimal Valor);
}