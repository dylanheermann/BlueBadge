using Microsoft.AspNet.Identity;
using RMS.Models;
using RMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.WebMvc.Controllers
{
    public class SongController : Controller
    {
        //Goal: Change SongController to be used for the Archives page.

        private Guid _userId;

        public SongController()
        {
            if (User != null)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
            }
        }
        //REMEMBER: 
        //REMEMBER: Use Ctrl + Space when writing a line of code to see the possibilities of the remaining line.
        //REMEMBER: Annotate thoroughly, often.
        //This controller deals with all aspects of creating, reading, editing, and deleting a Song post.
        // GET: Song
        [AllowAnonymous]
        public ActionResult Index()
          
        {
            var service = new SongService();
            var model = service.GetAllSongs();
            return View(model);
            
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(SongCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSongService();


            if (service.CreateSong(model))
            {
                TempData["SaveResult"] = "Your Song was successfully created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Song could not be created.");

            return View(model);

        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = CreateSongService();
            var model = service.GetSongById(id);
            return View(model);
        }


        [Authorize]
        public ActionResult Edit(int id)
        {
            var service = CreateSongService();
            var detail = service.GetSongById(id);
            var model =
                new SongEditModel
                {
                    SongId = detail.SongId,
                    Title = detail.Title,
                    Content = detail.Content,
                    Link = detail.Link
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, SongEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SongId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateSongService();


            if (service.UpdateSong(model))
            {
                TempData["SaveResult"] = "Your Song was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Song could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateSongService();
            var model = service.GetSongById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSongService();

            if (service.DeleteSong(id))
            {
                TempData["SaveResult"] = "Your Song was successfully deleted.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Song could not be deleted!");


            return RedirectToAction("Index");
        }


        private SongService CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SongService(userId);
            return service;
        }
    }
}