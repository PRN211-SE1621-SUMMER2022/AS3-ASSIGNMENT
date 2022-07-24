using BusinessObject.Models;
using BusinessObject.Utils;
using DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SaleWebApp.Filters;

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
        [AdminFilter]
        public ActionResult Create()
        {

            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter]
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
                if (id == null)
                {
                    return NotFound();
                }
                if (id != member.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        Member m = memberRepository.GetMemberByID(id);
                        if (m != null)
                        {
                            m.Email = member.Email;
                            m.City = member.City;
                            m.CompanyName = member.CompanyName;
                            m.Country = member.Country;
                            if (member.Password != null && member.Password != "")
                            {
                                m.Password = member.Password;
                            }
                        }
                        memberRepository.UpdateMember(m);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                    }
                    string session = HttpContext.Session.GetString("User");
                    if (session != null)
                    {
                        Member user = JsonConvert.DeserializeObject<Member>(session);
                        if (Helper.CheckRole(user))
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            return RedirectToAction(nameof(Details), routeValues: new { Id = user.Id });
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(member);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        // GET: MemberController/Delete/5
        [AdminFilter]
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
