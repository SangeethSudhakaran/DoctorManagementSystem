namespace DoctorManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maintain list of doctors
            List<Doctor> doctors = new List<Doctor>();
            int choice;

            do
            {
                Console.WriteLine("\nDoctor Management System");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Add Doctor Information");
                Console.WriteLine("2. Display All Doctors");
                Console.WriteLine("3. Search Doctor by Registration No");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice :");
                choice = int.Parse(Console.ReadLine());

                //Menu
                switch (choice)
                {
                    case 1:
                        AddNewDoctor(doctors);
                        break;
                    case 2:
                        DisplayAllDoctors(doctors);
                        break;
                    case 3:
                        SearchDoctor(doctors);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != 4);
        }


        //Adding a new doctor to the List
        static void AddNewDoctor(List<Doctor> doctors)
        {
            Doctor doctor = new Doctor();
            doctor.RegistrationNo = GetValidInput("Enter Registration No (7 digits): ", InputType.RegistrationNo);
            doctor.DoctorName = GetValidInput("Enter Doctor Name: ", InputType.AlphabetOnly);
            doctor.City = GetValidInput("Enter City: ", InputType.AlphabetOnly);
            doctor.AreaOfSpecialization = GetValidInput("Enter Area of Specialization: ", InputType.AlphabetOnly);
            doctor.ClinicAddress = GetValidInput("Enter Clinic Address: ", InputType.Alphanumeric);
            doctor.ClinicTimings = GetValidInput("Enter Clinic Timings: ", InputType.AlphanumericWithSpecialChars);
            doctor.ContactNo = GetValidInput("Enter Contact No (10 digits): ", InputType.ContactNo);

            doctors.Add(doctor);
            Console.WriteLine("Doctor information added successfully!");
        }


        //Display all doctors from the list
        static void DisplayAllDoctors(List<Doctor> doctors)
        {
            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors available.");
                return;
            }

            Console.WriteLine("\nDoctor Details:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor);
            }
        }

        //Search a doctor by Registration number
        static void SearchDoctor(List<Doctor> doctors)
        {
            string regNo = GetValidInput("Enter Registration No to search: ", InputType.RegistrationNo);

            var doctor = doctors.FirstOrDefault(d => d.RegistrationNo == regNo);

            if (doctor != null)
            {
                Console.WriteLine("Doctor found :");
                Console.WriteLine(doctor);
            }
            else
            {
                Console.WriteLine("Doctor not found with Registration No : " + regNo);
            }
        }

        //Validation part common method
        static string GetValidInput(string prompt, InputType type)
        {
            string input;
            bool isValid;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                isValid = ValidateInput(input, type);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            } while (!isValid);

            return input;
        }


        //Validating input data
        static bool ValidateInput(string input, InputType type)
        {
            switch (type)
            {
                case InputType.RegistrationNo:
                    return input.All(char.IsDigit) && input.Length == 7;
                case InputType.AlphabetOnly:
                    return input.All(char.IsLetter);
                case InputType.Alphanumeric:
                    return input.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
                case InputType.AlphanumericWithSpecialChars:
                    return input.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c));
                case InputType.ContactNo:
                    return input.All(char.IsDigit) && input.Length == 10;
                default:
                    return false;
            }
        }
    }


    //Enum used to validation static field
    enum InputType
    {
        RegistrationNo,
        AlphabetOnly,
        Alphanumeric,
        AlphanumericWithSpecialChars,
        ContactNo
    }
}
