using System;

namespace TechFinanceira.Domain
{
    public class Conta
    {
        // Propriedades com "private set"
        // Ninguém de fora pode fazer: conta.Saldo = 1000000;
        public Guid Id { get; private set; }
        public string Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public bool Ativa { get; private set; }

        // Construtor para criar uma conta nova
        // O EF Core precisa de um construtor vazio, mas podemos deixá-lo privado ou protegido se quisermos ser puristas.
        // Para simplificar agora, vamos usar um construtor público que obriga a passar os dados iniciais.
        public Conta(string numero, decimal saldoInicial)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Número da conta é obrigatório.");
            
            if (saldoInicial < 0)
                throw new ArgumentException("Saldo inicial não pode ser negativo.");

            Id = Guid.NewGuid();
            Numero = numero;
            Saldo = saldoInicial;
            Ativa = true;
        }

        // Métodos de Negócio (Onde a regra mora!)
        public void Debitar(decimal valor)
        {
            if (!Ativa)
                throw new InvalidOperationException("Conta inativa não pode realizar operações.");

            if (valor <= 0)
                throw new ArgumentException("Valor do débito deve ser maior que zero.");

            if (Saldo < valor)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;
        }

        public void Creditar(decimal valor)
        {
            if (!Ativa)
                throw new InvalidOperationException("Conta inativa não pode realizar operações.");

            if (valor <= 0)
                throw new ArgumentException("Valor do crédito deve ser maior que zero.");

            Saldo += valor;
        }
    }
}