using System;

namespace Falcon.App.Core
{
    public abstract class TypeSafeEnum
    {
        private readonly string _name;
        public string Name { get { return _name; } }

        protected TypeSafeEnum(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            _name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}