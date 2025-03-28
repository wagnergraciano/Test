    namespace TestAPI.UseCases.GetBillSupportsOpositionsById;

    public class GetBillSupportsOpositionsByIdResponse
    {
        public int BillId { get; set; }
        public string Title { get; set; }
        public string PrimarySponsor { get; set; }
        public int LegislatorsSupported { get; set; }
        public int LegislatorsOpposed { get; set; }
    }