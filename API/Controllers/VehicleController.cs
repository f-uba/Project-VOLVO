using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class VehicleController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Get all vehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetVehiclesAsync()
        {
            try
            {
                var command = new GetVehiclesCommand();
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get vehicle by series number
        /// </summary>
        /// <param name="series"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("{series}/{number}")]
        public async Task<IActionResult> GetVehicleBySeriesNumber(string series, uint number)
        {
            try
            {
                var command = new GetVehicleBySeriesNumberCommand 
                { 
                    Series = series,
                    Number = number
                };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new vehicle
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update vehicle color
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
