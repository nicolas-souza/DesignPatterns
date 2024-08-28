using AdapterPlayer.AdapterPlayer.Adapter;
using AdapterPlayer.AdapterPlayer.Client;
using AdapterPlayer.AdapterPlayer.Interface;
using AdapterPlayer.AdapterPlayer.Libs;
using Microsoft.Extensions.DependencyInjection;

namespace AdapterPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuração do serviço de DI
            var serviceProvider = new ServiceCollection()
                .AddScoped<Mp4Player>() // Registra o Adapter como IMediaPlayer
                .AddScoped<Mp3Player>() // Registra o Adapter como IMediaPlayer
                .AddScoped<IMidiaPlayer, Mp3PlayerAdapter>() // Registra o Adapter como IMediaPlayer
                .AddScoped<MediaClient>() // Registra o MediaClient
                .BuildServiceProvider();

            // Resolve as dependências
            var mediaClient = serviceProvider.GetRequiredService<MediaClient>();

            // Usando o MediaClient para reproduzir arquivos
            mediaClient.Play("musica.mp3");
            mediaClient.Play("video.mp4");
            mediaClient.Play("documento.pdf");
        }
    }
}