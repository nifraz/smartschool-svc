﻿namespace SmartSchool.Graphql.Models
{
    public class AgeModel
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public string ShortString
        {
            get
            {
                return $"{Years}Y-{Months}M-{Days}D";
            }
        }
        public string LongString
        {
            get
            {
                return $"{Years} {nameof(Years)}, {Months} {nameof(Months)}, {Days} {nameof(Days)}";
            }
        }
    }
}