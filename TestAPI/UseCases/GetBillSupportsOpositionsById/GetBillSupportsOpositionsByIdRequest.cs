using MediatR;

namespace TestAPI.UseCases.GetBillSupportsOpositionsById
{
    public class GetBillSupportsOpositionsByIdRequest : IRequest<GetBillSupportsOpositionsByIdResponse>
    {
        public int BillId { get; set; }

        public GetBillSupportsOpositionsByIdRequest(int billId)
        {
            BillId = billId;
        }
    }
}