using Leadersofpositvechange.Models;
using LOPC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leadersofpositvechange.Controllers
{

    public class HomeController : Controller
    {
        private readonly PositiveChangeEntitiesContext db;

        public HomeController()
        {
            db = new PositiveChangeEntitiesContext();
        }

        #region LeadersHomePage

        /// <summary>
        /// Landing page 
        /// </summary>
        /// <returns></returns>
        public ActionResult LeadersOfPositiveChange()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }

        #endregion


        #region About us

        public ActionResult AboutUs()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }

        #endregion


        #region Our Team

        public ActionResult OurTeam()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }

        #endregion


        #region Our Projects 


        // GET: Projects
        public ActionResult OurProjects()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }



        #endregion


        #region Our Gallery 


        public ActionResult Gallery()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }


        [Route("Home/Gallery/Photos/{galleryId?}")] //Route: /Users/Index
        public ActionResult Photos(int? galleryId)
        {
            var folder = "~/Photos/";

            switch (galleryId)
            {
                case 0:
                    {
                        folder = "~/Photos/Football/";
                        ViewBag.Title = "Football Event Gallery";
                        break;
                    }
                case 1:
                    {
                        folder = "~/Photos/Farm/";
                        ViewBag.Title = "Our Farm Gallery";
                        break;
                    }

                case 2:
                    {
                        folder = "~/Photos/Productivity/";
                        ViewBag.Title = "More From Our Farm and Productivity Gallery";
                        break;
                    }
                case 3:
                    {
                        folder = "~/Photos/Construction/";
                        ViewBag.Title = "Buildings and Shelter Gallery";
                        break;
                    }

                default:
                    //return RedirectToAction("ActionName", "ControllerName");
                    return RedirectToAction(nameof(Gallery));
                    //throw new Exception("Unexpected Case");
            }

            return View(new PhotoModel(folder));
        }

        #endregion


        #region Our Blog 


        public ActionResult OurBlog()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View(db.BlogPosts.ToList());
        }

        //GET: Blog
        [Route("Home/OurBlog/BlogPost/{postId?}")] //Route: /Users/Index
        public ActionResult BlogPost(int? postId)
        {
            var blogPost = db.BlogPosts.Find(postId);
            if (blogPost == null)
            {
                return RedirectToAction("OurBlog");
            }

            //strip html from
            //blogPost.Post = ; 
            blogPost.Post = blogPost.Post;
            return View(blogPost);
        }


        #endregion


        #region Volunteers
        //////////////////////////////Volunteers//////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Volunteer()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }


        // POST: Volunteers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Volunteer([Bind(Include = "Id,Name,Phone,Email,Message")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                volunteer.DateTimeMessage = DateTime.Now;
                db.Volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Volunteer");
            }
            return View(volunteer);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion


        #region Contact Us 

        /// <summary>
        /// //////////////////////////
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactUs()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }


        #endregion






    }
}