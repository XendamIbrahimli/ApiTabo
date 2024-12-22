namespace Tabo.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
        public int? Score { get; set; }
        public int? SuccessAnswer { get; set; }
        public int? WrongAnswer { get; set; }
        public string LanguageCode { get; set; }
        public Language Language { get; set; }
    }
}
