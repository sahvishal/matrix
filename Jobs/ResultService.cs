using System;
using System.Threading;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;

namespace Falcon.Jobs
{
    public partial class ResultService : ConsoleServiceBase
    {
        private readonly TimeSpan _interval = new TimeSpan(0, 0, 1, 0);
        private readonly IntervalWorkThread _pollThread;
        private readonly Timer _timer;
        private ILogger _logger;

        public ResultService(IResultArchivePollingAgent resultArchivePollingAgent, ILogManager logManager)
        {
            InitializeComponent();
            _pollThread = new IntervalWorkThread(resultArchivePollingAgent.PollforUploadCompleteResultArchives);
            _timer = new Timer(x => _pollThread.Trigger(), new object(), new TimeSpan(0), _interval);
            _logger = logManager.GetLogger<ResultService>();
        }

        public override void Start(string[] args)
        {
            _logger.Info("Starting result service...");
            _pollThread.Start();
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping result service...");
            _timer.Change(new TimeSpan(-1), new TimeSpan(-1));
            _pollThread.Stop();
        }

    }
}
