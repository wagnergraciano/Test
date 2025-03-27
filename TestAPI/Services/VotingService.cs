using CsvHelper;
using TestAPI.Models;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Dtos.Csv;
using TestAPI.Mappings;

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
            LoadAndConvertDataFromCsv();
        }

        private void LoadAndConvertDataFromCsv()
        {
            //Could apply builder pattern
            //Should use dbContext with EFCore
            using (var reader = new StreamReader("Assets/legislators_(2).csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<PersonCsvDto> people = csv.GetRecords<PersonCsvDto>().ToList();
                foreach (PersonCsvDto personDto in people){
                    Person legislator = MappingHelper.MapLegislatorCsvDtoToModel(personDto);
                    _legislators.Add(legislator);
                }
            }

            using (var reader = new StreamReader("Assets/bills_(2).csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<BillCsvDto> bills = csv.GetRecords<BillCsvDto>().ToList();

                foreach(BillCsvDto billDto in bills){
                    Bill bill = MappingHelper.MapBillCsvDtoToModel(billDto);
                    bill.PrimarySponsor = _legislators.FirstOrDefault(x => x.Id.Equals(billDto.sponsor_id));
                    _bills.Add(bill);
                }
            }            

            using (var reader = new StreamReader("Assets/votes_(2).csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<VoteCsvDto> votes = csv.GetRecords<VoteCsvDto>().ToList();
                foreach(VoteCsvDto voteDto in votes){
                    Vote vote = MappingHelper.MapVoteCsvDtoToModel(voteDto);
                    vote.Bill = _bills.FirstOrDefault(x  => x.Id.Equals(vote.BillId));
                    _votes.Add(vote);
                }
            }

            using (var reader = new StreamReader("Assets/vote_results_(2).csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<VoteResultCsvDto> voteResults = csv.GetRecords<VoteResultCsvDto>().ToList();
                foreach(VoteResultCsvDto voteResultDto in voteResults){
                    VoteResult voteResult = MappingHelper.MapVoteResultCsvDtoToModel(voteResultDto);
                    voteResult.Legislator = _legislators.FirstOrDefault(x => x.Id.Equals(voteResult.LegislatorId));
                    voteResult.Vote = _votes.FirstOrDefault(x => x.Id.Equals(voteResult.VoteId));
                    _voteResults.Add(voteResult);
                }
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

            string primarySponsor = bill.PrimarySponsor.Name;

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