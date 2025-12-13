using System;

namespace Potify
{
    public class PotifyPlayer
    {
        private IAudioChannelAdapter _audioChannelAdapter;
        public PotifyPlayer(IAudioChannelAdapter audioChannel)
        {
            _audioChannelAdapter = audioChannel;
        }
            // Touch: force rebuild
        public void StartMusicPlayer(Song song)
        {
            _audioChannelAdapter.PlayAudio(song.GetDetails());
        }
    }
    
}