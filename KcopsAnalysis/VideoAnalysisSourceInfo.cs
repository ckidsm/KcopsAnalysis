using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KcopsAnalysis
{
    internal class VideoAnalysisSourceInfo
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public int FileSize { get; set; }

        public string? fileContent { get; set; }

        public string? Description { get; set; }

    }
}
