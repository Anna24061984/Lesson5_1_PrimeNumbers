namespace AnnLesson_5_1
{
    internal class Program
    {        
        static void Main(string[] args)
        {            
            Console.Write($"Введите порядковый номер простого числа: ");
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(GetPrimeNumbers(n));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так...");
            }
                        
            Console.ReadLine();
        }                

        /// <summary>
        /// Получение массива простых чисел
        /// </summary>        
        public static int GetPrimeNumbers(int n)
        {            
            if (n == 1)                
                return 2;
            int[] primeNumbers = new int[n];
            primeNumbers[0] = 2;            
            for (int i = 1; i < n; i++)
            {
                primeNumbers[i] = GetNextPrimeNumber(primeNumbers, i);
            }
            return primeNumbers[n-1];
        }

        public static int GetNextPrimeNumber(int[] primeNumbers, int count)
        { 
            int nextNumber = primeNumbers[count - 1] + 1;            
            while (true)
            {
                bool nextNumberIsPrime = true;                  //предположим, что следующее число простое
                for (int i = 0; i < count; i++)
                {
                    if (nextNumber % primeNumbers[i] == 0)          //если оно делится на одно из простых, ранее найденных
                    {
                        nextNumberIsPrime = false;                  //то оно не простое
                        nextNumber++;                               //и берем следующее число
                        break;
                    }
                }
                if (nextNumberIsPrime)                          //если мы перебрали все ранее найденные простые числа и ни на одно не поделилось
                    return nextNumber;                          //то это числе - следующее простое
            }
        }        
    }
}

