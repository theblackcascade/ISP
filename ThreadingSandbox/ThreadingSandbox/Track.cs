using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace ThreadingSandbox
{
    public enum genre
    {
        Rock,Metal,Doom,Sludge,Pop,Idm,Glitch,Dub,Ambient
    }
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Length { get; set; }
        public string Artist { get; set; }
        public genre Genre { get; set; }
        public int Rate { get; set; }
        public Track()
        {
            Id = 0;
            Title = "Unknown";
            Length = new TimeSpan(0, 0, 0);
            Artist = "Unknown";
            Genre = genre.Pop;
            Rate = 0;
        }
        public Track(int id, string title, TimeSpan length, string artist, genre genre, int rate)
        {
            Id = id;
            Title = title;
            Length = length;
            Artist = artist;
            Genre = genre;
            Rate = rate;
        }
        public void Play()
        {
            var t1 = new TimeSpan(0, 0, 0, 0);
            var t2 = new TimeSpan(0, 0, 0, 1);
            while (t1.TotalSeconds < this.Length.TotalSeconds)
            {
                Thread.Sleep(1000);
                t1 = t1.Add(t2);
                Console.Clear();
                Console.WriteLine("                                Foobar 666\n\n");
                Console.WriteLine("{6} / {3} Bang! {0} {1} - {2}  {4} , {5}", Id, Artist, Title, Length, Genre, Rate, t1);
                 //Проигрывается трек                 
            }
        }
    }
}
