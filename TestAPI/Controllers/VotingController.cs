using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.UseCases.GetAllBills;
using TestAPI.UseCases.GetAllLegislators;
using TestAPI.UseCases.GetBillSupportsOpositionsById;
using TestAPI.UseCases.GetLegislatorVotesCountById;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VotingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("legislator/support-opposition")]
        public async Task<IActionResult> GetLegislatorSupportOpposition()
        {
            try
            {
                List<GetLegislatorVotesCountByIdResponse> result = new List<GetLegislatorVotesCountByIdResponse>();
                GetAllLegislatorsResponse legislators = await _mediator.Send(new GetAllLegislatorsRequest());
                foreach(Person person in legislators.Legislators){
                    try
                    {
                        GetLegislatorVotesCountByIdResponse legislatorVotesCount = await _mediator.Send(new GetLegislatorVotesCountByIdRequest(person.Id));
                        result.Add(legislatorVotesCount);
                    }
                    catch (Exception ex){}
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bill/support-opposition")]
        public async Task<IActionResult> GetBillSupportOpposition()
        {
            try
            {
                List<GetBillSupportsOpositionsByIdResponse> result = new List<GetBillSupportsOpositionsByIdResponse>();
                GetAllBillsResponse bills = await _mediator.Send(new GetAllBillsRequest());
                foreach(Bill bill in bills.Bills){
                    try
                    {
                            GetBillSupportsOpositionsByIdResponse billSuportsOpositions = await _mediator.Send(new GetBillSupportsOpositionsByIdRequest(bill.Id));
                            result.Add(billSuportsOpositions);
                    }
                    catch (Exception ex) { }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}