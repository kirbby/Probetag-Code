using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbMove.Models
{
    public class Move
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime MoveDate { get; set; }

        [Required]
        public long SportId { get; set; }

        public Sport Sport { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        public long? MediaId { get; set; }

        public Media Media { get; set; }

        public ICollection<MoveMover> MoveMovers { get; set; }
    }
}