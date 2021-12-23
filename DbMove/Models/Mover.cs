using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbMove.Models
{
    public class Mover
    {
        public long Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime? Birthdate { get; set; }

        public ICollection<MoveMover> MoveMovers { get; set; }
    }
}