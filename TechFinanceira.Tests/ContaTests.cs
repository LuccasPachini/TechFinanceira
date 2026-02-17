using Xunit;
using FluentAssertions;
using TechFinanceira.Domain;

namespace TechFinanceira.Tests
{
    public class ContaTests
    {
        [Fact] // [Fact] avisa o C# que isso é um teste
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
            // Ajustado para InvalidOperationException para bater com sua classe Conta
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Saldo insuficiente."); 
        }
    }
}