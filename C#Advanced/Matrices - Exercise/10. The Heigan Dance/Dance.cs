using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dance
{
    public static void DamageSpell(int[][] chamber, int spellRow, int spellCol)
    {
        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            for (int colIndex = 0; colIndex < 3; colIndex++)
            {
                if ((spellRow - 1) + rowIndex <= 14 && (spellRow - 1) + rowIndex >= 0 &&
                    (spellCol - 1) + colIndex <= 14 && (spellCol - 1) + colIndex >= 0)
                {
                    chamber[spellRow - 1 + rowIndex][spellCol - 1 + colIndex] = 1;
                }
            }
        }
    }
    public static bool IsGameOver(int playerPoints, decimal HeiganPoints, string spell, int playerRow, int playerCol)
    {
        if (playerPoints <= 0 || HeiganPoints <= 0)
        {
            if (spell == "Cloud")
            {
                spell = "Plague Cloud";
            }

            Console.WriteLine(HeiganPoints > 0
                ? $"Heigan: {HeiganPoints:F2}"
                : $"Heigan: Defeated!");

            Console.WriteLine(playerPoints > 0
                ? $"Player: {playerPoints}"
                : $"Player: Killed by {spell}");

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");

            return true;
        }
        return false;
    }
    public static void Main()
    {
        decimal damageToHeiganOnEachTurn = decimal.Parse(Console.ReadLine());
        int playerPoints = 18500;
        decimal HeiganPoints = 3000000.0m;
        int playerRow = 7;
        int playerCol = 7;
        bool isCloudActive = false;
        string spell = string.Empty;
        int[][] chamber = new int[15][];

        chamber = chamber.Select(A => A = new int[15]).ToArray();

        while (true)
        {
            if (isCloudActive)
            {
                playerPoints -= 3500;
                isCloudActive = false;
            }

            HeiganPoints -= damageToHeiganOnEachTurn;

            if (IsGameOver(playerPoints, HeiganPoints, spell, playerRow, playerCol)) break;

            List<string> HeiganAttack = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            spell = HeiganAttack[0];
            int spellRow = int.Parse(HeiganAttack[1]);
            int spellCol = int.Parse(HeiganAttack[2]);
            int damageToPlayer = 0;

            switch (spell)
            {
                case "Cloud": damageToPlayer = 3500; break;
                case "Eruption": damageToPlayer = 6000; break;
            }

            DamageSpell(chamber, spellRow, spellCol);

            if (spellRow == playerRow || spellRow + 1 == playerRow || spellRow - 1 == playerRow ||
                spellCol == playerCol || spellCol + 1 == playerCol || spellCol - 1 == playerCol)
            {
                if (playerRow - 1 >= 0 && chamber[playerRow - 1][playerCol] == 0 && playerRow > 0) playerRow--;

                else if (playerCol + 1 <= 14 && chamber[playerRow][playerCol + 1] == 0 && playerCol < 14) playerCol++;

                else if (playerRow + 1 <= 14 && chamber[playerRow + 1][playerCol] == 0 && playerRow < 14) playerRow++;

                else if (playerCol - 1 >= 0 && chamber[playerRow][playerCol - 1] == 0 && playerCol > 0) playerCol--;

                else
                {
                    playerPoints -= damageToPlayer;

                    if (IsGameOver(playerPoints, HeiganPoints, spell, playerRow, playerCol)) break;
                    if (spell == "Cloud") isCloudActive = true;
                }
            }
            if (IsGameOver(playerPoints, HeiganPoints, spell, playerRow, playerCol)) break;

            chamber = chamber.Select(A => A = new int[15]).ToArray();
        }
    }
}
