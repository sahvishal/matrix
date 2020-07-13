using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jobs.TermByAbsence
{
    public class IntervalWorkThread : IIntervalWorkThread
    {
        private readonly ManualResetEvent _event;
        private readonly Thread _thread;
        private readonly ThreadStart _worker;
        private bool _isRunning;

        public IntervalWorkThread(ThreadStart worker)
        {
            _worker = worker;

            _thread = new Thread(DoWork);
            _event = new ManualResetEvent(false);
        }

        private void DoWork()
        {
            while (_isRunning)
            {
                _event.WaitOne();
                _event.Reset();
                _worker();
            }
        }

        public void Start()
        {
            _isRunning = true;
            _thread.Start();
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public void Trigger()
        {
            _event.Set();
        }
    }
}
