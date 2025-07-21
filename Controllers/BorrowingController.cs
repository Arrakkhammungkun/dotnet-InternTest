using Microsoft.AspNetCore.Mvc;
using MyApiProject.Data;
using MyApiProject.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BorrowingController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Borrowing
        [HttpPost]
        public async Task<ActionResult<BorrowingResponse>> CreateBorrowing([FromBody] BorrowingCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrowing = new Borrowing
            {
                BorrowedDate = request.BorrowedDate,
                DueDate = request.DueDate,
                Status = request.Status,
                UserId = request.UserId,
                EquipmentId = request.EquipmentId
            };

            _context.Borrowings.Add(borrowing);
            await _context.SaveChangesAsync();

            var response = new BorrowingResponse
            {
                BorrowingId = borrowing.BorrowingId,
                BorrowedDate = borrowing.BorrowedDate,
                DueDate = borrowing.DueDate,
                DateReturned = borrowing.DateReturned,
                Status = borrowing.Status,
                UserId = borrowing.UserId,
                EquipmentId = borrowing.EquipmentId
            };

            return CreatedAtAction(nameof(GetBorrowing), new { id = borrowing.BorrowingId }, response);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowingResponse>>> GetAllBorrowing()
        {
            var Borrow = await _context.Borrowings
                .Select(borrowing => new BorrowingResponse
                {
                    BorrowingId = borrowing.BorrowingId,
                    BorrowedDate = borrowing.BorrowedDate,
                    DueDate = borrowing.DueDate,
                    DateReturned = borrowing.DateReturned,
                    Status = borrowing.Status,
                    UserId = borrowing.UserId,
                    EquipmentId = borrowing.EquipmentId

                })
                .ToListAsync();
            return Ok(Borrow);
        }



        // GET: api/Borrowing/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowingResponse>> GetBorrowing(int id)
        {
            var borrowing = await _context.Borrowings
                .Include(b => b.User)
                .Include(b => b.Equipment)
                .FirstOrDefaultAsync(b => b.BorrowingId == id);

            if (borrowing == null)
            {
                return NotFound();
            }

            var response = new BorrowingResponse
            {
                BorrowingId = borrowing.BorrowingId,
                BorrowedDate = borrowing.BorrowedDate,
                DueDate = borrowing.DueDate,
                DateReturned = borrowing.DateReturned,
                Status = borrowing.Status,
                UserId = borrowing.UserId,
                EquipmentId = borrowing.EquipmentId
            };

            return Ok(response);
        }
    }

    public class BorrowingCreateRequest
    {
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Borrowed";
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
    }

    public class BorrowingResponse
    {
        public int BorrowingId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateReturned { get; set; }
        public string Status { get; set; } = null!;
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
    }
}