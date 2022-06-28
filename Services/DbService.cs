using Microsoft.EntityFrameworkCore;
using przygotowanie_do_kolokwium.DTO;
using przygotowanie_do_kolokwium.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace przygotowanie_do_kolokwium.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SomeSortOfAlbum>> GetAlbums(int IdAlbum)
        {
            return await _dbContext.Albums
    .Include( e => e.Tracks)
    .Select(e => new SomeSortOfAlbum
    {
        IdAlbum = e.IdAlbum,
        AlbumName = e.AlbumName,
        PublishDate = e.PublishDate,
        IdMusicLabel = e.IdMusicLabel,
        Tracks = e.Tracks.Select(e => new Track
        {
            TrackName = e.TrackName,
            Duration = e.Duration
        }).OrderBy(e => e.Duration).ToList()
    })
    .Where(e => e.IdAlbum == IdAlbum)
    .ToListAsync();
        }

        public async Task<bool> DeleteMusician(int IdMusician)
        {

            // check if musician exists
            var checkMusician = await _dbContext.Musicians.Where(e => e.IdMusician == IdMusician).FirstOrDefaultAsync();
            if (checkMusician is null)
            {
                return false;
            }

            // check if musician exists as foreign key in any track (actually musician_track); if yes we cannot delete
            var checkMusicianTrack = await _dbContext.Musician_Tracks.Where(e => e.IdMusician == IdMusician).FirstOrDefaultAsync();
            if (checkMusicianTrack != null)
            {
                return false;
            }

            _dbContext.Attach(checkMusician);
            _dbContext.Remove(checkMusician);

            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
