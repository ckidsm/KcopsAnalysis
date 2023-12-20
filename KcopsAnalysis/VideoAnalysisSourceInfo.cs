using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KcopsAnalysis
{
    internal class VideoAnalysisSourceInfo
    {
        public VideoAnalysisSourceInfo() { }
        public string FileName { get; set; }
        public string FileFullName { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public string FileContent { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }


        public string?   Description { get; set; }



    }
}
