using System;

namespace Potify
{
    public class Playlist
    {
        string playlistName {get; set;}
        string playlistDescription {get; set;}
        List<Song> songs;

        public Playlist(string playlistName, string playlistDescription)
        {
            this.playlistName = playlistName;
            this.playlistDescription = playlistDescription;
            songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            songs.Remove(song);
        }

        public List<Song> GetAllSongs()
        {
            return songs;
        }
    }

    public interface IPlaylistStrategy
    {
        Song GetNextSong(int currentSong);
    }
    public class ShufflePlayStrategy : IPlaylistStrategy
    {
        private Playlist _playlist;
        public ShufflePlayStrategy(Playlist playlist)
        {
            _playlist = playlist;
        }
        public Song GetNextSong(int currentSong)
        {
            var random = new Random();
            int index = random.Next(0, _playlist.GetAllSongs().Count);
            return _playlist.GetAllSongs()[index];
        }
    }
    public class OrderedPlayStrategy : IPlaylistStrategy
    {
        private Playlist _playlist;
        public OrderedPlayStrategy(Playlist playlist)
        {
            _playlist = playlist;
        }

        public Song GetNextSong(int currentSong)
        {
            if (currentSong + 1 < _playlist.GetAllSongs().Count)
            {
                return _playlist.GetAllSongs()[currentSong + 1];
            }
            return _playlist.GetAllSongs()[0];
        }
    }

    public enum PlayMode
    {
        Shuffle,
        Ordered
    }

    public class PlayModeFactory
    {
        public static IPlaylistStrategy GetPlayModeStrategy(PlayMode mode, Playlist playlist)
        {
            switch (mode)
            {
                case PlayMode.Shuffle:
                    return new ShufflePlayStrategy(playlist);
                case PlayMode.Ordered:
                    return new OrderedPlayStrategy(playlist);
                default:
                    throw new ArgumentException("Invalid play mode");
            }
        }
    }
}

