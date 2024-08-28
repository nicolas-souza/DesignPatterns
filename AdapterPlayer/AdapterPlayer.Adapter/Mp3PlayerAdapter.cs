using AdapterPlayer.AdapterPlayer.Interface;
using AdapterPlayer.AdapterPlayer.Libs;

namespace AdapterPlayer.AdapterPlayer.Adapter;

public class Mp3PlayerAdapter : IMidiaPlayer
{
    private readonly Mp3Player mp3Player;
    private readonly Mp4Player mp4Player;

    public Mp3PlayerAdapter(Mp3Player mp3Player_, Mp4Player mp4Player_)
    {
        mp3Player = mp3Player_;
        mp4Player = mp4Player_;
    }
    public void Play(string file)
    {
        if(file.EndsWith(".mp3"))
            mp3Player.PlayMp3(file);
        if(file.EndsWith(".mp4"))
            mp4Player.Play(file);
        
    }
}
