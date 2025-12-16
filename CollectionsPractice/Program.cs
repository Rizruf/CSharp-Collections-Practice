namespace CollectionsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListTasks myWorker = new ListTasks();

            myWorker.ListMerge();

            Console.WriteLine("\nНажми Enter, чтобы закрыть...");
            Console.ReadLine();
        }
    }
}
