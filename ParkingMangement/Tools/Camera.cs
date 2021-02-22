// Camera Vision
//
// Copyright © Andrew Kirillov, 2005-2012
// andrew.kirillov@aforgenet.com
//

namespace CameraViewer
{
    using System;
    using System.Drawing;
    using System.Threading;
    using AForge.Video;
    using videosource;

    // Camera class
    public class Camera
    {
        private int id = 0;
        private string name;
        private string description = "";
        private Group parent = null;
        private object configuration = null;
        private VideoProvider provider = null;

        private IVideoSource videoSource = null;
        private Bitmap lastFrame = null;

        private int width = -1, height = -1;
        private float zoomFactor = 1f;

        //
        public event EventHandler NewFrame;

        // ID property
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        // Name property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Zoom property
        public float ZoomFactor
        {
            get { return zoomFactor; }
            set { zoomFactor = value; }
        }
        // Description property
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        // Parent property
        public Group Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        // FullName property
        public string FullName
        {
            get
            {
                return ( parent == null ) ? name : ( parent.FullName + '\\' + name );
            }
        }

        // Configuration property
        public object Configuration
        {
            get { return configuration; }
            set { configuration = value; }
        }
        // Provider property
        public VideoProvider Provider
        {
            get { return provider; }
            set { provider = value; }
        }
        // LastFrame property
        public Bitmap LastFrame
        {
            get { return lastFrame; }
        }
        // Width property
        public int Width
        {
            get { return width; }
        }
        // Height property
        public int Height
        {
            get { return height; }
        }
        // FramesReceived property
        public int FramesReceived
        {
            get { return ( videoSource == null ) ? 0 : videoSource.FramesReceived; }
        }
        // BytesReceived property
        public long BytesReceived
        {
            get { return ( videoSource == null ) ? 0 : videoSource.BytesReceived; }
        }
        // Running property
        public bool IsRunning
        {
            get { return ( videoSource == null ) ? false : videoSource.IsRunning; }
        }

        // Constructor
        public Camera( string name )
        {
            this.name = name;
        }

        // Create video source
        public bool CreateVideoSource( )
        {
            if ( ( provider != null ) && ( ( videoSource = provider.CreateVideoSource( configuration ) ) != null ) )
            {
                videoSource.NewFrame += new NewFrameEventHandler( video_NewFrame );
                return true;
            }
            return false;
        }

        // Close video source
        public void CloseVideoSource( )
        {
            if ( videoSource != null )
            {
                videoSource = null;
            }
            // dispose old frame
            if ( lastFrame != null )
            {
                lastFrame.Dispose( );
                lastFrame = null;
            }
            width = -1;
            height = -1;
        }

        // Start video source
        public void Start( )
        {
            if ( videoSource != null )
            {
                videoSource.Start( );
            }
        }

        // Siganl video source to stop
        public void SignalToStop( )
        {
            if ( videoSource != null )
            {
                videoSource.SignalToStop( );
            }
        }

        // Wait video source for stop
        public void WaitForStop( )
        {
            lock ( this )
            {
                if ( videoSource != null )
                {
                    videoSource.WaitForStop( );
                }
            }
        }

        // Abort camera
        public void Stop( )
        {
            lock ( this )
            {
                if ( videoSource != null )
                {
                    videoSource.Stop( );
                }
            }
        }

        // Lock it
        public void Lock( )
        {
            Monitor.Enter( this );
        }

        // Unlock it
        public void Unlock( )
        {
            Monitor.Exit( this );
        }

        // On new frame
        private void video_NewFrame( object sender, NewFrameEventArgs e )
        {
            lock ( this )
            {
                // dispose old frame
                if ( lastFrame != null )
                {
                    lastFrame.Dispose( );
                }

                lastFrame = (Bitmap) e.Frame.Clone( );

                // image dimension
                width = lastFrame.Width;
                height = lastFrame.Height;
            }

            // notify client
            if ( NewFrame != null )
            {
                NewFrame( this, new EventArgs( ) );
            }
        }
    }
}
