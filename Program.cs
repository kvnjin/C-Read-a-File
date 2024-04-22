using System;
using System.IO;
using System.Text;
internal class Program
{

    private async static Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        await CreateFile();        
        await ReadFile();
        Console.WriteLine("Continuation du traitement");
    }

    private async static Task ReadFile(){
    Console.WriteLine("Début de la lecture du fichier");

    using (StreamReader sr = new StreamReader(@"Test.txt"))
    {
        string line;
        
        while ((line = await sr.ReadLineAsync()) != null)
        {
            if (line.Contains("2"))
            {
                Console.WriteLine(line); 
            }
        }
        Console.WriteLine("Fin du fichier");
    }

    Console.WriteLine("Fin de la lecture du fichier");
}

    private async static Task CreateFile(){
        Console.WriteLine("Début de la création et écriture dans un fichier");
        
        using (FileStream fs = File.Create(@"Test.txt"))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < 99000; i++){
                await sw.WriteLineAsync($"Line {i}");
            }
        }
        Console.WriteLine("Fin de l'écriture dans le fichier");

    
    }
    
}
