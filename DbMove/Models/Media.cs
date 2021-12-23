using System.Collections.Generic;

namespace DbMove.Models
{
    public class Media
    {
        public long Id { get; set; }

        public byte[] File { get; set; }

        public string MediaUrl { get; set; }

        public ICollection<Move> Moves { get; set; }
    }
}