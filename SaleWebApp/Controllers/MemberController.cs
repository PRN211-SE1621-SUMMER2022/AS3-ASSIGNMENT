using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository;
using DataAccess;
using BusinessObject.Models;
namespace SaleWebApp.Controllers
{
    public class MemberController : Controller
    {
        IMemberRepository memberRepository = null;
        public MemberController() => memberRepository = new MemberRepository();


        // GET: MemberController
        public ActionResult Index()
        {
            var memberList = memberRepository.GetAllMember();
            return View(memberList);
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberByID(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepository.AddMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(member);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberByID(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            try
            {
                if (id != member.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    memberRepository.UpdateMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberByID(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Member member)
        {
            try
            {
                memberRepository.DeleteMember(member);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
