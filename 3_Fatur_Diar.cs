using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Faturamento
{

  /*

    3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne: 
• O menor valor de faturamento ocorrido em um dia do mês; 
• O maior valor de faturamento ocorrido em um dia do mês; 
• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal. 

IMPORTANTE: 
a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal; 
b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média; 

  
  */
  
    public static void Main(string[] args)
    {
        string jsonString = File.ReadAllText("faturamento.json"); // Crie um arquivo faturamento.json.
        List<FaturamentoDiario> faturamento = JsonSerializer.Deserialize<List<FaturamentoDiario>>(jsonString);

        double menorFaturamento = double.MaxValue;
        double maiorFaturamento = double.MinValue;
        double somaFaturamento = 0;
        int diasComFaturamento = 0;

        foreach (var dia in faturamento)
        {
            if (dia.Valor > 0)
            {
                if (dia.Valor < menorFaturamento)
                {
                    menorFaturamento = dia.Valor;
                }
                if (dia.Valor > maiorFaturamento)
                {
                    maiorFaturamento = dia.Valor;
                }
                somaFaturamento += dia.Valor;
                diasComFaturamento++;
            }
        }

        double mediaMensal = somaFaturamento / diasComFaturamento;
        int diasAcimaDaMedia = 0;

        foreach (var dia in faturamento)
        {
            if (dia.Valor > mediaMensal)
            {
                diasAcimaDaMedia++;
            }
        }

        Console.WriteLine($"Menor faturamento: R${menorFaturamento:F2}");
        Console.WriteLine($"Maior faturamento: R${maiorFaturamento:F2}");
        Console.WriteLine($"Dias acima da média: {diasAcimaDaMedia}");
    }
}

public class FaturamentoDiario
{
    public int Dia { get; set; }
    public double Valor { get; set; }
}
