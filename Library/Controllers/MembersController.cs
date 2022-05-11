using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Library.ViewModels;

namespace Library.Controllers
{
    public class MembersController : Controller
    {
        private ApplicationDbContext _context;

        public MembersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Members
        public ActionResult Index()
        {
            var members = _context.Members;
            return View(members);
        }
        //GET: Members/Details
        public ActionResult Details(int id)
        {
            var member = _context.Members.Include(m => m.MembershipType).SingleOrDefault(m => m.Id == id);

            if (member == null)
                return HttpNotFound();
            return View(member);
        }
        // Add New Member
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new MemberFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("MemberForm",viewModel);
        }
        // Create Member
        [HttpPost]
        public ActionResult Save(Member member)
        {
            if (member.Id == 0)
                _context.Members.Add(member);
            else
            {
                var memberInDb = _context.Members.Single(m => m.Id == member.Id);

                memberInDb.Name = member.Name;
                memberInDb.BirthDate = member.BirthDate;
                memberInDb.MembershipTypeId = member.MembershipTypeId;
                memberInDb.IsSubscribedToNewsletter = member.IsSubscribedToNewsletter;

            }
           
            _context.SaveChanges();
            return RedirectToAction("Index", "Members");
          
        }
        // Edit Member
        public ActionResult Edit(int id)
        {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (member == null)
                return HttpNotFound();

            var viewModel = new MemberFormViewModel
            {
                Member = member,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("MemberForm", viewModel);
        }
        
    }
}