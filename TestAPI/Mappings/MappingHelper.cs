using TestAPI.Dtos.Csv;
using TestAPI.Models;

namespace TestAPI.Mappings;

public static class MappingHelper
{
    public static Bill MapBillDtoToModel(BillCsvDto billDto)
    {
        return new Bill
        {
            Id = billDto.id,
            Title = billDto.title,
            PrimarySponsor = billDto.PrimarySponsor
        };
    }

    public static Person MapLegislatorDtoToModel(LegislatorCsvDto legislatorDto)
    {
        return new Person
        {
            Id = legislatorDto.Id,
            Name = legislatorDto.Name
        };
    }

    public static Vote MapVoteDtoToModel(VoteCsvDto voteDto)
    {
        return new Vote
        {
            Id = voteDto.Id,
            BillId = voteDto.BillId
        };
    }

    public static VoteResult MapVoteResultDtoToModel(VoteResultCsvDto voteResultDto)
    {
        return new VoteResult
        {
            Id = voteResultDto.Id,
            LegislatorId = voteResultDto.LegislatorId,
            VoteId = voteResultDto.VoteId,
            VoteType = voteResultDto.VoteType
        };
    }
}
