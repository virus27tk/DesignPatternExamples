
namespace Potify
{
	public class BlueToothHardware()
    {
        public void PlayViaBluetooth(string song)
        {
            Console.WriteLine($"Playing audio via Bluetooth hardware: {song}");
        }
    }
    public class SpeakerHardware()
    {
        public void PlayViaSpeakers(string song)
        {
            Console.WriteLine($"Playing audio via Speaker hardware: {song}");
        }
    }
    public class HeadphoneHardware()
    {
        public void PlayViaHeadphones(string song)
        {
            Console.WriteLine($"Playing audio via Headphone hardware: {song}");
        }
    }

    public interface IAudioChannelAdapter
    {
        void PlayAudio(string song);
    }
    public class BluetoothAdapter : IAudioChannelAdapter
    {
        private BlueToothHardware _bluetoothHardware;

        public BluetoothAdapter(BlueToothHardware bluetoothHardware)
        {
            _bluetoothHardware = bluetoothHardware;
        }

        public void PlayAudio(string song)
        {
            _bluetoothHardware.PlayViaBluetooth(song);
        }
    }
    public class SpeakerAdapter : IAudioChannelAdapter
    {
        private SpeakerHardware _speakerHardware;

        public SpeakerAdapter(SpeakerHardware speakerHardware)
        {
            _speakerHardware = speakerHardware;
        }

        public void PlayAudio(string song)
        {
            _speakerHardware.PlayViaSpeakers(song);
        }
    }
    public class HeadphoneAdapter : IAudioChannelAdapter
    {
        private HeadphoneHardware _headphoneHardware;

        public HeadphoneAdapter(HeadphoneHardware headphoneHardware)
        {
            _headphoneHardware = headphoneHardware;
        }

        public void PlayAudio(string song)
        {
            _headphoneHardware.PlayViaHeadphones(song);
        }
    }  

    public enum AudioChannelType
    {
        Bluetooth,
        Speaker,
        Headphone
    }
    public class AudioChannelFactory
    {
        public static IAudioChannelAdapter GetAudioChannelAdapter(AudioChannelType channelType)
        {
            switch (channelType)
            {
                case AudioChannelType.Bluetooth:
                    return new BluetoothAdapter(new BlueToothHardware());
                case AudioChannelType.Speaker:
                    return new SpeakerAdapter(new SpeakerHardware());
                case AudioChannelType.Headphone:
                    return new HeadphoneAdapter(new HeadphoneHardware());
                default:
                    throw new NotSupportedException("Audio channel type not supported.");
            }
        }
    }

    public class AudioChannelManager
    {
        private IAudioChannelAdapter _audioChannelAdapter;

        public AudioChannelManager(AudioChannelType channelType)
        {
            _audioChannelAdapter = AudioChannelFactory.GetAudioChannelAdapter(channelType);
        }

        public void PlayAudio(string song)
        {
            _audioChannelAdapter.PlayAudio(song);
        }
    }
}
