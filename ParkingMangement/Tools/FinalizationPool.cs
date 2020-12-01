// Camera Vision
//
// Copyright © Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//
namespace CameraViewer
{
    using System;
    using System.Collections;
    using System.Threading;

    /// <summary>
    /// FinalizationPool
    /// </summary>
    public class FinalizationPool : CollectionBase
    {
        private Thread	thread;
        private ManualResetEvent stopEvent = null;

        // Constructor
        public FinalizationPool( )
        {
        }

        // Start the pool
        public void Start( )
        {
            // create events
            stopEvent = new ManualResetEvent( false );

            // create and start new thread
            thread = new Thread( new ThreadStart( WorkerThread ) );
            thread.Start( );
        }

        // Stop the pool
        public void Stop( )
        {
            if ( thread != null )
            {
                // signal to stop
                stopEvent.Set( );
                // wait for thread stop
                thread.Join( );

                thread = null;

                // release events
                stopEvent.Close( );
                stopEvent = null;
            }
        }

        // Thread entry point
        private void WorkerThread( )
        {
            while ( !stopEvent.WaitOne( 300, true ) )
            {
                lock ( this )
                {
                    int n = InnerList.Count;

                    // check each camera
                    for ( int i = n - 1; i >= 0; i-- )
                    {
                        Camera camera = (Camera) InnerList[i];

                        if ( !camera.IsRunning )
                        {
                            camera.CloseVideoSource( );
                            InnerList.RemoveAt( i );
                        }
                    }
                }
            }

            // exiting, so kill'em all
            foreach ( Camera camera in InnerList )
            {
                camera.Stop( );
            }
        }

        // Add new camera to the collection and run it
        public void Add( Camera camera )
        {
            lock ( this )
            {
                // add to the pool
                InnerList.Add( camera );
            }
        }

        // Ensure the camera is stopped
        public void Remove( Camera camera )
        {
            lock ( this )
            {
                for ( int i = 0; i < InnerList.Count; i++ )
                {
                    if ( InnerList[i] == camera )
                    {
                        if ( camera.IsRunning )
                        {
                            camera.Stop( );
                        }
                        camera.CloseVideoSource( );
                        InnerList.RemoveAt( i );
                        break;
                    }
                }
            }
        }
    }
}
