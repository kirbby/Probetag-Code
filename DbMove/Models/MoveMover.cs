using System.ComponentModel.DataAnnotations;

namespace DbMove.Models
{
    public class MoveMover
    {
        public long Id { get; set; }

        [Required]
        public long MoveId { get; set; }

        public Move Move { get; set; }

        [Required]
        public long MoverId { get; set; }

        public Mover Mover { get; set; }

        public float Distance { get; set; }

        public bool ReadOnly { get; set; }
    }
}