using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace atividadeArray
{
    internal class Program
    {
        static int[] array;

        static int maiorValor, menorValor;
        static double soma, divisao;

        static void Main(string[] args)
        {
            CriarArray();

            while (true)
            {
                string opcaoEscolhida = Menu();
                Console.WriteLine();

                if (opcaoEscolhida == "1")
                    EncontraMaiorValor();

                else if (opcaoEscolhida == "2")
                    EncontraMenorValor();

                else if (opcaoEscolhida == "3")
                    FazMediaAritmetica();

                else if (opcaoEscolhida == "4")
                    EncontraTresMaioresValores();

                else if (opcaoEscolhida == "5")
                    EncontraValoresNegativos();

                else if (opcaoEscolhida == "6")
                    RemoverItemSequencia();

                else if (opcaoEscolhida == "7")
                    CriarArray();

                else if (opcaoEscolhida == "S" || opcaoEscolhida == "s")
                    break;
            }

        }

        private static void RemoverItemSequencia()
        {
            Console.Write("Qual número deseja remover da sequência? ");

            int numeroParaRemover = Convert.ToInt32(Console.ReadLine());

            int quantidadeNumerosParaRemover = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == numeroParaRemover)
                    quantidadeNumerosParaRemover++;
            }

            int[] novaArray = new int[array.Length - quantidadeNumerosParaRemover];
            
            int j = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != numeroParaRemover)
                {
                    novaArray[j] = array[i];
                    j++;
                }
            }

            Console.WriteLine($"Sua nova sequência de números é: {String.Join(", ", novaArray)}.");
            Console.ReadKey();
        }

        private static void EncontraValoresNegativos()
        {
            Array.Reverse(array);

            int quantidadeNumerosNegativos = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    quantidadeNumerosNegativos++;
            }

            int[] arrayValoresNegativos = new int[quantidadeNumerosNegativos];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    arrayValoresNegativos[i] = array[i];
                }
            }

            Console.WriteLine($"Os valores negativos dessa sequência são: {string.Join(", ", arrayValoresNegativos)}.");
            Console.ReadKey();
        }

        private static void EncontraTresMaioresValores()
        {
            int[] arrayMaioresValores = new int[3];
            Array.Sort(array);
            Array.Reverse(array);

            for (int i = 0; i < arrayMaioresValores.Length; i++)
            {
                arrayMaioresValores[i] = array[i];
            }

            Console.WriteLine($"Os maiores valores dessa array são: {string.Join(", ", arrayMaioresValores)}.");
            Console.ReadKey();
        }

        private static void FazMediaAritmetica()
        {
            for (int i = 0; i < array.Length; i++)
            {
                soma += array[i];
                divisao = soma / array.Length; 
            }

            Console.WriteLine($"A média aritmética dessa sequência é: {divisao}");
            Console.ReadKey();
        }

        private static void EncontraMenorValor()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < menorValor)
                    menorValor = array[i];
            }
            Console.WriteLine($"O menor valor é: {menorValor}.");
            Console.ReadKey();
        }

        private static void EncontraMaiorValor()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maiorValor)
                    maiorValor = array[i];
            }

            Console.WriteLine($"O maior valor é: {maiorValor}.");
            Console.ReadKey();
        }

        private static int[] CriarArray()
        {
            Console.WriteLine("Atividade Arrays, funções e programação estruturada.");
            Console.WriteLine("\nDigite 10 números para serem analisados, como [-5 3 4 5 9 6 10 -2 11 1]: ");

            string inputArray = Console.ReadLine();

            string[] stringArray = inputArray.Split(' ');
            
            array = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                array[i] = Convert.ToInt32(stringArray[i]);
            }

            return array;
            
        }

        private static string Menu()
        {
            Console.Clear();

            Console.Write($"\nArray criado: {String.Join(", ", array)}.");
               
            Console.WriteLine();
            Console.WriteLine("\nEscolha dentre as opções abaixo: ");
            Console.WriteLine("[1] Encontrar o maior valor.");
            Console.WriteLine("[2] Encontrar o menor valor.");
            Console.WriteLine("[3] Fazer a Média Aritmetica. ");
            Console.WriteLine("[4] Encontrar os 3 maiores valores.");
            Console.WriteLine("[5] Encontrar os valores negativos.");
            Console.WriteLine("[6] Remover um item da sequência.");
            Console.WriteLine("[7] Mudar a sequência.");
            Console.WriteLine("[S] Para sair da aplicação.");

            string opcaoEscolhida = Console.ReadLine();
            
            return opcaoEscolhida;
        }
    }
}