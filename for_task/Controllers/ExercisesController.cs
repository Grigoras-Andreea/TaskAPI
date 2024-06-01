using Microsoft.AspNetCore.Mvc;

namespace for_task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : Controller
    {
        private static readonly List<string> HardCoded = new List<string>
        {
            "Hello", "World", "From", "Hard", "Coded", "List"
        };

        [HttpGet("5"+"{id}")]
        public IActionResult Get(int id)
        {
            return Ok(id);
        }

        [HttpGet("5"+"{id}/sum")]
        public IActionResult Get(int id, [FromQuery] double param1, [FromQuery] double param2)
        {
            double sum = param1 + param2;
            return Ok($"{id}: {sum}");
        }

        [HttpPost("5"+"sum")]
        public IActionResult SumList([FromBody] List<double> numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                return BadRequest("List of numbers cannot be null or empty.");
            }

            double sum = numbers.Sum();
            return Ok($"Sum of numbers: {sum}");
        }
        [HttpGet("6"+"values")]
        public IActionResult GetValues()
        {
            return Ok(HardCoded);
        }
        [HttpPut("5"+"update/{index}")]
        public IActionResult UpdateListValue(int index, [FromBody] string value)
        {
            // Check if index is out of bounds
            if (index < 0 || index >= HardCoded.Count)
            {
                return BadRequest("Index is out of bounds.");
            }

            // Check if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty.");
            }

            HardCoded[index] = value;
            return Ok(HardCoded);
        }
        [HttpDelete("delete/{index}")]
        public IActionResult DeleteListValue(int index)
        {
            // Check if index is out of bounds
            if (index < 0 || index >= HardCoded.Count)
            {
                return BadRequest("Index is out of bounds.");
            }

            HardCoded.RemoveAt(index);
            return Ok(HardCoded);
        }
    }
}
