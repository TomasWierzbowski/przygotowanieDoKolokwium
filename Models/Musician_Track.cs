namespace przygotowanie_do_kolokwium.Models
{
    public class Musician_Track
    {
        public virtual int IdTrack { get; set; }
        public virtual int IdMusician { get; set; }

        public virtual Musician Musician { get; set; }
        public virtual Track Track { get; set; }
    }
}
