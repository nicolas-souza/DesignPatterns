using AdapterPlayer.AdapterPlayer.Interface;

namespace AdapterPlayer.AdapterPlayer.Client;

public class MediaClient
{
    private readonly IMidiaPlayer mediaPlayer;

    public MediaClient(IMidiaPlayer mediaPlayer_)
    {
        mediaPlayer = mediaPlayer_;
    }

    public void Play(string file)
    {
        mediaPlayer.Play(file);
    }
}
