using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ClinicManager
{
    private Dictionary<string, Clinic> clinics;
    private SortedSet<Pet> pets;

    public ClinicManager()
    {
        this.clinics = new Dictionary<string, Clinic>();
        this.pets = new SortedSet<Pet>();
    }

    public void CreatePet(List<string> args)
    {
        string name = args[0];
        int age = int.Parse(args[1]);
        string kind = args[2];

        Pet pet = new Pet(name, age, kind);

        this.pets.Add(pet);
    }

    public void CreateClinic(List<string> args)
    {
        string name = args[0];
        int roomsCount = int.Parse(args[1]);

        Clinic clinic = new Clinic(name, roomsCount);

        this.clinics[name] = clinic;
    }

    public bool Add(List<string>args)
    {
        string petName = args[0];
        string clinicName = args[1];
        
        Pet pet = this.pets.FirstOrDefault(p => p.Name.CompareTo(petName) == 0);

        Clinic clinic = this.clinics[clinicName];

        if (this.HasEmptyRooms(clinicName))
        {
            return clinic.AddPet(pet);
        }
        return false;
    }

    public bool Release(string clinicName)
    {
        Clinic clinic = this.clinics[clinicName];

        return clinic.ReleasePet();
    }

    public bool HasEmptyRooms(string clinicName)
    {
        Clinic clinic = this.clinics[clinicName];

        if (clinic.Rooms.Any(r => r == null))
        {
            return true;
        }
        return false;
    }

    public void Print(string clinicName)
    {
        Pet[] rooms = this.clinics[clinicName].Rooms;

        for (int counter = 0; counter < rooms.Length; counter++)
        {
            if (rooms[counter] == null)
            {
                Console.WriteLine("Room empty");
                continue;
            }
            Console.WriteLine(rooms[counter]);
        }
    }

    public void Print(string clinicName, int roomNum)
    {
        if (this.clinics[clinicName].Rooms[roomNum - 1] == null)
        {
            Console.WriteLine("Room empty");
        }
        else
        {
            Pet pet = this.clinics[clinicName].Rooms[roomNum - 1];
            Console.WriteLine(pet);
        }
    }
}
