using System;
using System.Collections.Generic;
using System.Linq;
using DbMove.Models;

namespace MoveAPI.Models
{
    public class MoveViewModel
    {
        public MoveViewModel()
        {

        }

        public MoveViewModel(Move move)
        {
            if (move == null)
            {
                return;
            }

            Id = move.Id;
            Name = move.Name;
            Description = move.Description;
            MoveDate = move.MoveDate;
            SportId = move.SportId;
            Longitude = move.Longitude;
            Latitude = move.Latitude;
            MediaId = move.MediaId;
            MoveMovers = move.MoveMovers;
            ReadOnly = true;
        }

        public MoveViewModel(Move move, List<MoveMover> moveMovers)
        {
            if (move == null)
            {
                return;
            }

            Id = move.Id;
            Name = move.Name;
            Description = move.Description;
            MoveDate = move.MoveDate;
            SportId = move.SportId;
            Longitude = move.Longitude;
            Latitude = move.Latitude;
            MediaId = move.MediaId;
            MoveMovers = move.MoveMovers;
            ReadOnly = moveMovers.FirstOrDefault(x => x.MoveId == move.Id)?.ReadOnly ?? true;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime MoveDate { get; set; }

        public long SportId { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public long? MediaId { get; set; }

        public ICollection<MoveMover> MoveMovers { get; set; }

        public bool ReadOnly { get; set; }

        internal Move ToMove()
        {
            return new Move
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                MoveDate = this.MoveDate,
                SportId = this.SportId,
                Longitude = this.Longitude,
                Latitude = this.Latitude,
                MediaId = this.MediaId
            };
        }
    }
}