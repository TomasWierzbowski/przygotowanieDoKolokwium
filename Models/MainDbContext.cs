using Microsoft.EntityFrameworkCore;
using System;

namespace przygotowanie_do_kolokwium.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Musician>(m => {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname);

                m.HasData(
                    new Musician { IdMusician = 1, FirstName = "Jan", LastName = "Kowalski", Nickname = "Nickname 1" },
                    new Musician { IdMusician = 2, FirstName = "Ada", LastName = "Nowak", Nickname = "Nickname 2" }
                    );

            });

            modelbuilder.Entity<MusicLabel>(ml => {
                ml.HasKey(e => e.IdMusicLabel);
                ml.Property(e => e.Name);

                ml.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "label 1" },
                    new MusicLabel { IdMusicLabel = 2, Name = "label 2" }
                    );

            });

            modelbuilder.Entity<Album>(a => {
                a.HasKey(e => new {
                    e.IdAlbum,
                });
                a.Property(e => e.AlbumName);
                a.Property(e => e.PublishDate);
                a.Property(e => e.IdMusicLabel);

                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Nazwa albumu 1", PublishDate= DateTime.Parse("2022-03-01"), IdMusicLabel = 1},
                    new Album { IdAlbum = 2, AlbumName = "Nazwa albumu 2", PublishDate = DateTime.Parse("2020-03-01"), IdMusicLabel = 2 }
                    );

            });


            modelbuilder.Entity<Track>(t => {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();
                t.Property(e => e.IdMusicAlbum);

                t.HasOne(e => e.MusicAlbum).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                t.HasData(
                    new Track { IdTrack = 1, TrackName = "name 1", Duration = 3, IdMusicAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "name 2", Duration = 4, IdMusicAlbum = 2 }
                    );

            });

            modelbuilder.Entity<Musician_Track>(mt => {
                mt.HasKey(e => new {
                    e.IdTrack,
                    e.IdMusician
                });

                mt.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                mt.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);

                mt.HasData(
                    new Musician_Track { IdMusician = 1, IdTrack = 1 },
                    new Musician_Track { IdMusician = 2, IdTrack = 2}
                    );

            });

        }
    }
}
