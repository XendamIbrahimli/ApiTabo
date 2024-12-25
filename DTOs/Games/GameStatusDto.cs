using Tabo.Entities;

namespace Tabo.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Success {  get; set; }
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public Stack<Word> Words { get; set; }
        public int[] UsedWordIds { get; set; }
    }
}
