using TestAPI.Models;

namespace TestAPI.UseCases.GetAllBills;

    public class GetAllBillsResponse
    {
        public List<Bill> Bills { get; set; }
    }