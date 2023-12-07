using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;
using System.Linq;

[Component(PropertyGuid = "4134c54a4b204e3019a0dc9c13e79323fde47192")]
public class Global : Component
{

	public static int currentLvl = 1;
	public static int WinnerPoints = 11000;
	public static int ChosenTournamentId = -1;
	public static string FirstName = "";
	public static string SecondName = "";
	public static string ChoosenTeam = "";
	public static string NextEnemyTeam = "";
	public static Dictionary<string, Team> teamList = new Dictionary<string, Team>();
	public static List<Tournament> tournamentList = new List<Tournament>();
	public static DateTime Date = new DateTime(2015, 12, 29);
	public static List<string> nickNamesList = new List<string>(); // По идее можно удалить после испольщования



	private void Init()
	{
		//shuffle
		System.Random rand = new System.Random();
		int n = Global.nickNamesList.Count;
		while (n > 1)
		{
			n--;
			int k = rand.Next(n + 1);
			string value = Global.nickNamesList[k];
			Global.nickNamesList[k] = Global.nickNamesList[n];
			Global.nickNamesList[n] = value;

		}
	}
}
public partial class Team //Класс создания команды
{
	public int power;
	public string name;
	public int money;
	public int complexity;
	public Dictionary<string, KiberKotleta> teammatesList = new Dictionary<string, KiberKotleta>();

	public Team(int powerMin, int powerMax)
	{
		List<string> positions = new List<string>
		{
			"HS",
			"SS",
			"H",
			"C",
			"M"
		};
		System.Random rnd = new System.Random();
		for (int i = 0; i < 5; i++)
		{
			int powerMate = rnd.Next(powerMin, powerMax);
			KiberKotleta gamer = new KiberKotleta(positions[i], powerMate, i);
			teammatesList.Add(gamer.name, gamer);
		}
		this.power = countPowerTeam();
		this.name = Database.teamNames[Global.teamList.Count + 1];
		this.money = rnd.Next(0, 1000);
		this.complexity = countComplexity(this.money);
	}
	public int countPowerTeam()
	{
		int power = 0;
		for (int i = 0; i < teammatesList.Count; i++)
			power += teammatesList[teammatesList.ElementAt(i).Key].power;
		return power / 5;
	}
	public int countComplexity(int money) // Здесь могут оказаться ошибки
	{
		int complexity = 0;
		for (int i = 0; i < 5; i++)
		{
			complexity += teammatesList[teammatesList.ElementAt(i).Key].power - teammatesList[teammatesList.ElementAt(i).Key].age - money;
		}
		return complexity / 5;
	}
}
public partial class KiberKotleta //Класс создания киберкотлет
{
	public string name;
	public int power;
	public string position;
	public int exp;
	public int kda;
	public int pool;
	public int laining;
	public int laningGold;
	public int teamFight;//как часто в боях
	public int age = 14;
	public int form;
	public int salary = 0;
	public KiberKotleta(string position, int power, int iterator)
	{
		this.name = CreateName(iterator);
		this.power = power;
		this.position = position;
		this.salary = countSalary();
	}
	public int CreateAbilities()
	{
		System.Random rnd = new System.Random();
		int power = rnd.Next(0, 100);
		return power;
	}
	public string CreateName(int iterator)
	{
		string a = Global.nickNamesList.ElementAt(Global.teamList.Count * 5 + iterator);
		return a;
	}
	public int countSalary()//зарплата
	{
		int kf = 10;
		return power * kf;
	}

}

public partial class Tournament
{
	public string name;
	public int power;
	public List<string> tournamentTeamList = new List<string>();
	public Dictionary<string, string> teamsPairsList = new Dictionary<string, string>();
	public List<DateTime> tournamentDaysList = new List<DateTime>();
	public Tournament(int razmer, int complexity)
	{
		System.Random rnd = new System.Random();
		this.name = Database.tournamentNames[rnd.Next(1, 75)];
		createTournamentTeamsList(razmer, complexity);
		countPower();
		createTournamentDays(razmer);
	}
	public void createTournamentTeamsList(int razmer, int complexity)
	{
		for (int i = 0; i < razmer; i++)
		{
			if (Global.teamList.ElementAt(i).Value.power > complexity - 10 && Global.teamList.ElementAt(i).Value.power < complexity + 10)
			{
				tournamentTeamList.Add(Global.teamList.ElementAt(i).Key);
				if (Global.teamList.ElementAt(i).Key == Global.ChoosenTeam)
				{
					tournamentTeamList.Remove(Global.teamList.ElementAt(i).Key);
					razmer++;
				}
			}
			else { razmer++; }
		}
	}
	public void countPower()
	{
		foreach (string teamKey in tournamentTeamList)
		{
			this.power += Global.teamList[teamKey].power;
		}
		this.power /= tournamentTeamList.Count;
	}
	public string findEnemyTeam()
	{
		foreach (KeyValuePair<string, string> teampair in teamsPairsList)
		{
			if (teampair.Key == Global.ChoosenTeam)
			{
				return teampair.Value;
			}
			else if (teampair.Value == Global.ChoosenTeam)
			{
				return teampair.Key;
			}
		}
		return "";

	}
	public void createGrid()
	{
		for (int i = 0; i < tournamentTeamList.Count; i += 2)
			teamsPairsList.Add(tournamentTeamList.ElementAt(i), tournamentTeamList.ElementAt(i + 1));
	}
	public void createTournamentDays(int razmer)
	{
		System.Random rnd = new System.Random();
		DateTime temp = new DateTime();
		temp = Global.Date;
		for (int i = 0; i < Math.Sqrt(razmer); i++)
		{
			tournamentDaysList.Add(temp.AddDays(rnd.Next(1, 3)));
			temp = tournamentDaysList[i];
		}
	}
}
public partial class Fight
{

	public Fight(int tournamentId, Dictionary<string, string> previousPairs)
	{
		createNewRound(tournamentId, previousPairs);
	}
	public void createNewRound(int tournamentId, Dictionary<string, string> previousPairs)
	{
		for (int i = 0; i < previousPairs.Count; i++)
		{
			Global.tournamentList[tournamentId].tournamentTeamList.Remove(fightChance(previousPairs.ElementAt(i).Key, previousPairs.ElementAt(i).Value));

		}
		Global.tournamentList[tournamentId].teamsPairsList.Clear();
		if (Global.tournamentList[tournamentId].tournamentTeamList.Count != 1)
			Global.tournamentList[tournamentId].createGrid();
	}
	public string fightChance(string firstTeam, string secondTeam)
	{
		string loser = "";
		System.Random rnd = new System.Random();
		float kf = (Global.teamList[firstTeam].power + Global.teamList[secondTeam].power) / 100;
		float chanceToWinFirst = (Math.Max(Global.teamList[firstTeam].power, Global.teamList[secondTeam].power) / kf) * 100;
		int random = rnd.Next(0, 10000);
		if (Global.teamList[firstTeam].power >= Global.teamList[secondTeam].power)
		{
			if (random > chanceToWinFirst)
			{
				loser = firstTeam;
			}
			else if (random <= chanceToWinFirst)
			{
				loser = secondTeam;
			}
		}
		else
		{
			if (random < chanceToWinFirst)
			{
				loser = firstTeam;
			}
			else if (random >= chanceToWinFirst)
			{
				loser = secondTeam;
			}
		}
		return loser;
	}
}
public partial class PreFight
{
	public PreFight()
	{

	}
	public void createMeta()
	{
		Dictionary<string, int[]> heroMetaDict = new Dictionary<string, int[]>();
		int[] arrayOfMeta = new int[4];

		System.Random rnd = new System.Random();
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				arrayOfMeta[j] = rnd.Next(0, 3);
				if (i == j)
					arrayOfMeta[j] = -1;
			}
			heroMetaDict.Add(i.ToString(), arrayOfMeta);
		}
	}
}
