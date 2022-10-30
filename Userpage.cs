using System;
using System.Collections.Generic;

namespace StoneClinicApi.Models
{
    public partial class Userpage
    {
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; } = null!;
    }
}
