using MediatR;

namespace TestAPI.UseCases.GetAllLegislators
{
    public class GetAllLegislatorsRequest : IRequest<GetAllLegislatorsResponse>
    {
        public GetAllLegislatorsRequest()
        {
        }
    }
}