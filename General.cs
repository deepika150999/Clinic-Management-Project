namespace TheStoneClinic.Models
{
    public class General
    {
        public class doc
        {
            public int DoctorId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Specialization { get; set; }
            public string? IDSpec { get; set; }
        }
        public class patient
        {
            public int PatientId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Gender { get; set; }
            public int? Age { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? IDSpec { get; set; }
        }
    }
}
