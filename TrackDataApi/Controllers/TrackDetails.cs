namespace TrackDataApi.Controllers
{
    public class TrackDetails
    {
        public string Artist { get; set; }
        public int SevenDigArtistId { get; set; }
        public int SevenDigTrackId { get; set; }
        public decimal Dancability { get; set; }
        public decimal Energy { get; set; }
        public decimal Tempo { get; set; }
        public string Title { get; set; }
    }
}