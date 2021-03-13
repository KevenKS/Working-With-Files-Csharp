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
                foreach (string line1 in linesArq)
                {
                    Console.WriteLine(line1);
                }
            }
            catch (IOException e)
            {
                throw new IOException("Erro!! " + e.Message);
            }

            // Exemplo FileStream & StreamReader

            string path = @"c:\temp\file1.txt";
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(path, FileMode.Open); // File.OpenRead(path);
                sr = new StreamReader(fs);
                string line2 = sr.ReadLine();
                Console.WriteLine(line2);
            }
            catch (IOException e)
            {
                throw new IOException("Erro!! " + e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }

            // Exemplo sintaxe simplificada, usando apenas StreamReader

            string path1 = @"c:\temp\file1.txt";
            StreamReader ssr = null;
            try
            {
                ssr = File.OpenText(path1);
                while (!ssr.EndOfStream)
                {
                    string line3 = ssr.ReadLine();
                    Console.WriteLine(line3);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (ssr != null) ssr.Close();
            }

            // Exemplo Bloco using = Sintaxe simplificada que garante que os obj IDisposable serão fechado automaticamente.

            string pathh = @"c:\temp\file1.txt";
            try
            {
                using (StreamReader srr = File.OpenText(pathh))
                {
                    while (!srr.EndOfStream)
                    {
                        string line4 = srr.ReadLine();
                        Console.WriteLine(line4);
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException("Erro!! " + e.Message);
            }

            // Exemplo StreamWriter = É uma stream capaz de escrever caracteres a partir de uma stream binária(ex: FileStream); Suporta dados no formato texto;

            string sourcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";
            try
            {
                string[] lines5 = File.ReadAllLines(sourcePath);
                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line5 in lines5)
                    {
                        sw.WriteLine(line5.ToUpper());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }

        }
    }
}
