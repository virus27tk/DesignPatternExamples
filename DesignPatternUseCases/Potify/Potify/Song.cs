using System;

namespace Potify
{
    public class Song
    {
        string name {get; set;}
        string artist {get; set;}
        string genre {get; set;}

        public Song(string name, string artist, string genre)
        {
            this.name = name;
            this.artist = artist;
            this.genre = genre;
        }

        public string GetDetails()
        {
            return $"{name} by {artist} - Genre: {genre}";
        }
    }
}


