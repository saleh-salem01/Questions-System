using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jocksWebApp.Data;
using jocksWebApp.Models;

namespace jocksWebApp.Controllers
{
    public class QAnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QAnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QAnswers
        public async Task<IActionResult> Index()
        {
            return View(await _context.QAnswer.ToListAsync());
        }

        // GET: QAnswers/Details/5
        //GET: Qanswer/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        //POST: QAnswer/ShowSearchResult
        public async Task<IActionResult> ShowSearchResult(string SearchPhrase)
        {
            return View("Index", await _context.QAnswer.Where(j => j.Question.Contains(SearchPhrase)).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qAnswer = await _context.QAnswer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qAnswer == null)
            {
                return NotFound();
            }

            return View(qAnswer);
        }

        // GET: QAnswers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] QAnswer qAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qAnswer);
        }

        // GET: QAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qAnswer = await _context.QAnswer.FindAsync(id);
            if (qAnswer == null)
            {
                return NotFound();
            }
            return View(qAnswer);
        }

        // POST: QAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] QAnswer qAnswer)
        {
            if (id != qAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QAnswerExists(qAnswer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(qAnswer);
        }

        // GET: QAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qAnswer = await _context.QAnswer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qAnswer == null)
            {
                return NotFound();
            }

            return View(qAnswer);
        }

        // POST: QAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qAnswer = await _context.QAnswer.FindAsync(id);
            if (qAnswer != null)
            {
                _context.QAnswer.Remove(qAnswer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QAnswerExists(int id)
        {
            return _context.QAnswer.Any(e => e.Id == id);
        }
    }
}
