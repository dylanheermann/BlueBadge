using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RMS.Contracts;
using RMS.Data;
using RMS.Models;
using RMS.Services;

namespace BlueBadgeSolution.Controllers
{

    [Authorize]
    public class SongsController : Controller
    {
        private ISongService CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new SongService(userId);

            return svc;
        }

        // GET: Notes
        public ActionResult Index()
        {
            var model = CreateSongService().GetSongs();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new SongCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (!CreateSongService().CreateSong(model))
            {
                ModelState.AddModelError("", "Unable to create note");
                return View(model);
            }

            TempData["SaveResult"] = "Your note was created";

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = CreateSongService().GetSongById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detailModel = CreateSongService().GetSongById(id);
            var editModel =
                new SongEditModel
                {
                    SongId = detailModel.SongId,
                    Title = detailModel.Title,
                    Content = detailModel.Content
                };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SongEditModel model)
        {
            if (model.SongId != id)
            {
                ModelState.AddModelError("", "Nice try!");
                model.SongId = id;
                return View(model);
            }

            if (!ModelState.IsValid) return View(model);

            if (!CreateSongService().UpdateSong(model))
            {
                ModelState.AddModelError("", "Unable to update song");
                return View(model);
            }

            TempData["SaveResult"] = "Your song was saved";

            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var model = CreateSongService().GetSongById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            CreateSongService().DeleteSong(id);

            TempData["SaveResult"] = "Your song was deleted";

            return RedirectToAction("Index");
        }

    }
}