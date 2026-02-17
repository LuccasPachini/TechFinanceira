using System.Threading.Tasks;
using TechFinanceira.Application.DTOs;

namespace TechFinanceira.Application.Interfaces
{
    // Interface: O contrato que define O QUE o serviço faz
    public interface ITransferenciaService
    {
        Task RealizarTransferenciaAsync(TransferenciaDto dto);
    }
}