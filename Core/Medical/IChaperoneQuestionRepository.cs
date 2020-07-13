﻿using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IChaperoneQuestionRepository
    {
        IEnumerable<ChaperoneQuestion> GetAllQuestions();
    }
}