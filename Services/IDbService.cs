using przygotowanie_do_kolokwium.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace przygotowanie_do_kolokwium.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfAlbum>> GetAlbums(int IdAlbum);
        Task<bool> DeleteMusician(int IdMusician);
    }
}
