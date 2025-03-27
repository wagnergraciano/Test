namespace TestAPI.Models
{
    public class VoteResult
    {
        public int Id { get; set; }
        public int LegislatorId { get; set; }
        public Person Legislator { get; set; }
        public int VoteId { get; set; }
        public Vote Vote { get; set; }
        public VoteType VoteType { get; set; }
    }

    public enum VoteType{
        Yea = 1,
        Nay = 2
    }
}