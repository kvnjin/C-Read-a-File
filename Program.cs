using System;
using System.IO;
using System.Text;
internal class Program
{

    private async static Task Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(ThreadProc);
        
        for (int i = 0; i < 2; i++)
        {
            await ReadFile(i);
        }
        
        Console.WriteLine("Continuation du traitement");
    }
    async static void ThreadProc(Object stateInfo) 
    {
        for (int i = 0; i < 2; i++)
        {
            await CreateFile(i);

        }
    }

    private async static Task ReadFile(int a){
    Console.WriteLine("Début de la lecture du fichier");

    using (StreamReader sr = new StreamReader(@$"Test{a}.txt"))
    {
        string line;

        while ((line = await sr.ReadLineAsync()) != null)
        {
            if (line.Contains("4"))
            {
                Console.WriteLine(line); 
            }
        }
        Console.WriteLine("Fin du fichier");
    }

    Console.WriteLine("Fin de la lecture du fichier");
}

    private async static Task CreateFile(int a){
        Console.WriteLine("Début de la création et écriture dans un fichier");
        
        using (FileStream fs = File.Create(@$"Test{a}.txt"))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < 990; i++){
                await sw.WriteLineAsync($"Fichier{a} Line {i}");
            }
        }
        Console.WriteLine("Fin de l'écriture dans le fichier");

    
    }
    
}
