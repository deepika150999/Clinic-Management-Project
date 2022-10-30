using System;
using System.Collections.Generic;

namespace StoneClinicApi.Models
{
    public partial class DoctorDetail
    {
        public DoctorDetail()
        {
            AppointmentDetails = new HashSet<AppointmentDetail>();
        }

        public int DoctorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Specialization { get; set; }
        public string? VistingHours { get; set; }

        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
    }
}
