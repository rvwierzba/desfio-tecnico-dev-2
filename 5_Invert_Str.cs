using System;

public class InverterString
{

/*
  
5) Escreva um programa que inverta os caracteres de um string. 

IMPORTANTE: 
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código; 
b) Evite usar funções prontas, como, por exemplo, reverse; 
  
  */
  
    public static void Main(string[] args)
    {
        Console.Write("Digite uma string: ");
        string texto = Console.ReadLine();

        char[] caracteres = texto.ToCharArray();
        int inicio = 0;
        int fim = caracteres.Length - 1;

        while (inicio < fim)
        {
            char temp = caracteres[inicio];
            caracteres[inicio] = caracteres[fim];
            caracteres[fim] = temp;
            inicio++;
            fim--;
        }

        string textoInvertido = new string(caracteres);
        Console.WriteLine($"String invertida: {textoInvertido}");
    }
}
