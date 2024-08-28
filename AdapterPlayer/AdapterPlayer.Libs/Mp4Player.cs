using AdapterPlayer.AdapterPlayer.Interface;

namespace AdapterPlayer.AdapterPlayer.Libs;

public class Mp4Player : IMidiaPlayer
{
    public void Play(string file)
    {
        Console.WriteLine($"Reproduzindo MP4: {file}");
    }
}
