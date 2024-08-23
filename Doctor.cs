namespace DoctorManagement
{
    public class Doctor
    {
        public string RegistrationNo { get; set; }
        public string DoctorName { get; set; }
        public string City { get; set; }
        public string AreaOfSpecialization { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicTimings { get; set; }
        public string ContactNo { get; set; }

        public override string ToString()
        {
            return $"Registration No       : {RegistrationNo}\n" +
                    $"Doctor Name           : {DoctorName}\n" +
                    $"City                  : {City}\n" +
                    $"Area of Specialization: {AreaOfSpecialization}\n" +
                    $"Clinic Address        : {ClinicAddress}\n" +
                    $"Clinic Timings        : {ClinicTimings}\n" +
                    $"Contact No            : {ContactNo}\n";
        }
    }
}
