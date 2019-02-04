using log4net;
using PostSharp.Aspects;
using PostSharp.Aspects.Configuration;
using PRS.Core.Aspects.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PRS.Core.Aspects.Logging
{
    [Serializable]
    public class LogAspect : OnMethodBoundaryAspect
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(LogAspect));

        public override void OnEntry(MethodExecutionArgs args)
        {
            log.InfoFormat("Entering {0}.{1}.", args.Method.DeclaringType.Name, args.Method.Name);
            log.Debug(DisplayObjectInfo(args));
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            log.DebugFormat("Leaving {0}.{1}. Return value {2}", args.Method.DeclaringType.Name, args.Method.Name, args.ReturnValue);
        }
        static string DisplayObjectInfo(MethodExecutionArgs args)
        {
            StringBuilder sb = new StringBuilder();
            Type type = args.Arguments.GetType();
            sb.Append("Method " + args.Method.Name);
            sb.Append("\r\nArguments:");
            FieldInfo[] fi = type.GetFields();
            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
                {
                    sb.Append("\r\n " + f + " = " + f.GetValue(args.Arguments));
                }
            }
            else
                sb.Append("\r\n None");

            return sb.ToString();
        }
        protected override void SetAspectConfiguration(AspectConfiguration aspectConfiguration, MethodBase targetMethod)
        {
            aspectConfiguration.AspectPriority = 2;
            base.SetAspectConfiguration(aspectConfiguration, targetMethod);
        }
    }
}
