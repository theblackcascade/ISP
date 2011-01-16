using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ThreadingSandbox
{
    public class Playlist
    {
        public List<Track> tracks = new List<Track>();
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan TotalLength {
            get
            {
                int PlaylistLength = 0;
                foreach (var track in tracks)
                    PlaylistLength = PlaylistLength + track.Length.Seconds;
                return new TimeSpan(0,0,0,PlaylistLength);
            }
        }
        public int Rate
        {
            get
            {
                int PlaylistRate = 0;
                foreach (var track in tracks)
                    PlaylistRate += track.Rate;
                return PlaylistRate / tracks.Count;
            }
        }
        public void SavePlaylist()
        {
            var serializer = new XmlSerializer(typeof(Playlist));
            using (Stream stream = File.Create(Title + ".xml"))
                serializer.Serialize(stream, this);
            Console.WriteLine("InSavePlayListMethod");
        }
        public static Playlist LoadPlaylist(string title)
        {
            var serilizer = new XmlSerializer(typeof(Playlist));
            Console.WriteLine("InLoadPlayListMethod");
            using (Stream stream = File.OpenRead(title + ".xml"))
            {
                return (Playlist)serilizer.Deserialize(stream);
            }
        }
    }
}
