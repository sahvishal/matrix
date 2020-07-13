﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.HealthPlanReportsService
{
    public interface IIntervalWorkThread
    {
        void Start();
        void Stop();
        void Trigger();
    }
}
