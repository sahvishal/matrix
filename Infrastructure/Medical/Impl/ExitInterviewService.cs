using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ExitInterviewService : IExitInterviewService
    {
        private readonly IExitInterviewQuestionRepository _exitInterviewQuestionRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IExitInterviewAnswerRepository _exitInterviewAnswerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        private static readonly List<long> GiftCertificateQuestions = new List<long> { 4 };

        public ExitInterviewService(IExitInterviewQuestionRepository exitInterviewQuestionRepository, IEventCustomerRepository eventCustomerRepository, IExitInterviewAnswerRepository exitInterviewAnswerRepository,
            ICorporateAccountRepository corporateAccountRepository)
        {
            _exitInterviewQuestionRepository = exitInterviewQuestionRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _exitInterviewAnswerRepository = exitInterviewAnswerRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public IEnumerable<ExitInterviewQuestionAnswerEditModel> GetQuestions(long eventCustomerId)
        {
            var list = new List<ExitInterviewQuestionAnswerEditModel>();

            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            if (eventCustomer == null) return list;

            var questions = _exitInterviewQuestionRepository.GetAllQuestions();

            var answers = _exitInterviewAnswerRepository.GetByEventCustomerId(eventCustomerId);

            var account = _corporateAccountRepository.GetbyEventId(eventCustomer.EventId);

            if (account == null || !account.AttachGiftCard)
            {
                questions = questions.Where(q => !GiftCertificateQuestions.Contains(q.Id));
            }

            foreach (var question in questions)
            {
                var model = new ExitInterviewQuestionAnswerEditModel
                {
                    QuestionId = question.Id,
                    Question = question.Question,
                    Index = question.Index
                };

                var answer = answers.FirstOrDefault(x => x.QuestionId == question.Id);

                if (answer != null && !string.IsNullOrWhiteSpace(answer.Answer))
                {
                    model.Answer = answer.Answer.ToLower() == Boolean.TrueString.ToLower();
                }

                list.Add(model);
            }

            return list;
        }

        public bool Save(ExitInterviewAnswerModel model, long orgRoleUserId)
        {
            var evenntCustomer = _eventCustomerRepository.GetById(model.EventCustomerId);
            if (evenntCustomer == null) return false;

            if (!model.Answers.IsNullOrEmpty())
            {
                var exitInterviewAnswers = new List<ExitInterviewAnswer>();

                var answerVersion = _exitInterviewAnswerRepository.GetLatestVersion(model.EventCustomerId);

                foreach (var answer in model.Answers)
                {
                    var exitInterviewAnswer = new ExitInterviewAnswer
                    {
                        EventCustomerId = model.EventCustomerId,
                        QuestionId = answer.QuestionId,
                        Answer = answer.Answer.ToString(),
                        Version = answerVersion + 1,
                        IsActive = true,
                        DateCreated = DateTime.Now,
                        CreatedBy = orgRoleUserId
                    };

                    exitInterviewAnswers.Add(exitInterviewAnswer);
                }

                _exitInterviewAnswerRepository.SaveAnswer(exitInterviewAnswers);
            }

            return true;
        }
    }
}
