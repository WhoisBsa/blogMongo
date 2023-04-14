namespace exemploMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            Console.WriteLine("Esperando 10s");
            await Task.Delay(10000);
            Console.WriteLine("Esperei 10S");
        }
    }
}