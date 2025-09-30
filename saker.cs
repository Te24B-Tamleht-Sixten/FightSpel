using System;

namespace Characters
{
	public class Fighter
	{

		public string title;
		public int reserveHealth;
		public int stregnth;
		public string name;
		public int hp;
		public int maxDamage;
		public int minDamage;
		public int chanseToClit; //ut av hundra
		public float clittModifyer; 
		public uint score;
		
		public void Heal()
		{
			if(reserveHealth>=100-hp)
			{
				reserveHealth-=100-hp;
				hp=100;
			}
				else
			{
				hp+=reserveHealth;
				reserveHealth=0;
			}
			Console.WriteLine("you curently have: " + hp + " hp and: " + reserveHealth + "reversve(press enter to continiue)");
			Console.ReadLine();
		}
		//public Fighter(string Name, int Hp, float MaxDamage, float MinDamage, int ChanseToClit, float ClittModifyer)
		public Fighter(int gamemode)
		{
			/*
			name=Name;
			hp=Hp;
			maxDamage=MaxDamage;
			minDamage=MinDamage;
			chanseToClit=ChanseToClit;
			clittModifyer=ClittModifyer;

			name="";
			hp=0;
			maxDamage=0.0f;
			minDamage=0.0f;
			chanseToClit=0;
			clittModifyer=0.0f;
			*/
			stregnth=gamemode;
			score=0;
			if(gamemode==0)
			{
				title="chemo patient";
				reserveHealth=0;
				hp=20;
				chanseToClit=7;
				clittModifyer=100.0f;
				maxDamage=3;
				minDamage=0;
			}
			else if(gamemode==1)
			{
				title="John";
				reserveHealth=1000;
				hp=100;
				chanseToClit=5;
				clittModifyer=3.0f;//ja den ska vara mer,
				maxDamage=15;
				minDamage=5;

			}
			else if(gamemode==2)
			{
				title="fighter";
				reserveHealth=150;
				hp=100;
				chanseToClit=7;
				clittModifyer=2.0f;
				maxDamage=20;
				minDamage=10;
			}
			else if(gamemode==3)
			{
				title="pro fighter";
				reserveHealth=150;
				hp=100;
				chanseToClit=7;
				clittModifyer=2.0f;
				maxDamage=20;
				minDamage=10;
			}
			else if(gamemode==4)
			{
				title="beast";
				reserveHealth=150;
				hp=1000;
				chanseToClit=7;
				clittModifyer=2.0f;
				maxDamage=200;
				minDamage=10;
			}
		}
		
	}
	
}

namespace GameFunctions
{
	public class Values
	{
	}
	public static class Funcs
	{
	static public string returnRandomName()
	{
		Random random = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
		int randomVal=random.Next(1, 21);
		if(randomVal==1)
			return "Mehmmed1";
		if(randomVal==2)
			return "Mehmmed2";
		if(randomVal==3)
			return "Mehmmed3";
		if(randomVal==4)
			return "Mehmmed4";
		if(randomVal==5)
			return "Mehmmed5";
		if(randomVal==6)
			return "Mehmmed6";
		if(randomVal==7)
			return "Mehmmed7";
		if(randomVal==8)
			return "Mehmmed8";
		if(randomVal==9)
			return "Mehmmed9";
		if(randomVal==10)
			return "Mehmmed10";
		if(randomVal==11)
			return "Mehmmed11";
		if(randomVal==12)
			return "Mehmmed12";
		if(randomVal==13)
			return "Mehmmed13";
		if(randomVal==14)
			return "Mehmmed14";
		if(randomVal==15)
			return "Mehmmed15";
		if(randomVal==16)
			return "Mehmmed16";
		if(randomVal==17)
			return "Mehmmed17";
		if(randomVal==18)
			return "Mehmmed18";
		if(randomVal==19)
			return "Mehmmed19";
		return "Mehmmed20";
	}
		
	static public int question(int maxNum, int minNum)
	{
		string ans="";
		while(true)
		{
			int result;
			try
			{
				result = Int32.Parse(Console.ReadLine());
				if(result>maxNum)
					Console.WriteLine("it dosent fit\n");
				else if(result<minNum)
					Console.WriteLine("To small to fit");
			}
			catch(FormatException e)
			{
				Console.WriteLine("wrong input" + e);
			}
			ans=Console.ReadLine();
			if(ans=="1")
				return 1;
			if(ans=="2")
				return 2;
		}
	}
	static public int question()
	{
		string ans="";
		while(true)
		{
			ans=Console.ReadLine();
			if(ans=="1")
				return 1;
			if(ans=="2")
				return 2;
		}
	}
	static public void saveGame(Characters.Fighter charToSave)
	{
		/*
		public string title;
		public int reserveHealth;
		public int stregnth;
		public string name;
		public int hp;
		public int maxDamage;
		public int minDamage;
		public int chanseToClit; //ut av hundra
		public float clittModifyer; 
		public uint score;
		*/
		List<string> data = new List<string>();
		data.Add(charToSave.title);
		data.Add("\n");
		data.Add(charToSave.reserveHealth.ToString());
		data.Add("\n");
		data.Add(charToSave.stregnth.ToString());
		data.Add("\n");
		data.Add(charToSave.name);
		data.Add("\n");
		data.Add(charToSave.hp.ToString());
		data.Add("\n");
		data.Add(charToSave.maxDamage.ToString());
		data.Add("\n");
		data.Add(charToSave.minDamage.ToString());
		data.Add("\n");
		data.Add(charToSave.chanseToClit.ToString());
		data.Add("\n");
		data.Add(charToSave.clittModifyer.ToString());
		data.Add("\n");
		data.Add(charToSave.score.ToString());
		data.Add("\n");
		
		if(File.Exists(@".\SaveFile.gooning"))
		{
		    File.Delete(@".\SaveFile.gooning");
		}

		string dataStr = string.Join("", data.ToArray());
		File.WriteAllText("SaveFile.gooning", dataStr);
    	System.Environment.Exit(1);
	}
	static public bool hasPlayedBefore()
	{
		return false;
	}
	static public void tutorial()
	{
		Console.WriteLine("fråga Sixten or sum jag orkar inte försklara");	
	}
	}
}

