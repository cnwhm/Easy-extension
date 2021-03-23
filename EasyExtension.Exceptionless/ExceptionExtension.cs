using System;

namespace EasyExtension.Exceptionless
{
    public static class ExceptionExtension
    {
        public static string ApiKey;
        public static string ServerUrl;
        public static void ExceptionRecord(this Exception ex,Action<Exception> handleException)
        {
            handleException(ex);
            string methodName = ex.TargetSite.Name;
            string nameSpace = ex.TargetSite.DeclaringType.Namespace;
            string fullName = ex.TargetSite.DeclaringType.FullName;
        }
    }
}
