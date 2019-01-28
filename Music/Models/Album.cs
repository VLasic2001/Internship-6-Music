using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public int ArtistId { get; set; }
        public List<Song> Songs { get; set; }
        public Artist Artist { get; set; }

        public void AddSongToAlbum(Song songToAdd)
        {
            if (Songs == null)
                Songs = new List<Song>();
            Songs.Add(songToAdd);
        }
    }
}
