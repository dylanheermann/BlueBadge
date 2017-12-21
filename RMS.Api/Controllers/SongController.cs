using Microsoft.AspNet.Identity;
using RMS.Models;
using RMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMS.API.Controllers
{
    public class SongController : ApiController
    {
        public SongService CreateSongService(Guid id)
        {
            return new SongService(id);
        }

        /*
        public SongService CreateSongService()
        {
            return new SongService();
        }
        */

        // GET api/Song
        public IHttpActionResult GetAll()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService(userId);
            var songs = songService.GetAllSongs();
            return Ok(songs);
        }

        public IHttpActionResult GetById(int id)
        {
            var songService = new SongService(Guid.Parse(User.Identity.GetUserId()));

            var song = songService.GetSongById(id);
            if (song == null) return NotFound();

            return Ok(song);
        }

        public IHttpActionResult Post(SongCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var songService = new SongService(Guid.Parse(User.Identity.GetUserId()));
            return Ok(songService.CreateSong(model));
        }
        public IHttpActionResult Put(SongEditModel song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new SongService();

            if (!service.UpdateSong(song))
                return InternalServerError();

            return Ok();
        }

        //public IHttpActionResult Put(SongEditModel model)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var songService = new SongService(Guid.Parse(User.Identity.GetUserId()));
        //    var song = songService.GetSongById(model.SongId);
        //    if (song == null) return NotFound();

        //    return Ok(songService.UpdateSong(model));
        //}



        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var songService = new SongService(Guid.Parse(User.Identity.GetUserId()));
            return Ok(songService.DeleteSong(id));
        }


    }
}
