
namespace Potify
{
	class Program
	{
		static void Main(string[] args)
		{
			var song1 = new Song("Song1", "Srujan", "Happy");
			var song2 = new Song("Song2", "Alice", "Pop");
			var song3 = new Song("Song3", "Bob", "Rock");
			var song4 = new Song("Song4", "Charlie", "Jazz");
			var song5 = new Song("Song5", "Diana", "Classical");

			// Touch: force rebuild
			var headphone = AudioChannelFactory.GetAudioChannelAdapter(AudioChannelType.Headphone);
			var player = new PotifyPlayer(headphone);
			player.StartMusicPlayer(song1);

			var speaker = AudioChannelFactory.GetAudioChannelAdapter(AudioChannelType.Speaker);
			var player2 = new PotifyPlayer(speaker);
			player2.StartMusicPlayer(song2);

			var playlist1 = new Playlist("MyPlaylist", "My favorite songs");
			playlist1.AddSong(song1);
			playlist1.AddSong(song2);
			playlist1.AddSong(song3);
			
			//Shuffle Play
			var playListStrategy = PlayModeFactory.GetPlayModeStrategy(PlayMode.Shuffle, playlist1);
			var nextSong = playListStrategy.GetNextSong(-1);
			player.StartMusicPlayer(nextSong); //Played Fist song in BT

			nextSong = playListStrategy.GetNextSong(1);
			player2.StartMusicPlayer(nextSong); //Played Second song in Speaker

			//Sequential Play
			var playlist2 = new Playlist("SequentialPlaylist", "Songs in order");
			playlist2.AddSong(song3);
			playlist2.AddSong(song4);
			playlist2.AddSong(song5);

			var sequentialStrategy = PlayModeFactory.GetPlayModeStrategy(PlayMode.Ordered, playlist2);
			nextSong = sequentialStrategy.GetNextSong(0);
			player.StartMusicPlayer(nextSong); //Played first song sequentially on Headphone

			nextSong = sequentialStrategy.GetNextSong(1);
			player2.StartMusicPlayer(nextSong); //Played second song sequentially on Speaker
		}
	}
}
