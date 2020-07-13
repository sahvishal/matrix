using System;

namespace Falcon.App.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultImplementationAttribute : Attribute
    {
        public Type Interface { get; set; }
    }
}