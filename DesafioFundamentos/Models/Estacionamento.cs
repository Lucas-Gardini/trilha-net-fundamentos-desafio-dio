namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private static string GetPlaca()
        {
            return Console.ReadLine()?.ToUpper();
        }

        private bool VeiculoCadastrado(string placa)
        {
            return veiculos.Any(v => v == placa);
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = GetPlaca();

            if (this.VeiculoCadastrado(placa))
            {
                Console.WriteLine("Veículo já estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine("Veículo estacionado.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = GetPlaca();

            if (this.VeiculoCadastrado(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                bool inputValido = int.TryParse(Console.ReadLine(), out int horas);

                if (!inputValido ||  horas == 0)
                {
                    Console.WriteLine("Valor inválido. Veículo não removido.");
                    return;
                }

                decimal valorTotal = this.precoInicial + this.precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count != 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.ToString());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
