using System;
using System.Collections.Generic;

namespace StoneClinicApi.Models
{
    public partial class AppointmentDetail
    {
        public int AppointmentNumber { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? Specialization { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public string? AppointmentDuration { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public virtual DoctorDetail? Doctor { get; set; }
        public virtual PatientDetail? Patient { get; set; }
    }
}
