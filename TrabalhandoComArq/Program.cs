using System;
using System.IO;

namespace TrabalhandoComArq
{
    class Program
    {
        static void Main(string[] args)
        {
            // File = membros statics (simples, mas realiza verificação de segurança para cada operação (pesando na performace))
            // FileInfo = Necessario instancia; melhor em perfomarce.

            // criando string com o caminho do arquivo
            string PathOrigem = @"C:\Users\Desktop\file1.txt";
            string PathDestino = @"C:\Users\Desktop\file2.txt";

            try
            {
                // instacia de obj FileInfo passando como parametro o a string contento o caminho do obj
                FileInfo fileInfo = new FileInfo(PathOrigem);
                // usando o obj criado para copiar o arquivo para outro lugar. O novo caminho está na string PathDestino
                fileInfo.CopyTo(PathDestino);
                // criando um vetor para guardar cada linha de texto que está no arq txt. 
                //Usando a classe File (a qual não precisa de instancia) somado com o metodo ReadAllLines (ler todas as linhas do arq); 
                String[] linesArq = File.ReadAllLines(PathOrigem);
                // foreach para ler e printar todas as lines dentro do vetor;
                foreach (string line in linesArq)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                throw new IOException("Erro!! " + e.Message);
            }

        }
    }
}
