﻿namespace SonaAPI.Models.Spotify
{
    public class Tracks
    {
        public string href { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public string previous { get; set; }
        public int total { get; set; }
        public Item[] items { get; set; }
    }
}
