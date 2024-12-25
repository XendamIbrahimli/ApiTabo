namespace Tabo.DTOs.Games
{
    public class GameCreateDto
    {
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int BannedWordCount { get; set; }
        public int Time { get; set; }
        public string LanguageCode { get; set; }
    }
}
