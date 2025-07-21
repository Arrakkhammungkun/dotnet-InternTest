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
	public class EquipmentController : ControllerBase
	{
		private readonly AppDbContext _context;

		public EquipmentController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<ActionResult<EquipmentResponse>> CreateEquipment([FromBody] EquipmentCreateRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var equipment = new Equipment
			{
				Name = request.Name,
				SerialNumber = request.SerialNumber,
				Description = request.Description,
				Total = request.Total,
				Status = request.Status,
				Unit = request.Unit,
				StorageLocation = request.StorageLocation,
				Condition = request.Condition
			};

			_context.Equipments.Add(equipment);
			await _context.SaveChangesAsync();

			var response = new EquipmentResponse
			{
				EquipmentId = equipment.EquipmentId,
				Name = equipment.Name,
				SerialNumber = equipment.SerialNumber,
				Description = equipment.Description,
				Total = equipment.Total,
				Status = equipment.Status,
				Unit = equipment.Unit,
				StorageLocation = equipment.StorageLocation,
				Condition = equipment.Condition,
				CreatedAt = equipment.CreatedAt
			};

			return CreatedAtAction(nameof(GetEquipment), new { id = equipment.EquipmentId }, response);
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EquipmentResponse>>> GetAllEquipment()
		{
			var Equipment = await _context.Equipments
				.Select(equipment => new EquipmentResponse
				{
					EquipmentId = equipment.EquipmentId,
					Name = equipment.Name,
					SerialNumber = equipment.SerialNumber,
					Description = equipment.Description,
					Total = equipment.Total,
					Status = equipment.Status,
					Unit = equipment.Unit,
					StorageLocation = equipment.StorageLocation,
					Condition = equipment.Condition,
					CreatedAt = equipment.CreatedAt
				})
				.ToListAsync();
			return Ok(Equipment);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<EquipmentResponse>> GetEquipment(int id)
		{
			var equipment = await _context.Equipments.FindAsync(id);
			if (equipment == null)
			{
				return NotFound();
			}

			var response = new EquipmentResponse
			{
				EquipmentId = equipment.EquipmentId,
				Name = equipment.Name,
				SerialNumber = equipment.SerialNumber,
				Description = equipment.Description,
				Total = equipment.Total,
				Status = equipment.Status,
				Unit = equipment.Unit,
				StorageLocation = equipment.StorageLocation,
				Condition = equipment.Condition,
				CreatedAt = equipment.CreatedAt
			};

			return Ok(response);
		}
	}

	public class EquipmentCreateRequest
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[MaxLength(50)]
		public string SerialNumber { get; set; } = string.Empty;

		[MaxLength(500)]
		public string? Description { get; set; }

		public int Total { get; set; }

		public string? Status { get; set; }

		public string? Unit { get; set; }

		[MaxLength(500)]
		public string? StorageLocation { get; set; }

		public string? Condition { get; set; }
	}

	public class EquipmentResponse
	{
		public int EquipmentId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string SerialNumber { get; set; } = string.Empty;
		public string? Description { get; set; }
		public int Total { get; set; }
		public string? Status { get; set; }
		public string? Unit { get; set; }
		public string? StorageLocation { get; set; }
		public string? Condition { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}