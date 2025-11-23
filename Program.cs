using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n=== MENU DE PROGRAMAS ===\n");
            Console.WriteLine("1. Soma dos Elementos de um Vetor");
            Console.WriteLine("2. Encontrar o Maior e o Menor Valor");
            Console.WriteLine("3. Ordenação de Vetor");
            Console.WriteLine("4. Cálculo da Média e Desvio Padrão");
            Console.WriteLine("5. Rotacionar os Elementos de um Vetor");
            Console.WriteLine("6. Intercalar Dois Vetores");
            Console.WriteLine("7. Remover Elementos Duplicados de um Vetor");
            Console.WriteLine("8. Contar Elementos de um Vetor");
            Console.WriteLine("9. Vetor Palíndromo");
            Console.WriteLine("10. Produto Escalar de Dois Vetores");
            Console.WriteLine("0. Sair\n");

            Console.Write("Escolha uma opção: ");
            string? opcaoInput = Console.ReadLine();
            Console.Clear();

            switch (opcaoInput)
            {
                case "1": Program1.Run(); break;
                case "2": Program2.Run(); break;
                case "3": Program3.Run(); break;
                case "4": Program4.Run(); break;
                case "5": Program5.Run(); break;
                case "6": Program6.Run(); break;
                case "7": Program7.Run(); break;
                case "8": Program8.Run(); break;
                case "9": Program9.Run(); break;
                case "10": Program10.Run(); break;
                case "0": continuar = false; Console.WriteLine("Saindo do programa..."); break;
                default: Console.WriteLine("Opção inválida. Tente novamente."); break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPressione Enter para voltar ao menu...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}

static class Utils
{
    public static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Entrada inválida. Tente novamente: ");
        }
        return value;
    }

    public static int[] ReadIntArrayFromUser()
    {
        int tamanho = ReadInt("Digite o tamanho do vetor: ");
        int[] vetor = new int[tamanho];
        for (int i = 0; i < tamanho; i++)
        {
            vetor[i] = ReadInt($"Elemento [{i}]: ");
        }
        return vetor;
    }
}

class Program1
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        int soma = 0;
        foreach (var v in vetor) soma += v;
        Console.WriteLine($"A soma dos elementos do vetor é: {soma}");
    }
}

class Program2
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        if (vetor.Length == 0)
        {
            Console.WriteLine("Vetor vazio.");
            return;
        }
        int maior = vetor[0], menor = vetor[0];
        foreach (var v in vetor)
        {
            if (v > maior) maior = v;
            if (v < menor) menor = v;
        }
        Console.WriteLine($"Maior valor: {maior}, Menor valor: {menor}");
    }
}

class Program3
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        // Bubble sort simples
        for (int i = 0; i < vetor.Length - 1; i++)
            for (int j = 0; j < vetor.Length - 1 - i; j++)
                if (vetor[j] > vetor[j + 1])
                {
                    int tmp = vetor[j];
                    vetor[j] = vetor[j + 1];
                    vetor[j + 1] = tmp;
                }
        Console.WriteLine("Vetor ordenado: " + string.Join(", ", vetor));
    }
}

class Program4
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        if (vetor.Length == 0)
        {
            Console.WriteLine("Vetor vazio.");
            return;
        }
        double soma = 0;
        foreach (var v in vetor) soma += v;
        double media = soma / vetor.Length;
        double somaQuadrados = 0;
        foreach (var v in vetor) somaQuadrados += Math.Pow(v - media, 2);
        double desvio = Math.Sqrt(somaQuadrados / vetor.Length);
        Console.WriteLine($"Média: {media:F2}, Desvio Padrão: {desvio:F2}");
    }
}

class Program5
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        if (vetor.Length == 0)
        {
            Console.WriteLine("Vetor vazio.");
            return;
        }
        int n = Utils.ReadInt("Digite o número de posições para rotacionar (direita): ");
        n = ((n % vetor.Length) + vetor.Length) % vetor.Length;
        int[] res = new int[vetor.Length];
        for (int i = 0; i < vetor.Length; i++)
            res[(i + n) % vetor.Length] = vetor[i];
        Console.WriteLine("Vetor rotacionado: " + string.Join(", ", res));
    }
}

class Program6
{
    public static void Run()
    {
        Console.WriteLine("Vetor 1:");
        int[] v1 = Utils.ReadIntArrayFromUser();
        Console.WriteLine("Vetor 2:");
        int[] v2 = Utils.ReadIntArrayFromUser();
        List<int> inter = new List<int>();
        int i = 0, j = 0;
        while (i < v1.Length || j < v2.Length)
        {
            if (i < v1.Length) inter.Add(v1[i++]);
            if (j < v2.Length) inter.Add(v2[j++]);
        }
        Console.WriteLine("Vetor intercalado: " + string.Join(", ", inter));
    }
}

class Program7
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        HashSet<int> seen = new HashSet<int>();
        List<int> res = new List<int>();
        foreach (var v in vetor)
            if (seen.Add(v)) res.Add(v);
        Console.WriteLine("Vetor sem duplicados: " + string.Join(", ", res));
    }
}

class Program8
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        int x = Utils.ReadInt("Digite o número a ser contado: ");
        int count = 0;
        foreach (var v in vetor) if (v == x) count++;
        Console.WriteLine($"O número {x} aparece {count} vezes no vetor.");
    }
}

class Program9
{
    public static void Run()
    {
        int[] vetor = Utils.ReadIntArrayFromUser();
        bool pal = true;
        for (int i = 0; i < vetor.Length / 2; i++)
            if (vetor[i] != vetor[vetor.Length - 1 - i]) { pal = false; break; }
        Console.WriteLine($"O vetor é palíndromo? {pal}");
    }
}

class Program10
{
    public static void Run()
    {
        Console.WriteLine("Vetor 1:");
        int[] v1 = Utils.ReadIntArrayFromUser();
        Console.WriteLine("Vetor 2 (deve ter o mesmo tamanho):");
        int[] v2 = Utils.ReadIntArrayFromUser();
        if (v1.Length != v2.Length)
        {
            Console.WriteLine("Vetores com tamanhos diferentes. Não é possível calcular o produto escalar.");
            return;
        }
        long produto = 0;
        for (int i = 0; i < v1.Length; i++) produto += (long)v1[i] * v2[i];
        Console.WriteLine($"O produto escalar dos vetores é: {produto}");
    }
}