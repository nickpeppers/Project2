using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project2
{
	static class MainClass
	{
		static int [,]ArrayA = new int[,] {{1,1},{2,2},{3,3},{4,4}};
		static int [,]ArrayB = new int[,] {{5,4,3,2},{6,7,8,9}};
		static int [,]ArrayC;

		public static void Main (string[] args)
		{

			while (true)
			{
                var tasks = new List<Task<int>>();

                for (int i = 0; i < ArrayA.GetLength(0); i++)
                {
                    for (int j = 0; j < ArrayB.GetLength(1); j++)
                    {
                        tasks.Add(Task.Factory.StartNew(() => CalculateColumn(i, j)));
                    }
                }

                //Block until all tasks complete.
                Task.WaitAll(tasks.ToArray());

                //see results of the task
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine(i + " " + tasks[i].Result);
                }
			}
		}

        private static int CalculateColumn(int i, int j)
        {
            return 0;
            //for (int k = 0; k < ArrayB.GetLength; k++)
            //{
            //    ArrayC[i, j] += ArrayA[i, k] * ArrayB[k, j];
            //}
        }
	}
}
