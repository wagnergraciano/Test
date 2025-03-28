using MediatR;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.UseCases.GetAllLegislators
{
    public class GetAllLegislatorsHandler : IRequestHandler<GetAllLegislatorsRequest, GetAllLegislatorsResponse>
    {
        private readonly List<Person> _legislators;

        // Injeção de dependência para o banco de dados ou serviço
        public GetAllLegislatorsHandler(VotingService votingService)
        {
            this._legislators = votingService.Legislators;
        }

        public async Task<GetAllLegislatorsResponse> Handle(GetAllLegislatorsRequest request, CancellationToken cancellationToken)
        {
            return new GetAllLegislatorsResponse
            {
                Legislators = this._legislators
            };
        }
    }
}