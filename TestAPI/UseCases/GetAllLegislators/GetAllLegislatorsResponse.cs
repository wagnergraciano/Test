using TestAPI.Models;

namespace TestAPI.UseCases.GetAllLegislators;

    public class GetAllLegislatorsResponse
    {
        public List<Person> Legislators { get; set; }
    }