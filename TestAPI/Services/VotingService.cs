using CsvHelper;
using TestAPI.Models;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Services
{
    public class VotingService
    {
        private readonly List<Bill> _bills;
        private readonly List<Person> _legislators;
        private readonly List<Vote> _votes;
        private readonly List<VoteResult> _voteResults;

        public VotingService()
        {
            _bills = new List<Bill>();
            _legislators = new List<Person>();
            _votes = new List<Vote>();
            _voteResults = new List<VoteResult>();
            LoadDataFromCsv();
        }

        private void LoadDataFromCsv()
        {
            // Loading Bills
            using (var reader = new StreamReader("Bills.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Bill>().ToList();
                _bills.AddRange(records);
            }

            // Loading Legislators
            using (var reader = new StreamReader("Legislators.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Person>().ToList();
                _legislators.AddRange(records);
            }

            // Loading Votes
            using (var reader = new StreamReader("Votes.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Vote>().ToList();
                _votes.AddRange(records);
            }

            // Loading VoteResults
            using (var reader = new StreamReader("VoteResults.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<VoteResult>().ToList();
                _voteResults.AddRange(records);
            }
        }

        public async Task<LegislatorBillSupportOpposition> GetLegislatorSupportOppositionAsync(int legislatorId)
        {
            Person legislator = _legislators.FirstOrDefault(l => l.Id == legislatorId);
            if (legislator == null)
                throw new ArgumentException("Legislator not found.");

            List<VoteResult> legislatorVotes = _voteResults.Where(vr => vr.LegislatorId == legislatorId).ToList();

            int billsSupported = legislatorVotes.Count(vr => vr.VoteType == VoteType.Yea);
            int billsOpposed = legislatorVotes.Count(vr => vr.VoteType == VoteType.Nay);

            return new LegislatorBillSupportOpposition
            {
                LegislatorId = legislatorId,
                LegislatorName = legislator.Name,
                BillsSupported = billsSupported,
                BillsOpposed = billsOpposed
            };
        }

        public async Task<BillSupportOppositionResult> GetBillSupportOppositionAsync(int billId)
        {
            Bill bill = _bills.FirstOrDefault(b => b.Id == billId);
            if (bill == null)
                throw new ArgumentException("Bill not found.");

            List<VoteResult> billVotes = _voteResults.Where(vr => vr.Vote.BillId == billId).ToList();
            int billsSupported = billVotes.Count(vr => vr.VoteType == VoteType.Yea);
            int billsOpposed = billVotes.Count(vr => vr.VoteType == VoteType.Nay);

            string primarySponsor = bill.PrimarySponsor;

            return new BillSupportOppositionResult
            {
                BillId = billId,
                Title = bill.Title,
                PrimarySponsor = primarySponsor,
                LegislatorsSupported = billsSupported,
                LegislatorsOpposed = billsOpposed
            };
        }
    }

    public class LegislatorBillSupportOpposition
    {
        public int LegislatorId { get; set; }
        public string LegislatorName { get; set; }
        public int BillsSupported { get; set; }
        public int BillsOpposed { get; set; }
    }

    public class BillSupportOppositionResult
    {
        public int BillId { get; set; }
        public string Title { get; set; }
        public string PrimarySponsor { get; set; }
        public int LegislatorsSupported { get; set; }
        public int LegislatorsOpposed { get; set; }
    }
}