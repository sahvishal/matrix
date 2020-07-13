using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    public class TestimonialRepository : UniqueItemRepository<Testimonial, TestimonialEntity>, ITestimonialRepository
    {
        private readonly IUniqueItemRepository<File> _fileRepository;

        public TestimonialRepository()
            : this(new TestimonialMapper())
        {
            _fileRepository = new FileRepository();
        }

        public TestimonialRepository(IMapper<Testimonial, TestimonialEntity> mapper)
            : base(mapper)
        {
            _fileRepository = new FileRepository();
        }


        protected override EntityField2 EntityIdField
        {
            get { return TestimonialFields.TestimonialId; }
        }

        public Testimonial SaveTestimonial(Testimonial testimonial)
        {
            using (var transaction = new TransactionScope())
            {
                File file = null;
                if (testimonial.TestimonialVideo != null)
                {
                    file = _fileRepository.Save(testimonial.TestimonialVideo);
                    testimonial.TestimonialVideo.Id = file.Id;
                }
                testimonial = Save(testimonial);
                testimonial.TestimonialVideo = file;
                transaction.Complete();
                return testimonial;
            }
        }

        public Testimonial GetTestimonial(long testimonialId)
        {
            var testimonial = GetById(testimonialId);
            if (testimonial.TestimonialVideo != null && testimonial.TestimonialVideo.Id > 0)
                testimonial.TestimonialVideo = _fileRepository.GetById(testimonial.TestimonialVideo.Id);
            return testimonial;
        }

        public List<Testimonial> GetTestimonials(bool? isAccepted, int pageNumber, int pageSize)
        {
            using(var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                    var testimonialEntities = linqMetaData.Testimonial
                        .Where(t => t.IsAccepted == isAccepted)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize).ToList();
                    if (testimonialEntities.IsNullOrEmpty())
                        throw new ObjectNotFoundInPersistenceException<Testimonial>();
                    return Mapper.MapMultiple(testimonialEntities).ToList();
               
            }
        }

        public int CountTestimonials(bool? isAccepted)
        {
            IPredicateExpression predicateExpression = new PredicateExpression(TestimonialFields.IsAccepted == isAccepted);
            IRelationPredicateBucket bucket = new RelationPredicateBucket(predicateExpression);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return adapter.GetDbCount(new EntityCollection<TestimonialEntity>(), bucket);
            }
        }

        public int CountAcceptedTestimonials(bool? isAccepted, string gender)
        {
            IPredicateExpression predicateExpression = new PredicateExpression(TestimonialFields.IsAccepted == isAccepted);
            IRelationPredicateBucket bucket = new RelationPredicateBucket(predicateExpression);
            bucket.Relations.Add(new EntityRelation(CustomerProfileFields.CustomerId, TestimonialFields.CustomerId,
                                                    RelationType.OneToMany));
            bucket.PredicateExpression.AddWithAnd(new PredicateExpression(CustomerProfileFields.Gender == gender));
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return adapter.GetDbCount(new EntityCollection<TestimonialEntity>(), bucket);
            }
        }

        public List<Testimonial> GetAcceptedTestimonials(bool? isAccepted, string gender, int pageNumber, int pageSize)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var testimonialEntities = linqMetaData.Testimonial
                    .Join(linqMetaData.CustomerProfile, test => test.CustomerId, c => c.CustomerId, (test, c) => new {test, c})
                    .Where(t => t.test.IsAccepted == isAccepted && t.c.Gender == gender)
                    .Select(t => t.test)
                    .Skip((pageNumber - 1)*pageSize)
                    .Take(pageSize).ToList();
                if (testimonialEntities.IsNullOrEmpty())
                    throw new ObjectNotFoundInPersistenceException<Testimonial>();
                return Mapper.MapMultiple(testimonialEntities).ToList();

            }
        }
    }
}
