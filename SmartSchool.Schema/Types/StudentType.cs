namespace SmartSchool.Schema.Types
{
    public class StudentType
    {
        [IsProjected(true)]
        public long Id { get; set; }
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? MobileNo { get; set; }
    }
}
