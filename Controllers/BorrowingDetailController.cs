using Microsoft.AspNetCore.Mvc;
using MyApiProject.Data;
using MyApiProject.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BorrowingDetailController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<BorrowingDetailResponse>> CreateBorrowingDetail([FromBody] BorrowingDetailCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrowingDetail = new Borrowing_Detail
            {
                BorrowingId = request.BorrowingId,
                EquipmentId = request.EquipmentId,
                ConditionAfterReturn = request.ConditionAfterReturn,
                Note = request.Note,
                Quantity = request.Quantity
            };

            _context.Borrowing_Details.Add(borrowingDetail);
            await _context.SaveChangesAsync();

            var response = new BorrowingDetailResponse
            {
                BorrowingId = borrowingDetail.BorrowingId,
                EquipmentId = borrowingDetail.EquipmentId,
                ConditionAfterReturn = borrowingDetail.ConditionAfterReturn,
                Note = borrowingDetail.Note,
                Quantity = borrowingDetail.Quantity
            };

            return CreatedAtAction(nameof(GetBorrowingDetail), new { borrowingId = borrowingDetail.BorrowingId, equipmentId = borrowingDetail.EquipmentId }, response);
        }

        [HttpGet("{borrowingId}/{equipmentId}")]
        public async Task<ActionResult<BorrowingDetailResponse>> GetBorrowingDetail(int borrowingId, int equipmentId)
        {
            var borrowingDetail = await _context.Borrowing_Details
                .Include(bd => bd.Borrowing)
                .Include(bd => bd.Equipment)
                .FirstOrDefaultAsync(bd => bd.BorrowingId == borrowingId && bd.EquipmentId == equipmentId);

            if (borrowingDetail == null)
            {
                return NotFound();
            }

            var response = new BorrowingDetailResponse
            {
                BorrowingId = borrowingDetail.BorrowingId,
                EquipmentId = borrowingDetail.EquipmentId,
                ConditionAfterReturn = borrowingDetail.ConditionAfterReturn,
                Note = borrowingDetail.Note,
                Quantity = borrowingDetail.Quantity
            };

            return Ok(response);
        }
    }

    public class BorrowingDetailCreateRequest
    {
        [Required]
        public int BorrowingId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ConditionAfterReturn { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Note { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

    public class BorrowingDetailResponse
    {
        public int BorrowingId { get; set; }
        public int EquipmentId { get; set; }
        public string ConditionAfterReturn { get; set; } = string.Empty;
        public string? Note { get; set; }
        public int Quantity { get; set; }
    }
}