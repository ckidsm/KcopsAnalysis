using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace KcopsAnalysis
{
    internal class VideoAnalysisResults
    {
        [DisplayName("영상재생시간")]
        public int FrameNumber { get; set; }
        [DisplayName("영상재생시간")]
        public double VideoNumber { get; set; }

        //https://www.csharptutorial.net/csharp-file/csharp-read-csv-file/
        public List<Collation> SetCsvFilePacer(string filename)
        {
            using (StreamReader SrtReader = new StreamReader(filename))
            { 
               
                using (CsvReader csvRead = new CsvReader((IParser)SrtReader))
                {
                  return (List<Collation>)csvRead.GetRecords<VideoAnalysisResults>();
                }
               
            }
            
        }

    }
}
