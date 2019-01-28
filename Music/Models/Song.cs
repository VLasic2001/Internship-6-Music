using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public int DurationInSeconds { get; set; }
        public List<Album> Albums { get; set; }
    }
}
