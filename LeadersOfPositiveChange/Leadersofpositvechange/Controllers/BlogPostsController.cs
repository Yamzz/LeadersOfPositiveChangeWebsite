using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Leadersofpositvechange.Models;
using LOPC.Entities.Entities;

namespace Leadersofpositvechange.Controllers
{
    [Authorize]
    public class BlogPostsController : Controller
    {
        private PositiveChangeEntitiesContext db;

        public BlogPostsController ()
        {
            db = new PositiveChangeEntitiesContext();
        }

        // GET: BlogPosts
        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            //strip html from
            //blogPost.Post = ; 
            blogPost.Post = HttpUtility.HtmlDecode(StripHtml(blogPost.Post));

            return View(blogPost);
        }


        protected string StripHtml(string Txt)
        {
            return Regex.Replace(Txt, "<(.|\\n)*?>", string.Empty);
        }


        // GET: BlogPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken , ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,Post,DateTime,PostedBy,Image,Files")] BlogUploadViewModel blogPost)
        {
            if (ModelState.IsValid)
            {
                if (blogPost.Files[0] != null && blogPost.Files[0].ContentLength > 0)
                {
                    //var folder = HttpContext.Server.MapPath("~/Content/images/blog");
                    //var path2 = Path.Combine(Server.MapPath("~/Content/images/blog"), Path.GetFileName(file.FileName));

                    var folder = Server.MapPath("~/Content/images/blog");
                    var path = Path.Combine(folder, Path.GetFileName(blogPost.Files[0].FileName));
                    blogPost.DateTime = DateTime.Now;

                    //new blog blog entity 
                    var newBlogPost = new BlogPost
                    {
                        Id = blogPost.Id,
                        Title = blogPost.Title,
                        Post = blogPost.Post,
                        PostedBy = blogPost.PostedBy,
                        ShortDescription = blogPost.ShortDescription,
                        DateTime = blogPost.DateTime,
                        Image = path, 
                    };

                    db.BlogPosts.Add(newBlogPost);
                    blogPost.Files[0].SaveAs(path);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(blogPost);
        }


        [HttpPost]
        public ActionResult TestUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    var folder = HttpContext.Server.MapPath("~/Content/images/blog");
                    var path2 = Path.Combine(Server.MapPath("~/Content/images/blog"), Path.GetFileName(file.FileName));
                    var path = Path.Combine(folder, Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    //ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    //ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    Console.WriteLine(ex.StackTrace);
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        // GET: BlogPosts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            var blogPostVm = new BlogUploadViewModel
            {
                Id = blogPost.Id,
                DateTime = blogPost.DateTime,
                ImageName = blogPost.Image,          
                PostedBy = blogPost.PostedBy,
                Post = blogPost.Post,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
            };

            return View(blogPostVm);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,ImageName,ShortDescription,Post,DateTime,PostedBy,Image,Files")] BlogUploadViewModel blogPost)
        {
            if (ModelState.IsValid)
            {
                //if (blogPost.Files[0] != null && blogPost.Files[0].ContentLength > 0)
                //{
                    //var folder = HttpContext.Server.MapPath("~/Content/images/blog");
                    //var path2 = Path.Combine(Server.MapPath("~/Content/images/blog"), Path.GetFileName(file.FileName));

                    var folder = Server.MapPath("~/Content/images/blog");
                    string path; 
                    ///TODO PICK UP FROM HERE EDIT BLOG POST
                    if (blogPost.Files[0] != null && blogPost.Files[0].ContentLength > 0)
                    {
                        path = Path.Combine(folder, Path.GetFileName(blogPost.Files[0].FileName));
                        blogPost.Files[0].SaveAs(path);

                        //remove old image maybe 

                    }
                else
                {
                    path = blogPost.ImageName;
                }

                  //new blog blog entity 
                  var blogPostToUpdate = new BlogPost
                    {
                        Id = blogPost.Id,
                        Title = blogPost.Title,
                        Post = blogPost.Post,
                        PostedBy = blogPost.PostedBy,
                        ShortDescription = blogPost.ShortDescription,
                        DateTime = DateTime.Now,
                        Image = path,                         
                    };

                    db.Entry(blogPostToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }

            blogPost.Post = HttpUtility.HtmlDecode(StripHtml(blogPost.Post));

            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);

            //delete picture
            FileInfo file = new FileInfo(blogPost.Image);
            file.Delete(); 

            db.BlogPosts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
