namespace Tabo.Entities
{
    public class Language
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Word> Words { get; set; }
    }
}
