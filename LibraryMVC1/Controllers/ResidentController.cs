using LibraryMVC1.Data;
using LibraryMVC1.Models.Residents;
using LibraryMVC1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ResidentController : Controller
{
    private readonly ApplicationDbContext _context;

    public ResidentController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Показване на всички жители
    public async Task<IActionResult> Index()
    {
        var residents = await _context.Residents.Include(r => r.Room).ToListAsync();
        return View(residents);
    }

    // Създаване на нов жител
    [HttpGet]
    public IActionResult Create()
    {
        // Зареждаме всички стаи от базата данни, за да ги подадем в изгледа
        ViewBag.Rooms = new SelectList(_context.Rooms, "Id", "RoomNumber");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateResidentViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Създаване на нов Resident обект от CreateResidentViewModel
            var resident = new Resident
            {
                FullName = model.FullName,
                Email = model.Email,
                RoomId = model.RoomId
            };

            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Ако не е валидно, връщаме обратно с попълнени стаи
        ViewBag.Rooms = new SelectList(_context.Rooms, "Id", "RoomNumber");
        return View(model);
    }
}
