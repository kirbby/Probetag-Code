using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbMove.Models
{
    public class Sport
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Move> Moves { get; set; }
    }
}