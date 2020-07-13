using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class TemplateMacro : DomainObjectBase
    {
        public string IdentifierName { get; set; }

        public string CodeString { get; set; }

        public int Sequence { get; set; }
        
        public string IdentifierUiString { get { return GetIdentifierUiString(IdentifierName); } }

        public static string GetIdentifierUiString(string idName)
        {
            return string.Concat("#", idName, "#");
        }

        public string ParameterValue { get; set; }
    }
}