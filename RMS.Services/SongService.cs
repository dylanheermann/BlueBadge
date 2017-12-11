using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Contracts;
using RMS.Data;
using RMS.Models;

namespace RMS.Services
{
   public class SongService : ISongService
    {
        private readonly Guid _userId;

        public SongService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSong(SongCreateModel model)
        {
            var entity =
                new SongEntity()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx
                   .Songs
                   .Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SongListModel> GetSong()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SongListModel
                                {
                                    SongId = e.SongId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public SongDetailsModel GetSongById(int SongId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == SongId && e.OwnerId == _userId);

                return
                    new SongDetailsModel
                    {
                        SongId = entity.SongId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateSong(SongEditModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == model.SongId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId && e.OwnerId == _userId);

                ctx.Songs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool EditSong(SongEditModel model)
        {
            throw new NotImplementedException();
        }

        public int ShowSongById()
        {
            throw new NotImplementedException();
        }

        IEnumerable<SongCreateModel> ISongService.GetSongs()
        {
            throw new NotImplementedException();
        }

    }
}
