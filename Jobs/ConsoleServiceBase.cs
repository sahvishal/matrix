using System.ServiceProcess;

namespace Falcon.Jobs
{
    public class ConsoleServiceBase : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        public virtual void Start(string[] args)
        {
            // Visual Studio's designer support demands this class be instantiable
        }
    }
}