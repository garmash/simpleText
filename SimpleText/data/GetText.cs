using SimpleText.interfaces;
using SimpleText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SimpleText.data
{
    public class GetText : IGetText
    {
        public string PText
        {
            get
            {
                var sb = new System.Text.StringBuilder("7 Гай, гай! ой, дей же його кату!\r\n");
                sb.Append("Еол насупившись сказав. —\r\n");
                sb.Append("Я все б зробив за сюю плату,\r\n");
                sb.Append("Та вітри всі порозпускав:\r\n");
                sb.Append("Борей недуж лежить з похмілля,\r\n");
                sb.Append("А Нот поїхав на весілля,\r\n");
                sb.Append("Зефір же, давній негодяй,\r\n");
                sb.Append("З дівчатами заженихався,\r\n");
                sb.Append("А Евр в поденщики нанявся, —\r\n");
                sb.Append("Я к хочеш, так і помишляй!\r\n");
                return sb.ToString();
            }

            set {
                
            }
        }
        public Dictionary<string, double> _metriks = new Dictionary<string, double>(); 
        //_metriks = 

        public void GetMetriks()
        {
            // counters
            int exclamSentens; 
            int marks; // count of punctuation marks
            int words = 0; // count of words
            int evenWords = 0; // count of even words
            int charackters; //count of all characters in text

            Dictionary<string, int> uniqueWords = new Dictionary<string, int>();

            string wordPattern = @"\b\w+\b"; 
            string punktPattern = @"\p{P}";
            string tmpWord;

            // get count of exclamatin marks and split text to array of blocks
            string[] extSentnsies = PText.Split('!'); //may be need check for empty or trashed elements
            marks = extSentnsies.Length - 1;
            charackters = marks; // extend charcount by '!'
            exclamSentens = marks;
            
            // analyze blocks             char[] otherSeparators = new char[] { '!', '.', '?' };
            foreach (string txtBlock in extSentnsies)
            {
                string[] blockWords = txtBlock.Split(' ');
                charackters += blockWords.Length - 1; // extend charcount by spaces
                // analyze words
                foreach (string word in blockWords)
                {
                    if (!String.IsNullOrEmpty(word)) {
                        charackters += word.Length; // extend charcount by other symbols
                        marks += Regex.Match(word, punktPattern).Length; // extend punktmarks 
                        foreach (Match match in Regex.Matches(word, wordPattern)) // get words
                        {
                            if (match.Success) // check if word found
                            {
                                words++; // increment words count
                                tmpWord = match.Value.ToLower(); // lowercase the word to compare
                                if (tmpWord.Length % 2 == 0) // check if word has even charackter count
                                {
                                    evenWords++; // then increment 
                                }
                                if (uniqueWords.ContainsKey(tmpWord)) // check if word is not unique
                                {
                                    uniqueWords[tmpWord]++; // then increment count of unique words
                                }
                                else
                                {
                                    uniqueWords.Add(tmpWord, 1); // else add it
                                }
                            }
                        }

                    }
                }

            }
            _metriks.TryAdd("ExclamationSentenceCount", exclamSentens);
            _metriks.TryAdd("EvenWordPercent", 100.0 * evenWords / words);
            _metriks.TryAdd("UniqueWordCount", uniqueWords.Count);
            _metriks.TryAdd("ClassicDocumentNausea", Math.Sqrt(uniqueWords.Values.Max()));
            _metriks.TryAdd("ComplexDocumentPercent", 100.0 * marks / charackters);
        }


        public SText AllTextString
        {
            get
            {
                GetMetriks();
                return new SText
                {
                        TextToAnalyze = PText, Metriks = _metriks
                };
            }
        }
    }
}
