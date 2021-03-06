﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurkishPlatform.Models;

namespace TurkishPlatform.Areas.Panel.Controllers
{
    public class ForumCommentTopicsController : Controller
    {
        private PlatformContext db = new PlatformContext();

        // GET: Panel/ForumCommentTopics
        public ActionResult Index()
        {
            var forumCommentTopics = db.ForumCommentTopics.Include(f => f.ForumTopicTitle);
            return View(forumCommentTopics.ToList());
        }

        // GET: Panel/ForumCommentTopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCommentTopic forumCommentTopic = db.ForumCommentTopics.Find(id);
            if (forumCommentTopic == null)
            {
                return HttpNotFound();
            }
            return View(forumCommentTopic);
        }

        // GET: Panel/ForumCommentTopics/Create
        public ActionResult Create()
        {
            ViewBag.ForumTopicTitleId = new SelectList(db.ForumTopicTitles, "TitleId", "Text");
            return View();
        }

        // POST: Panel/ForumCommentTopics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopicId,TopicTitle,ForumTopicTitleId")] ForumCommentTopic forumCommentTopic)
        {
            if (ModelState.IsValid)
            {
                db.ForumCommentTopics.Add(forumCommentTopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ForumTopicTitleId = new SelectList(db.ForumTopicTitles, "TitleId", "Text", forumCommentTopic.ForumTopicTitleId);
            return View(forumCommentTopic);
        }

        // GET: Panel/ForumCommentTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCommentTopic forumCommentTopic = db.ForumCommentTopics.Find(id);
            if (forumCommentTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ForumTopicTitleId = new SelectList(db.ForumTopicTitles, "TitleId", "Text", forumCommentTopic.ForumTopicTitleId);
            return View(forumCommentTopic);
        }

        // POST: Panel/ForumCommentTopics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopicId,TopicTitle,ForumTopicTitleId")] ForumCommentTopic forumCommentTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumCommentTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ForumTopicTitleId = new SelectList(db.ForumTopicTitles, "TitleId", "Text", forumCommentTopic.ForumTopicTitleId);
            return View(forumCommentTopic);
        }

        // GET: Panel/ForumCommentTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCommentTopic forumCommentTopic = db.ForumCommentTopics.Find(id);
            if (forumCommentTopic == null)
            {
                return HttpNotFound();
            }
            return View(forumCommentTopic);
        }

        // POST: Panel/ForumCommentTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumCommentTopic forumCommentTopic = db.ForumCommentTopics.Find(id);
            db.ForumCommentTopics.Remove(forumCommentTopic);
            db.SaveChanges();
            return RedirectToAction("Index");
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
