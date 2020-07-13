using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core
{
    [NoValidationRequired]
    public class OrderedPair<N, T>
    {
        public N FirstValue { get; set; }
        public T SecondValue { get; set; }

        public OrderedPair(N firstValue, T secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        public OrderedPair() { }
       
    }

}