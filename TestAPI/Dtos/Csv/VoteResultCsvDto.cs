namespace TestAPI.Dtos.Csv
{
    public class VoteResultCsvDto
    {
        public int id { get; set; }
        public int legislator_id { get; set; }
        public int vote_id { get; set; }
        public string vote_type { get; set; }
    }
}