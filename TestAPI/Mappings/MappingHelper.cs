using TestAPI.Dtos.Csv;
using TestAPI.Models;

namespace TestAPI.Mappings;

public static class MappingHelper
{
    public static Bill MapBillCsvDtoToModel(BillCsvDto billDto)
    {
        return new Bill
        {
            Id = billDto.id,
            Title = billDto.title,
            SponsorId = billDto.sponsor_id
        };
    }

    public static Person MapLegislatorCsvDtoToModel(PersonCsvDto legislatorDto)
    {
        return new Person
        {
            Id = legislatorDto.id,
            Name = legislatorDto.name
        };
    }

    public static Vote MapVoteCsvDtoToModel(VoteCsvDto voteDto)
    {
        return new Vote
        {
            Id = voteDto.id,
            BillId = voteDto.bill_id
        };
    }

    public static VoteResult MapVoteResultCsvDtoToModel(VoteResultCsvDto voteResultDto)
    {
        return new VoteResult
        {
            Id = voteResultDto.id,
            LegislatorId = voteResultDto.legislator_id,
            VoteId = voteResultDto.vote_id,
            VoteType = voteResultDto.vote_type == 1 ? VoteType.Yea : VoteType.Nay
        };
    }
}
