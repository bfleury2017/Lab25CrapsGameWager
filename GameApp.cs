using System;
namespace Lab25CrapsGameWager
{
    enum Status { Continue, Won, Lost }

    class GameApp
    {
        private static Random randomNumbers = new Random();

        private enum DiceNames
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            YoLeven = 11,
            BoxCars = 12
        }


        public Status GameStatus { get; set; }
        private decimal balance;

        public decimal Balance {
            get { return balance; }
            set { if (value >= 0) balance = value; }
        }

        private decimal wager;
        public decimal Wager {
            get { return wager; }
            set { wager = value; }
        }

        public GameApp()
        {
            Balance = 1000;
            GameStatus = Status.Continue;
        }

        public void Play() {
            int point = 0;
            int sumDice = RollDice();

            switch ((DiceNames) sumDice)
            {
                case DiceNames.Seven:
                case DiceNames.YoLeven:
                    GameStatus = Status.Won;
                    break;
                case DiceNames.SnakeEyes:
                case DiceNames.Trey:
                case DiceNames.BoxCars:
                    GameStatus = Status.Lost;
                    break;
                default:
                    GameStatus = Status.Continue;
                    point = sumDice;
                    Console.WriteLine($"Point {point}");
                    break;
            }


            while (GameStatus == Status.Continue)
            {
                sumDice = RollDice();
                if (point == sumDice)
                {
                    GameStatus = Status.Won;
                } else {
                    if (sumDice == (int)DiceNames.Seven)
                    {
                        GameStatus = Status.Lost;
                    }
                }
            }

            var result = "";
            if (GameStatus == Status.Won)
            {
                Balance += Wager;
                result = "Player wins";

            } else
            {
                Balance -= Wager;
                result = "Player loses";
            }

            var bustedPrompt = Balance > 0 ? "" : "Busted.";
            Console.WriteLine($"{result}. {bustedPrompt}");
        }

        public int RollDice(){
            int die1 = randomNumbers.Next(1, 7);
            int die2 = randomNumbers.Next(1, 7);

            int sum = die1 + die2;
            Console.WriteLine($"Player rolled {die1} + {die2} = {sum}");
            return sum;
        }
    }
}
