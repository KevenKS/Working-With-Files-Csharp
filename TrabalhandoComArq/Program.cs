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

            // Exemplo Directory e DirectoyInfo = Operações com pastas(create, enumerate, get files, entre outros)
            // Directory = Membros statics
            // DirectoryInfo = Membros de instancia

            string caminho = @"c:\temp\myfolder";
            try
            {
                // Listar as pastas a partir de um diretorio informado
                var folders = Directory.EnumerateDirectories(caminho, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS:");
                foreach (string s in folders)
                {
                    Console.WriteLine(s);
                }
                // Listar os arquivos a partir de um diretorio informado
                var files = Directory.EnumerateFiles(caminho, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES:");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
                // criar um diretorio
                Directory.CreateDirectory(@"c:\temp\myfolder\newfolder");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }

            // Exemplo classe path = Realiza operações com strings que contém info/caminhos de arq ou diretorios

            string patth = @"c:\temp\myfolder\file1.txt";

            // Caracter de separação
            Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
            // Caracter para separar path/pastas diferentes. Ex: Quando voce define a var path do windows, utiliza o pathseparator para separar as pastas;
            Console.WriteLine("PathSeparator: " + Path.PathSeparator);
            // porção da string apenas com o caminho das pastas. Retirando o nome do arq.
            Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(patth));
            // Pegar o nome do arq
            Console.WriteLine("GetFileName: " + Path.GetFileName(patth));
            // Extensão do arq
            Console.WriteLine("GetExtension: " + Path.GetExtension(patth));
            // Nome do arq sem extesão
            Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(patth));
            // O caminho completo
            Console.WriteLine("GetFullPath: " + Path.GetFullPath(patth));
            // Pasta temporaria do sistema
            Console.WriteLine("GetTempPath: " + Path.GetTempPath());
        }
    }
}
