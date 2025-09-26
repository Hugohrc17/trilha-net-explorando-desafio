namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a suite foi cadastrada antes de verificar a capacidade
            if (Suite == null)
            {
                throw new Exception("Suite não cadastrada. Cadastre uma suite antes de adicionar hóspedes.");
            }

            // Verificar se a capacidade é maior ou igual ao número de hóspedes
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Retornar uma exception caso a capacidade seja menor que o número de hóspedes
                throw new Exception($"A suíte {Suite.TipoSuite} tem capacidade para {Suite.Capacidade} hóspedes, mas foram recebidos {hospedes.Count} hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Verificar se a suite foi cadastrada
            if (Suite == null)
            {
                throw new Exception("Suite não cadastrada. Não é possível calcular o valor da diária.");
            }

            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.90m; // Aplica 10% de desconto (valor * 0.90)
            }

            return valor;
        }
    }
}