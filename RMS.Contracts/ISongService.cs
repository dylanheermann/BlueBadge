using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Models;

namespace RMS.Contracts
{
    public interface ISongService
    {
        bool CreateSong(SongCreateModel model);
        bool EditSong(SongEditModel model);
        int ShowSongById();
        IEnumerable<SongCreateModel> GetSongs();
        bool UpdateSong(SongEditModel model);
        bool DeleteSong(int songId);
        SongDetailsModel GetSongById(int SongId);
    }
}
