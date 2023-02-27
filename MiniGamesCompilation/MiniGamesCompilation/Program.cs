using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MiniGamesCompilation
{
    internal class Program
    {
        //main
        static Random rnd = new Random();
        static bool listChecker(string choices, List<string> listChoices)
        {
            int found = listChoices.IndexOf(choices);
            if (found == -1)
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        static int rockPaperCount = 0, sosCount = 0, diceCount = 0;

        static void mainMenu()
        {
            Console.WriteLine("Mini Games Compilation Program");
            Console.WriteLine("************Games*************");
            Console.WriteLine("1. Rock, Paper, Scissors");
            Console.WriteLine("2. SOS");
            Console.WriteLine("3. Dice Game");
            Console.WriteLine("4. View top played games");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter the number your choice: ");
            int menuInput = Convert.ToInt32(Console.ReadLine());

            switch(menuInput)
            {
                case 1:
                    rockPaper();
                    break;
                case 2:
                    sos();
                    break;
                case 3:
                    diceGame();
                    break;
                case 4:
                    ranking();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }

        }

        //ranking
        static void ranking()
        {
            Console.WriteLine("Your number of played games are showede below:");
            if(rockPaperCount>sosCount && rockPaperCount>diceCount)
            {
                if (sosCount > diceCount)
                {
                    Console.WriteLine($"1. Rock Paper Scissors = {rockPaperCount}\n2. SOS = {sosCount}\n3. Dice Game = {diceCount}");

                }
                else if(sosCount < diceCount)
                {
                    Console.WriteLine($"1. Rock Paper Scissors = {rockPaperCount}\n2. Dice Game = {diceCount}\n3. SOS = {sosCount}");

                }

            }
            else if (sosCount > rockPaperCount && sosCount > diceCount)
            {
                if (rockPaperCount > diceCount)
                {
                    Console.WriteLine($"1. SOS = {sosCount}\n2. Rock Paper Scissors = {rockPaperCount}\n3. Dice Game = {diceCount}");

                }
                else if (rockPaperCount < diceCount)
                {
                    Console.WriteLine($"1. SOS = {sosCount}\n2. Dice Game = {diceCount}\n3. Rock Paper Scissors = {rockPaperCount}");

                }

            }
            else if (diceCount > rockPaperCount && sosCount < diceCount)
            {
                if (rockPaperCount > sosCount)
                {
                    Console.WriteLine($"1. Dice Game = {diceCount}\n2. Rock Paper Scissors = {rockPaperCount}\n3. SOS = {sosCount}");

                }
                else if (rockPaperCount < sosCount)
                {
                    Console.WriteLine($"1. Dice Game = {diceCount}\n2. SOS = {sosCount}\n3. Rock Paper Scissors = {rockPaperCount}");

                }

            }
            Console.WriteLine("Press anykey to go back to main menu");
            string any = Console.ReadLine();
            mainMenu();


        }

        //rock paper scissors
        static List<string> rockPaperChoices = new List<string>() { "ROCK", "PAPER", "SCISSORS" };
        static int rockPaperRandomNumber()
        {
            return rnd.Next(3);

        }
        static void rockPaperPlay()
        {
            Console.Write("Enter you pick: ");
            string input = Console.ReadLine().ToUpper();
            if (listChecker(input, rockPaperChoices))
            {
                switch (rockPaperRandomNumber())
                {
                    case 0:
                        if (input == "ROCK")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[0]}");
                            Console.WriteLine("Tie!");

                        }
                        else if (input == "PAPER")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[0]}");
                            Console.WriteLine("You Won!");

                        }
                        else if (input == "SCISSORS")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[0]}");
                            Console.WriteLine("You Lost!");

                        }
                        break;
                    case 1:
                        if (input == "ROCK")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[1]}");
                            Console.WriteLine("You Lost!");

                        }
                        else if (input == "PAPER")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[1]}");
                            Console.WriteLine("Tie!");

                        }
                        else if (input == "SCISSORS")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[1]}");
                            Console.WriteLine("You Won!");

                        }
                        break;
                    case 2:
                        if (input == "ROCK")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[2]}");
                            Console.WriteLine("You Won!");

                        }
                        else if (input == "PAPER")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[2]}");
                            Console.WriteLine("You Lost!");

                        }
                        else if (input == "SCISSORS")
                        {
                            Console.WriteLine($"Your opponent's pick is {rockPaperChoices[2]}");
                            Console.WriteLine("Tie!");

                        }
                        break;
                }

            }
            else
            {
                Console.WriteLine("Invalid Input");

            }

        }
        static void rockPaper()
        {
            string anyKey;
            Console.WriteLine("Rock, Paper, Scissors!");
            do
            {
                Console.WriteLine("Press any key to play and 'B' to go back to menu");
                anyKey = Console.ReadLine().ToUpper();
                if (anyKey == "B")
                {
                    mainMenu();

                }

                rockPaperPlay();
                rockPaperCount++;

            }
            while (anyKey != "B");

        }

        //sos
        static List<string> sosChoices = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        static List<string> resetChoices()
        {
            List<string> choicesClone = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            return choicesClone;
        }
        static int sosTurns = 1;
        static int sosChoice;
        static void sosPlay()
        {
            do
            {
                Console.WriteLine("Player 1: S\nPlayer 2: O");
                if(sosTurns%2==0)
                {
                    Console.WriteLine("Your Turn Player 2");

                }
                else if (sosTurns%2==1)
                {
                    Console.WriteLine("Your Turn Player 1");

                }
                sosUI();
                Console.Write("Enter the corresponding number of your desired position: ");
                try
                {
                    sosChoice=int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Input number only!");
                }
                if(sosChoice>=0 && sosChoice<=8)
                {
                    if (sosChoices[sosChoice] != "S" && sosChoices[sosChoice] != "O")
                    {
                        if (sosTurns % 2 == 0)
                        {
                            sosChoices[sosChoice] = "O";
                            sosTurns++;

                        }
                        else if (sosTurns % 2 == 1)
                        {
                            sosChoices[sosChoice] = "S";
                            sosTurns++;

                        }

                    }
                    else if(sosChoices[sosChoice] == "S" || sosChoices[sosChoice] == "O")
                    {
                        Console.WriteLine($"Sorry box {sosChoice} is already marked with {sosChoices[sosChoice]}");
                        
                    }

                }
                else
                {
                    Console.WriteLine("Your pick is not on the choices!");

                }

            }
            while (winnerWinnerChickenDinner() == 3);

            sosUI();//last view

            if(winnerWinnerChickenDinner()==1)
            {
                Console.WriteLine($"Player {(sosTurns%2)+1} wins");
                sosChoices = resetChoices();
                sosTurns = 1;

            }
            else if(winnerWinnerChickenDinner()==2)
            {
                Console.WriteLine("Draw!");
                sosChoices = resetChoices();
                sosTurns = 1;

            }

        }
        static void sosUI()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {sosChoices[0]}  |  {sosChoices[1]}  |  {sosChoices[2]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {sosChoices[3]}  |  {sosChoices[4]}  |  {sosChoices[5]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {sosChoices[6]}  |  {sosChoices[7]}  |  {sosChoices[8]}  ");
            Console.WriteLine("     |     |     ");

        }
        static int winnerWinnerChickenDinner()
        {
            if (sosChoices[0] == sosChoices[1] && sosChoices[1] == sosChoices[2])
            {
                return 1;
            }
            else if (sosChoices[3] == sosChoices[4] && sosChoices[4] == sosChoices[5])
            {
                return 1;
            }
            else if (sosChoices[6] == sosChoices[7] && sosChoices[7] == sosChoices[8])
            {
                return 1;
            }
            else if (sosChoices[0] == sosChoices[3] && sosChoices[3] == sosChoices[6])
            {
                return 1;
            }
            else if (sosChoices[1] == sosChoices[4] && sosChoices[4] == sosChoices[7])
            {
                return 1;
            }
            else if (sosChoices[2] == sosChoices[5] && sosChoices[5] == sosChoices[8])
            {
                return 1;
            }
            else if (sosChoices[0] == sosChoices[4] && sosChoices[4] == sosChoices[8])
            {
                return 1;
            }
            else if (sosChoices[2] == sosChoices[4] && sosChoices[4] == sosChoices[6])
            {
                return 1;
            }
            else if (sosChoices[0] != "0" && sosChoices[1] != "1" && sosChoices[2] != "2" && sosChoices[3] != "3" && sosChoices[4] != "4" && sosChoices[5] != "5" && sosChoices[6] != "6" && sosChoices[7] != "7" && sosChoices[8] != "8")
            {
                return 2;
            }
            else
            {
                return 3;
            }

        }
        static void sos()
        {
            string anyKey;
            Console.WriteLine("SOS!");
            do
            {
                Console.WriteLine("Press any key to play and 'B' to go back to menu");
                anyKey = Console.ReadLine().ToUpper();
                if (anyKey == "B")
                {
                    mainMenu();

                }

                sosPlay();
                sosCount++;

            }
            while (anyKey != "B");
        }

        //dice game
        static int diceGameRandomNumber()
        {
            return rnd.Next(6) + 1;
        }
        static void diceGamePlay()
        {
            try
            {
                Console.WriteLine("Input your bet on each dice number: ");
                Console.Write("Side one: ");
                int sideOneIn = Convert.ToInt32(Console.ReadLine());
                Console.Write("Side two: ");
                int sideTwoIn = Convert.ToInt32(Console.ReadLine());
                Console.Write("Side three: ");
                int sideThreeIn = Convert.ToInt32(Console.ReadLine());
                Console.Write("Side four: ");
                int sideFourIn = Convert.ToInt32(Console.ReadLine());
                Console.Write("Side five: ");
                int sideFiveIn = Convert.ToInt32(Console.ReadLine());
                Console.Write("Side six: ");
                int sideSixIn = Convert.ToInt32(Console.ReadLine());

                int diceOne = diceGameRandomNumber();
                int diceTwo = diceGameRandomNumber();
                int diceThree = diceGameRandomNumber();

                Console.WriteLine($"The dice results are {diceOne}, {diceTwo}, and {diceThree}");

                switch(diceOne)
                {
                    case 1:
                        sideOneIn = sideOneIn + sideOneIn;
                        break;
                    case 2:
                        sideTwoIn = sideTwoIn + sideTwoIn;
                        break;
                    case 3:
                        sideThreeIn = sideThreeIn + sideThreeIn;
                        break;
                    case 4:
                        sideFourIn = sideFourIn + sideFourIn;
                        break;
                    case 5:
                        sideFiveIn = sideFiveIn + sideFiveIn;
                        break;
                    case 6:
                        sideSixIn = sideSixIn + sideSixIn;
                        break;
                }
                switch (diceTwo)
                {
                    case 1:
                        sideOneIn = sideOneIn + sideOneIn;
                        break;
                    case 2:
                        sideTwoIn = sideTwoIn + sideTwoIn;
                        break;
                    case 3:
                        sideThreeIn = sideThreeIn + sideThreeIn;
                        break;
                    case 4:
                        sideFourIn = sideFourIn + sideFourIn;
                        break;
                    case 5:
                        sideFiveIn = sideFiveIn + sideFiveIn;
                        break;
                    case 6:
                        sideSixIn = sideSixIn + sideSixIn;
                        break;
                }
                switch (diceThree)
                {
                    case 1:
                        sideOneIn = sideOneIn + sideOneIn;
                        break;
                    case 2:
                        sideTwoIn = sideTwoIn + sideTwoIn;
                        break;
                    case 3:
                        sideThreeIn = sideThreeIn + sideThreeIn;
                        break;
                    case 4:
                        sideFourIn = sideFourIn + sideFourIn;
                        break;
                    case 5:
                        sideFiveIn = sideFiveIn + sideFiveIn;
                        break;
                    case 6:
                        sideSixIn = sideSixIn + sideSixIn;
                        break;
                }

                sideOneIn = returnZero(1, diceOne, diceTwo, diceThree, sideOneIn);
                sideTwoIn = returnZero(2, diceOne, diceTwo, diceThree, sideTwoIn);
                sideThreeIn = returnZero(3, diceOne, diceTwo, diceThree, sideThreeIn);
                sideFourIn = returnZero(4, diceOne, diceTwo, diceThree, sideFourIn);
                sideFiveIn = returnZero(5, diceOne, diceTwo, diceThree, sideFiveIn);
                sideSixIn = returnZero(6, diceOne, diceTwo, diceThree, sideSixIn);


                Console.WriteLine($"Your money now is {sideOneIn + sideTwoIn + sideThreeIn + sideFourIn + sideFiveIn + sideSixIn}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter number only!");
            }

        }
        static int returnZero(int side, int first, int second, int third, int bet)
        {
            if(side != first && side != second && side != third)
            {
                return 0;
            }
            else
            {
                return bet;
            }
        }
        static void diceGame()
        {
            string anyKey;
            Console.WriteLine("Dice Game!");
            do
            {
                Console.WriteLine("Press any key to play and 'B' to go back to menu");
                anyKey = Console.ReadLine().ToUpper();
                if (anyKey == "B")
                {
                    mainMenu();

                }

                diceGamePlay();
                diceCount++;

            }
            while (anyKey != "B");
        }
        
        static void Main(string[] args)
        {
            //rockPaper();
            //sos();
            //diceGame();
            mainMenu();

        }
    }
}