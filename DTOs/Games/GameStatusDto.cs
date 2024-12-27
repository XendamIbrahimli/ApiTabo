using Tabo.DTOs.Words;
using Tabo.Entities;

namespace Tabo.DTOs.Games
{
    public class GameStatusDto
    {
        public int Success {  get; set; }
        public int Fail { get; set; }
        public byte Skip { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public IEnumerable<int> UsedWordIds { get; set; }
        public int MaxSkipCount { get; set; }
        public int Score { get; set; }  
        public byte failCount { get; set; }
    }
}
