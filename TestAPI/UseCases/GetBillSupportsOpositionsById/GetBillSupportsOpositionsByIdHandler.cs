using MediatR;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.UseCases.GetBillSupportsOpositionsById
{
    public class GetBillSupportsOpositionsByIdHandler : IRequestHandler<GetBillSupportsOpositionsByIdRequest, GetBillSupportsOpositionsByIdResponse>
    {
        private readonly List<Bill> _bills;
        private readonly List<VoteResult> _voteResults;

        // Injeção de dependência para o banco de dados ou serviço
        public GetBillSupportsOpositionsByIdHandler(VotingService votingService)
        {
            this._bills = votingService.Bills;
            this._voteResults = votingService.VoteResults;
        }

        public async Task<GetBillSupportsOpositionsByIdResponse> Handle(GetBillSupportsOpositionsByIdRequest request, CancellationToken cancellationToken)
        {
            int billId = request.BillId;
            Bill bill = _bills.FirstOrDefault(b => b.Id == billId);
            if (bill == null)
                throw new ArgumentException("Bill not found.");

            List<VoteResult> billVotes = _voteResults.Where(vr => vr.Vote.BillId == billId).ToList();
            int billsSupported = billVotes.Count(vr => vr.VoteType == VoteType.Yea);
            int billsOpposed = billVotes.Count(vr => vr.VoteType == VoteType.Nay);

            string primarySponsor = bill.PrimarySponsor.Name;

            return new GetBillSupportsOpositionsByIdResponse
            {
                BillId = billId,
                Title = bill.Title,
                PrimarySponsor = primarySponsor,
                LegislatorsSupported = billsSupported,
                LegislatorsOpposed = billsOpposed
            };
        }
    }
}