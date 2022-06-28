using przygotowanie_do_kolokwium.Models;
using System;
using System.Collections.Generic;

namespace przygotowanie_do_kolokwium.DTO
{
    public class SomeSortOfAlbum
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual MusicLabel MusicLabel { get; set; }
    }
}
