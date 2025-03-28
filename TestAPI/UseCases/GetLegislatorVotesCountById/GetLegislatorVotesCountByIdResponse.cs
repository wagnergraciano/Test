    namespace TestAPI.UseCases.GetLegislatorVotesCountById;

    public class GetLegislatorVotesCountByIdResponse
    {
        public int LegislatorId { get; set; }
        public string LegislatorName { get; set; }
        public int BillsSupported { get; set; }
        public int BillsOpposed { get; set; }
    }