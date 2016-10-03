namespace SnakeGame
{
    using System;
    using System.Threading;

    public class Timer
    {
        public int Timeout { get; set; }
        public Action Tick { get; set; }
        
        private Thread thread;
        private bool forceStop = false;

        private void Work()
        {
            while(true)
            {
                Thread.Sleep(Timeout);
                Tick();

                if (forceStop)
                    break;
            }
        }
        
        public void Start()
        {
            thread = new Thread(new ThreadStart(Work));
            thread.Start();
        }

        public void Stop()
        {
            forceStop = true;
        }
    }
}
