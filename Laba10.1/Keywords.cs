using System.Collections.Generic;

namespace Компилятор
{
    class Keywords
    {
        private Dictionary<string, byte> _kw;

        public Dictionary<string, byte> Kw => _kw;

        public Keywords()
        {
            _kw = new Dictionary<string, byte>();

            _kw["program"] = LexicalAnalyzer.programsy;
            _kw["var"] = LexicalAnalyzer.varsy;

            _kw["record"] = LexicalAnalyzer.recordsy;

            _kw["begin"] = LexicalAnalyzer.beginsy;
            _kw["end"] = LexicalAnalyzer.endsy;

            _kw["with"] = LexicalAnalyzer.withsy;
            _kw["do"] = LexicalAnalyzer.dosy;
        }

        public bool IsKeyword(string word)
        {
            return _kw.ContainsKey(word.ToLower());
        }

        public byte GetCode(string word)
        {
            word = word.ToLower();

            if (_kw.ContainsKey(word))
            {
                return _kw[word];
            }

            return 0;
        }
    }
}
