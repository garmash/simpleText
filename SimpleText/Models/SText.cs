using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleText.Models
{
    public class SText
    {
        public string TextToAnalyze { set; get; }
        public Dictionary<string, double> Metriks { set; get; }
        /*
        public struct Metriks
        {
            public int ExclamationSentenceCount;
            public int UniqueWordCount;
            public float EvenWordPercent;
            public float ClassicDocumentNausea; //Классическая тошнота определяется по самому частотному слову — как квадратный корень из количества его вхождений.
            public float ComplexDocumentPercent; //Percent of punctuation marks
        }

        public Metriks metriks = new Metriks(); */

    }
}
