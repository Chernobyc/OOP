using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateToPass = new DateTime(2023, 10, 25, 15, 34, 18);
            var image1 = new Image("Image 1", "Titus", dateToPass, 32, 1280, 1024);
            var image2 = new Image("Image 2", "Paul", dateToPass, 25, 1280, 1024);
            var video1 = new Video("Video 1", "Rocky", dateToPass, 16, 1280, 1024);
            var video2 = new Video("Video 2", "Garry", dateToPass, 62, 1280, 1024);
            
            var collection1 = new MediaCollection("Collection 1", "User", dateToPass, 100);
            collection1.Add(image1);
            collection1.Add(video1);

            var collection2 = new MediaCollection("Collection 2", "User", dateToPass, 80);
            collection2.Add(image2);
            collection2.Add(video2);

            var rootCollection = new MediaCollection("Root Collection", "User", dateToPass, 80);
            rootCollection.Add(collection1);
            rootCollection.Add(collection2);

            rootCollection.Display(0);
        }
    }

    interface IDuration
    {
        int Duration { get; }
    }

    interface IMediaPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }

    interface IResizable
    {
        void Resize();
    }

    /*
    public class Date
    {
        private DateTime date;
          public int year;
          public int month;
          public int day;
        
        public Date(int year, int month, int day)
        {
            date = new DateTime(year, month, day);
        }
        public DateTime GetTime()
        {
            return date;
        }

    }
    */
    abstract class MultimediaComponent
    {
        protected string name;
        protected string author;     
        private readonly DateTime creationDate;
        protected ulong fileSize;
        protected int Resolution { get; set; }
        public MultimediaComponent(string name, string author, DateTime date, ulong size)
        {
            this.name = name;
            this.author = author;
            creationDate = date;
            fileSize = size;
        }
        public MultimediaComponent(string name, string author, DateTime date, ulong size, int width, int height) : this(name, author, date, size)
        {
            Resolution = width * height;
        }

        public abstract void Add(MultimediaComponent component);
        public abstract void Remove(MultimediaComponent component);
        public abstract void Display(int depth);
        public abstract void Share(MultimediaComponent component);
        
    }

    class Image : MultimediaComponent, IResizable
    {
        public Image(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add an image");
        }

        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove an image.");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("Image was shared");
        }

        public void Resize()
        {
            Console.WriteLine("Image was resized.");
        }
    }

    class Video : MultimediaComponent, IDuration, IMediaPlayable
    {
        public Video(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add a video.");
        }

        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove a video.");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("Video was shared");
        }
        public void Play()
        {
            Console.WriteLine("Video playing.");
        }

        public void Pause()
        {
            Console.WriteLine("Video was paused.");
        }

        public void Stop()
        {
            Console.WriteLine("Video was stopped.");
        }

        public int Duration { get => 0; }

    }

    class Audio : MultimediaComponent, IDuration, IMediaPlayable
    {
        public Audio(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add an Audio");
        }

        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove an Audio");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("Audio was shared");
        }
        public void Play()
        {
            Console.WriteLine("Video playing.");
        }

        public void Pause()
        {
            Console.WriteLine("Video was paused.");
        }

        public void Stop()
        {
            Console.WriteLine("Video was stopped.");
        }

        public int Duration { get => 0; }

    }

    class Document : MultimediaComponent
    {
        public Document(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add a document.");
        }
        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove a document.");
        }
        
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("Document was shared");
        }
    }

    class Graphics : MultimediaComponent
    {
        public Graphics(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add a graphics.");
        }
        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove a graphics.");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("File was shared");
        }
    }

    class Animation : MultimediaComponent, IDuration, IMediaPlayable
    {
        public Animation(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add an animation.");
        }

        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove an animation.");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("Animation was shared");
        }
        public void Play()
        {
            Console.WriteLine("Animation playing.");
        }

        public void Pause()
        {
            Console.WriteLine("Animation was paused.");
        }

        public void Stop()
        {
            Console.WriteLine("Animation was stopped.");
        }

        public int Duration { get => 0; }

    }

    class Gif : MultimediaComponent, IDuration, IMediaPlayable
    {
        public Gif(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add a gif.");
        }
        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove a gif.");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("Gif was shared");
        }

        public void Play()
        {
            Console.WriteLine("Gif playing.");
        }

        public void Pause()
        {
            Console.WriteLine("Gif was paused.");
        }

        public void Stop()
        {
            Console.WriteLine("Gif was stopped.");
        }

        public int Duration { get => 0; }

    }

    class VR : MultimediaComponent, IDuration, IMediaPlayable
    {
        public VR(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {   

        }

        public override void Add(MultimediaComponent component)
        {
            Console.WriteLine("Trying to add a VR.");
        }
        public override void Remove(MultimediaComponent component)
        {
            Console.WriteLine("Trying to remove a VR.");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("File was shared");
        }

        public void Play()
        {
            Console.WriteLine("VR playing.");
        }

        public void Pause()
        {
            Console.WriteLine("VR was paused.");
        }

        public void Stop()
        {
            Console.WriteLine("VR was stopped.");
        }

        public int Duration { get => 0; }

    }

    class MediaCollection : MultimediaComponent
    {
        private List<MultimediaComponent> multimediaComponents = new List<MultimediaComponent>();

        public MediaCollection(string name, string author, DateTime date, ulong size, int width, int height) : base(name, author, date, size, width, height)
        {
                
        }

        public MediaCollection(string name, string author, DateTime date, ulong size) : base(name, author, date, size)
        {

        }
        public override void Add(MultimediaComponent component)
        {
            multimediaComponents.Add(component);
        }

        public override void Remove(MultimediaComponent component)
        {
            multimediaComponents.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + "Collection: " + name);

            foreach (var component in multimediaComponents)
            {
                component.Display(depth + 2);
            }
        }
        public override void Share(MultimediaComponent component)
        {
            Console.WriteLine("File was shared");
        }
    }

}
