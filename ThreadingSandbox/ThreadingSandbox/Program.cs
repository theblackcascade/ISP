using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ThreadingSandbox
{
    class Program
    {
        static void Main(string[] args)
        {            
            var playlist = new Playlist();
            playlist.Title = "Default";
            playlist.Id = 0;
            for(int i=0; i<1000; i++)
                playlist.tracks.Add(new Track(i,"unknownTrack" + i.ToString(),new TimeSpan(0,0,0,i),"unknownArtist", genre.Ambient, i));

            var playlistSaveThread = new Thread(playlist.SavePlaylist);

            var player = new Player();

            player.PlaylistPool.Add(playlist);

            var playThread = new Thread(player.Play);
            playThread.Start();
            Console.WriteLine("                                Foobar 666\n\n");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadKey();       
            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("                                Foobar 666\n\n");
               
                string response = Console.ReadLine();
                switch (response)
                {
                    case "s":
                        playlistSaveThread.Start();
                        break;
                    case "p":
                        player.Pause();
                        Console.WriteLine("                              Paused");
                        break;
                    case "r":
                        player.Resume();
                        Console.WriteLine("                              Resumed");
                        break;
                    case "l":
                        playlist = Playlist.LoadPlaylist(Console.ReadLine());
                        break;
                    case "e":
                        playThread.Abort();
                        playlistSaveThread.Abort();
                        break;
                        
                }
            }
        }
    }
}
