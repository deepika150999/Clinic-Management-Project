using System;
using System.Collections.Generic;

namespace StoneClinicApi.Models
{
    public partial class PatientDetail
    {
        public PatientDetail()
        {
            AppointmentDetails = new HashSet<AppointmentDetail>();
        }

        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
    }
}
