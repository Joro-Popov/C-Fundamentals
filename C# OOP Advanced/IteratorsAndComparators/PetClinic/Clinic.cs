using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic : IEnumerable<Pet>
{
    private int roomsCount;
    private int initialIndex;

    public Clinic(string name, int roomsCount)
    {
        this.Name = name;
        this.RoomsCount = roomsCount;
        this.Rooms = new Pet[roomsCount];
        this.initialIndex = (this.RoomsCount) / 2;
    }

    public int RoomsCount
    {
        get { return this.roomsCount; }
        private set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            this.roomsCount = value;
        }
    }

    public string Name { get; private set; }

    public Pet[] Rooms { get; private set; }

    public bool AddPet(Pet pet)
    {
        int currentRoom = this.initialIndex;

        for (int i = 0; i <= this.Rooms.Length; i++)
        {
            if (i % 2 != 0)
            {
                currentRoom -= i;
            }
            else
            {
                currentRoom += i;
            }

            if (this.Rooms[currentRoom] == null)
            {
                this.Rooms[currentRoom] = pet;
                return true;
            }
           
        }
        return false;
    }

    public bool ReleasePet()
    {
        foreach (var p in this)
        {
            if (p != null)
            {
                int currentIndex = Array.IndexOf(this.Rooms, p);
                this.Rooms[currentIndex] = null;
                return true;
            }
        }
        return false;
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        for (int i = 0; i < this.Rooms.Length; i++)
        {
            int index = (this.initialIndex + i) % this.Rooms.Length;

            yield return this.Rooms[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Rooms.GetEnumerator();
    }
}
