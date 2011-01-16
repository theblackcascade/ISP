using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSandbox
{
    public class Player
    {
        public ManualResetEvent playing = new ManualResetEvent(false);
        public List<Playlist> PlaylistPool = new List<Playlist>();
        public Playlist CurrentPlaylist;
        bool isPlaying = false;
        public void Play()
        {
                foreach (var playlist in PlaylistPool)
                {
                    foreach (var track in playlist.tracks)
                    {
                        if (isPlaying)
                            track.Play();
                        else
                            playing.WaitOne();                                                                                   
                    }
                }
        }
        public void Pause()
        {
            playing.Reset();
            isPlaying = false;
        }
        public void Resume()
        {
            playing.Set();
            isPlaying = true;
        }
    }
}
