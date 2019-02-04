using log4net;
using PostSharp.Aspects;
using PostSharp.Aspects.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PRS.Core.Aspects.Exception
{
    [Serializable]
    public class ExceptionAspect : OnExceptionAspect
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(ExceptionAspect));
        
        //public override void OnEntry(MethodExecutionArgs args)
        //{
        //    log.Info(ShowParameters);
        //}
        public override void OnException(MethodExecutionArgs args)
        {
            log.Error("hata test", args.Exception);
            args.FlowBehavior = FlowBehavior.ThrowException;
        }
        protected override void SetAspectConfiguration(AspectConfiguration aspectConfiguration, MethodBase targetMethod)
        {
            aspectConfiguration.AspectPriority = 1;
            base.SetAspectConfiguration(aspectConfiguration, targetMethod);
        }
    }
}
