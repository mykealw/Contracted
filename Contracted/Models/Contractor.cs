namespace Contracted.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
    }

    public class CompaniesContractorContractorViewModel : Contractor
    {
        public int CompaniesContractorId { get; set; }
    }
}