using Microsoft.AspNetCore.Mvc;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly VotingService _votingService;

        public VotingController(VotingService votingService)
        {
            _votingService = votingService;
        }

        // Endpoint to get legislator's bill support and opposition count
        [HttpGet("legislator/{legislatorId}/support-opposition")]
        public async Task<IActionResult> GetLegislatorSupportOpposition(int legislatorId)
        {
            try
            {
                var result = await _votingService.GetLegislatorSupportOppositionAsync(legislatorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint to get bill's legislator support and opposition count
        [HttpGet("bill/{billId}/support-opposition")]
        public async Task<IActionResult> GetBillSupportOpposition(int billId)
        {
            try
            {
                var result = await _votingService.GetBillSupportOppositionAsync(billId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}