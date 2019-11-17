using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJSuite.Models.APIModels
{
    public class QueueDTO
    {
        public int Id { get; set; }
        public TrackDTO[] Tracks;
        public AudioFeaturesDTO[] AudioFeatures;
    }

    public class Queue
    {
        public int QueueID { get; set; }
        public string TrackName { get; set; }
        public string TrackUri { get; set; }
    }
}