using System;
using Characters;
using GameFunctions;


class FightSpel
{
	public static void gameLoop(int gameMode, bool hasplayedbefore)
	{	

		Fighter mainCharacter; //Fighter{"", 0, 0.0f, 0.0f, 0, 0.0f};
		
		if(hasplayedbefore==false) //ladda in saves / skapa nya saves
		{
			if(gameMode==1)
				mainCharacter = new Fighter(1); 
			else
				mainCharacter = new Fighter(2); 
			Console.WriteLine("Vilket namn ska din fighter ha?");
			mainCharacter.name=Console.ReadLine();
		}
		else
		{

			if(gameMode==1)
				mainCharacter = new Fighter(1);
			else
				mainCharacter = new Fighter(2);
		/*
		 * alla variables som ska laddas in
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
			string[] data;// ser ut som detta för säkerheten
			if(File.Exists(@".\SaveFile.gooning"))
			{
				data=File.ReadAllLines(@".\SaveFile.gooning");
				if(data==null)
				{
					Console.WriteLine("couldnt read in existing savefile, gamemode default loaded(enter to continue)");
				}
				else
				{
					bool error=false;

					string title; //0
					int reserveHealth=0; //1
					int stregnth=0; //2
					string name; //3
					int hp=0; //4
					int maxDamage=0; //5
					int minDamage=0; //6
					int chanseToClit=0; //7
					float clittModifyer=0.0f; //8
					uint score=0; //9

					title=data[0];

					try{reserveHealth=Int32.Parse(data[1]);} // try catch ifall det är fel med sparfilen
					catch{	error=true;}

					try{stregnth=Int32.Parse(data[2]);}
					catch{	error=true;}
					
					name=data[3];

					try{hp=Int32.Parse(data[4]);}
					catch{	error=true;}

					try{maxDamage=Int32.Parse(data[5]);}
					catch{	error=true;}

					try{minDamage=Int32.Parse(data[6]);}
					catch{	error=true;}

					try{chanseToClit=Int32.Parse(data[7]);}
					catch{	error=true;}

					try{clittModifyer=float.Parse(data[8]);}
					catch{	error=true;}

					try{score=UInt32.Parse(data[9]);}
					catch{	error=true;}

					if(error)
					{
						Console.WriteLine("corrupted savefile!! delting it ngl tbh");
						File.Delete(@".\SaveFile.gooning");
					}
					else
					{
						mainCharacter.title=title;
						mainCharacter.reserveHealth=reserveHealth;
						mainCharacter.stregnth=stregnth;
						mainCharacter.name=name;
						mainCharacter.hp=hp;
						mainCharacter.maxDamage=maxDamage;
						mainCharacter.minDamage=minDamage;
						mainCharacter.chanseToClit=chanseToClit;
						mainCharacter.clittModifyer=clittModifyer;
						mainCharacter.score=score;

					
						Console.WriteLine("Do you want to heal[1](you currently have: " + mainCharacter.hp + "and: " + mainCharacter.reserveHealth + " worth of reservse health), or do you want to go directly[2]?");
						if(Funcs.question()==1)
						{
							mainCharacter.Heal();
						}
					}
				}
			}
			else
			{
				Console.WriteLine("SAvefile doesent exist, gamemode default loaded(enter to continue)");
				Console.ReadLine();
			}
		}


		Fighter enemy;
		Random random = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

		while(true)
		{
		if(mainCharacter.reserveHealth<=0 && mainCharacter.hp <=0)
		{
			Console.Clear();
			Console.WriteLine("you dead gng, your score were: " + mainCharacter.score + " start new game or enjoy that number(enter to continiue)");
			Console.ReadLine();
     		System.Environment.Exit(1);
		}
		if(gameMode==1)
			enemy = new Fighter(random.Next()%3);
		else if(gameMode==2)
			enemy = new Fighter((random.Next()%3)+1);
		else	//detta kan inte ske men csharps lanugae server blir gnällig utan
			enemy = new Fighter(0);

		enemy.name=Funcs.returnRandomName();

		Console.Clear();
		Console.WriteLine("Ok lets start fighitng! You will fight " + enemy.title + " " + enemy.name + " (enter to start)");
		Console.ReadLine();
		while(!(enemy.hp<0 || mainCharacter.hp<0))
		{
			int damageDone=0;
			if(random.Next(100)<=mainCharacter.chanseToClit)
				damageDone=(int)((float)random.Next(mainCharacter.minDamage, mainCharacter.maxDamage)*mainCharacter.clittModifyer);
			else
				damageDone=random.Next(mainCharacter.minDamage, mainCharacter.maxDamage);
			enemy.hp=enemy.hp-damageDone;

		if(enemy.hp<=0)
		{
			Console.WriteLine("Seams like you won! Do you want to save yor game[1], fight again![2]");
			if(Funcs.question()==1)
				Funcs.saveGame(mainCharacter);
			else
			{
				Console.WriteLine("Do you want to heal[1](you currently have: " + mainCharacter.hp + "and: " + mainCharacter.reserveHealth + " worth of reservse health), or do you want to go directly[2]?");
				if(Funcs.question()==1)
				{
					mainCharacter.Heal();
				}
			}
			mainCharacter.score+=(uint)gameMode;//dubla poäng för hardmode
			break;
		}

			Console.WriteLine(mainCharacter.name + " did " + damageDone + " amout of damage!");
			Console.WriteLine(enemy.name + ": auch!\n");
			
			if(random.Next(100)<=enemy.chanseToClit)
				damageDone=(int)((float)random.Next(enemy.minDamage, enemy.maxDamage)*enemy.clittModifyer);
			else
				damageDone=random.Next(enemy.minDamage, enemy.maxDamage);
			mainCharacter.hp=mainCharacter.hp-damageDone;

			Console.WriteLine(enemy.name + " did " + damageDone);
			Console.WriteLine(mainCharacter.name + ": auch!\n");
		
		if(mainCharacter.hp<=0)
		{
			Console.WriteLine("seams like you lost! Do you want to save yor game[1], retry[2]");
			if(mainCharacter.hp<=0 && mainCharacter.reserveHealth<=0)
			{
				Console.Clear();
				Console.WriteLine("you dead, js put the fires in the bag, you got: " + mainCharacter.score);
				Console.ReadLine();
    			System.Environment.Exit(1);
			}
			if(Funcs.question()==1)
				Funcs.saveGame(mainCharacter);
			else
			{
				Console.WriteLine("You have to heal(you currently have: " + mainCharacter.hp + " and: " + mainCharacter.reserveHealth + " worth of reservse health)");
					if(mainCharacter.reserveHealth==0)
					{
						Console.Clear();
						Console.WriteLine("you dead, js put the fires in the bag, you got: " + mainCharacter.score);
						Console.ReadLine();
    					System.Environment.Exit(1);
					}
					mainCharacter.Heal();
			}
			break;
		}
			Thread.Sleep(500);
		}
	}
	}

	public static void Main()
	{

		Console.WriteLine("WELCOME!! To the Serek MMA coaching, do you want the tutorial?\n[1]: yes, [2]:no");
		if(Funcs.question()==1)
			Funcs.tutorial();


		Console.WriteLine("do you want to start a new character?\n[1]yes[2]no\n");
		if(Funcs.question()==1)
		{
			Console.WriteLine(" what difficulty do yuo want? easy[1] hard[2]");
			if(Funcs.question()==1)
				gameLoop(1, false);
			else
				gameLoop(2, false);
		}
		else
		{
			Console.WriteLine(" what difficulty do yuo want? easy[1] hard[2]");
			if(Funcs.question()==1)
				gameLoop(1, true);
			else
				gameLoop(2, true);
		}
	}
}
