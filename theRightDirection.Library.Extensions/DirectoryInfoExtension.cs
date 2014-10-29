using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theRightDirection.Library.Extensions
{
    public static class DirectoryInfoExtension
    {
        public static List<FileInfo> GetImages(this DirectoryInfo directory, bool isRecursive = false)
        {
             List<FileInfo> filesFound = new List<FileInfo>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            foreach (var filter in filters)
            {
               filesFound.AddRange(directory.GetFiles(String.Format("*.{0}", filter), searchOption));
            }
           return filesFound;
        }
    }
}