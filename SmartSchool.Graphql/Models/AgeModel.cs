namespace SmartSchool.Graphql.Models
{
    public class AgeModel
    {
        public int? Years { get; set; }
        public int? Months { get; set; }
        public int? Days { get; set; }

        public string? ShortString { get; set; }
        public string? LongString { get; set; }
    }
}
