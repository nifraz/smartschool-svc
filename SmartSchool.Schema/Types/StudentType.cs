namespace SmartSchool.Schema.Types
{
    public class StudentType
    {
        public Guid Id { get; set; }
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
    }
}
