using Xunit;
using FluentAssertions;
using TechFinanceira.Domain;

namespace TechFinanceira.Tests
{
    public class ContaTests
    {
        [Fact]
        public void Debitar_DeveDiminuirSaldo_QuandoSaldoForSuficiente()
        {
            var conta = new Conta("João", 100); 

            conta.Debitar(40);
            
            conta.Saldo.Should().Be(60); 
        }

        [Fact]
        public void Debitar_DeveLancarErro_QuandoSaldoInsuficiente()
        {
            // ARRANGE
            var conta = new Conta("12345", 50);

            // ACT
            Action act = () => conta.Debitar(100);

            // ASSERT
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Saldo insuficiente."); 
        }
    }
}
