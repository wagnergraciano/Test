using MediatR;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.UseCases.GetAllBills
{
    public class GetAllBillsHandler : IRequestHandler<GetAllBillsRequest, GetAllBillsResponse>
    {
        private readonly List<Bill> _bills;

        // Injeção de dependência para o banco de dados ou serviço
        public GetAllBillsHandler(VotingService votingService)
        {
            this._bills = votingService.Bills;
        }

        public async Task<GetAllBillsResponse> Handle(GetAllBillsRequest request, CancellationToken cancellationToken)
        {
            return new GetAllBillsResponse
            {
                Bills = this._bills
            };
        }
    }
}