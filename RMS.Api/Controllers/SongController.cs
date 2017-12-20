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
        private SongService CreateSongService(Guid id)
        {
            return new SongService(id);
        }
       

        // GET api/Song
        public IHttpActionResult GetAll()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService(userId);
            var songs = songService.GetAllSongs();
            return Ok(songs);
        }

        public IHttpActionResult Get(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongById(id);
            return Ok(song);
        }

        public IHttpActionResult Post(SongCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service = CreateSong(song))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SongEditModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
                return InternalServerError();


            return Ok();
        }



        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();


            return Ok();
        }


    }
}
