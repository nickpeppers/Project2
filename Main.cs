using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project2
{
	static class Neo
	{
        // 2x4 matrix
		static int [,]ArrayA = new int[,] {{1,1},{2,2},{3,3},{4,4}};
        
        // 4x2 matrix
		static int [,]ArrayB = new int[,] {{5,4,3,2},{6,7,8,9}};

        // 4x4 end resulting matrix
		static int [,]ArrayC = new int[,] {{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};

        public static void Main(string[] args)
        {
            // creates list of pthreads to run separately
            var pthread = new List<Task>();

            for (int i = 0; i < ArrayA.GetLength(0); i++)
            {
                for (int j = 0; j < ArrayB.GetLength(1); j++)
                {
                    int x = i, y = j;
                    pthread.Add(Task.Factory.StartNew(() => EnterTheMatrix(x, y)));
                }
            }

            //Main thread waits until all threads complete and joins them
            Task.WaitAll(pthread.ToArray());

            //Shows results of thread multiplication
            for (int i = 0; i < ArrayC.GetLength(0); i++)
            {
                for (int j = 0; j < ArrayC.GetLength(1); j++)
                {
                    Console.Write(ArrayC[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        // Multiplies the RowxColumn and assigns it in ArrayC
        private static void EnterTheMatrix(int i, int j)
        {
            for (int k = 0; k < ArrayB.GetLength(0); k++)
            {
                ArrayC[i, j] += ArrayA[i, k] * ArrayB[k, j];
            }
        }
	}
}
