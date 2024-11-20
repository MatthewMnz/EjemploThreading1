namespace EjemploThreading1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejemplo con Hilos");

            List<int> NumPares = new List<int>();
            List<int> NumImpares = new List<int>();

            Thread parThread = new Thread(() => ProccessNumbers("Pares", NumPares, 0, 20, 2));
            Thread imparThread = new Thread(() => ProccessNumbers("Impares", NumImpares, 1, 19, 2));

            parThread.Start();
            imparThread.Start();

            parThread.Join();
            imparThread.Join();

            Console.WriteLine("Procesamiento Finalizado");
            Console.WriteLine($"Numeros pares procesados: {string.Join(", ", NumPares)}");
            Console.WriteLine($"Numeros impares procesados: {string.Join(", ", NumImpares)}");
        }

        static void ProccessNumbers(string nombreThread, List<int> resultList, int start, int end, int step)
        {
            for (int i = start; i <= end; i += step)
            {
                Console.WriteLine($"{nombreThread} procesando: {i}");
                resultList.Add(i);
                Thread.Sleep(400);
            }
        }
    }
}
