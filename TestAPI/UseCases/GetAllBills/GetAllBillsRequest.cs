using MediatR;

namespace TestAPI.UseCases.GetAllBills
{
    public class GetAllBillsRequest : IRequest<GetAllBillsResponse>
    {
        public GetAllBillsRequest()
        {
        }
    }
}