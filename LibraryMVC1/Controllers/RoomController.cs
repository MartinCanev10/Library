using LibraryMVC1.Data;
using LibraryMVC1.Models;
using LibraryMVC1.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC1.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Показване на всички стаи
        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return View(rooms);
        }

        // Форма за създаване на стая
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Създаване на нова стая (POST)
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var room = new Room
                {
                    RoomNumber = model.RoomNumber,
                    Capacity = model.Capacity
                };

                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
