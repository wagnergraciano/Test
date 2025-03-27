namespace TestAPI.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SponsorId { get; set; }
        public Person PrimarySponsor { get; set; }
    }
}