using System;
using System.Collections.Generic;
using System.Text;

namespace AzureLanguageTranslatorExample
{
    public class Translation
    {
        public string Text { get; set; }

        public TextResult Transliteration { get; set; }

        public string To { get; set; }

        public Alignment Alignment { get; set; }

        public SentenceLength SentLength { get; set; }
    }
}
