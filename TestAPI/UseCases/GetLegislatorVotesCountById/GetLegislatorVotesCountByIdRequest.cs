using MediatR;

namespace TestAPI.UseCases.GetLegislatorVotesCountById
{
    public class GetLegislatorVotesCountByIdRequest : IRequest<GetLegislatorVotesCountByIdResponse>
    {
        public int LegislatorId { get; set; }

        public GetLegislatorVotesCountByIdRequest(int legislatorId)
        {
            LegislatorId = legislatorId;
        }
    }
}