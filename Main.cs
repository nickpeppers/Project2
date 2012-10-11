using System;
using System.Threading;

namespace Project2
{
	class MainClass
	{
		int [,]ArrayA = new int[,] {{1,1},{2,2},{3,3},{4,4}};
		int [,]ArrayB = new int[,] {{5,4,3,2},{6,7,8,9}};
		int [,]ArrayC;

		public class pThread
		{
			// Called when the thread is started.
			public void ThreadWork()
			{
				while (!_StopThread)
				{

				}
			}
			public void RequestStop()
			{
				_StopThread = true;
			}

			private volatile bool _StopThread;
		}


		public static void Main (string[] args)
		{

			while (true)
			{
				pThread  ThreadMatrix = new pThread();
				Thread workerThread = new Thread(ThreadMatrix.ThreadWork);

				// Starts thread
				workerThread.Start();

				// Loops until thread activates.
				while (!workerThread.IsAlive);
				
				// Put the main thread to sleep for 1 millisecond to
				// allow thread to do some work:
				Thread.Sleep(1);
				
				// Request the thread stop itself:
				ThreadMatrix.RequestStop();
				
				// Join method blocks the current thread until the object's thread terminates
				workerThread.Join();
			}
		}
	}
}
