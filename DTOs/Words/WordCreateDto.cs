namespace Tabo.DTOs.Words
{
    public class WordCreateDto
    {
        public string Text { get; set; }
        public string LangCode { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
