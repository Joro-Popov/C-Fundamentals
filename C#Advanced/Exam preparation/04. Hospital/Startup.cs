using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Hospital
{
    public class Patient
    {
        public string Doctor { get; set; }
        public string Name { get; set; }

        public Patient(string doctor, string name)
        {
            Name = name;
            Doctor = doctor;
        }
    }
   
    public class Startup
    {
        public static void SettlePatient(Dictionary<string, Patient[][]> departments, string department, Patient currentPatient)
        {
            for (int rowIndex = 0; rowIndex < 20; rowIndex++)
            {
                bool isSettled = false;

                for (int colIndex = 0; colIndex < 3; colIndex++)
                {
                    if (departments[department][rowIndex][colIndex] == null)
                    {
                        departments[department][rowIndex][colIndex] = currentPatient;
                        isSettled = true;
                        break;
                    }
                }
                if (isSettled)
                {
                    break;
                }
            }
        }

        public static void Main()
        {
            string input;

            var departments = new Dictionary<string, Patient[][]>();
            var doctors = new Dictionary<string, List<Patient>>();

            while ((input = Console.ReadLine()) != "Output")
            {
                List<string> tokens = input.Split().ToList();

                string department = tokens[0];
                string doctor = $"{tokens[1]} {tokens[2]}";
                string patientName = tokens[3];

                Patient currentPatient = new Patient(doctor, patientName);

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new Patient[20][];

                    departments[department] = departments[department]
                        .Select(w => w = new Patient[3])
                        .ToArray();
                }

                SettlePatient(departments, department, currentPatient);

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<Patient>();
                }
                doctors[doctor].Add(currentPatient);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                List<string> tokens = command.Split(' ').ToList();

                if (tokens.Count == 1)
                {
                    string depart = tokens[0];

                    for (int rowIndex = 0; rowIndex < 20; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < 3; colIndex++)
                        {
                            if (departments[depart][rowIndex][colIndex] != null)
                            {
                                Console.WriteLine(departments[depart][rowIndex][colIndex].Name);
                            }
                        }
                    }
                }
                else
                {
                    string doc = "";
                    string depart = "";
                    int room = 0;

                    try
                    {
                        room = int.Parse(tokens[1]);
                        depart = tokens[0];
                        Patient[] current = departments[depart][room - 1];

                        foreach (var patient in current.OrderBy(w => w.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    catch (Exception)
                    {
                        doc = $"{tokens[0]} {tokens[1]}";

                        foreach (var patient in doctors[doc].OrderBy(w => w.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }
            }
        }


    }
}
