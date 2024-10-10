﻿namespace DawnModel
{
    public class Anime
    {
        public string AniName { get; set; } 
        public DateTime AniReleaseDate { get; set; } = DateTime.MinValue;
        public string AniStudio { get; set; } = string.Empty;
        public string AniGenre { get; set; } = string.Empty;
    }
}
