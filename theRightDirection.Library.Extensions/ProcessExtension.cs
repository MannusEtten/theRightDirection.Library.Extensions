using System.Diagnostics;

namespace theRightDirection.Library.Extensions
{
    public static class ProcessExtension
    {
        public static string GetOwner(this Process process)
        {
            return ProcessInformation.GetProcessOwner(process.Id);
        }
    }
}