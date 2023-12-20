using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KcopsAnalysis
{
    internal class VideoAnalysisCompletion
    {
        public string OutputFileName { get; set; }
        public string OutputFilePath { get; set; }
        public string OutputImage { get; set; }
        public string OutputText { get; set; }
        public string OutputCsv { get; set; }
        public string[] GraphReferenceValue { get; set; }
        public int FileSize { get; set; }
        public int Movielength { get;set; }
        public string Description { get; set; }

    }
}
