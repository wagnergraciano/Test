using MediatR;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.UseCases.GetLegislatorVotesCountById
{
    public class GetLegislatorVotesCountByIdHandler : IRequestHandler<GetLegislatorVotesCountByIdRequest, GetLegislatorVotesCountByIdResponse>
    {
        private readonly List<Person> _legislators;
        private readonly List<VoteResult> _voteResults;

        // Injeção de dependência para o banco de dados ou serviço
        public GetLegislatorVotesCountByIdHandler(VotingService votingService)
        {
            this._legislators = votingService.Legislators;
            this._voteResults = votingService.VoteResults;
        }

        public async Task<GetLegislatorVotesCountByIdResponse> Handle(GetLegislatorVotesCountByIdRequest request, CancellationToken cancellationToken)
        {
            int legislatorId = request.LegislatorId;
            Person legislator = _legislators.FirstOrDefault(l => l.Id == legislatorId);
            if (legislator == null)
                throw new ArgumentException("Legislator not found.");

            List<VoteResult> legislatorVotes = _voteResults.Where(vr => vr.LegislatorId == legislatorId).ToList();

            int billsSupported = legislatorVotes.Count(vr => vr.VoteType == VoteType.Yea);
            int billsOpposed = legislatorVotes.Count(vr => vr.VoteType == VoteType.Nay);

            return new GetLegislatorVotesCountByIdResponse
            {
                LegislatorId = legislatorId,
                LegislatorName = legislator.Name,
                BillsSupported = billsSupported,
                BillsOpposed = billsOpposed
            };
        }
    }
}