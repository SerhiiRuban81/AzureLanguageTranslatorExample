using System;
using System.Collections.Generic;
using System.Text;

namespace AzureLanguageTranslatorExample
{
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; set; }

        public TextResult SourceText { get; set; }

        public Translation[] Translations { get; set; }
    }
}
