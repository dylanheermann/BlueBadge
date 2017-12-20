using Microsoft.AspNet.Identity;
using RMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMS.API.Controllers
{
    public class APIController : ApiController
    {


















        [Authorize]
        private SongService CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService(userId);
            return songService;

        }

    }
}
