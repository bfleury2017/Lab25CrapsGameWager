using System;

namespace Lab25CrapsGameWager
{
    class Craps
    {
        
        public static void Main(string[] args)
        {
            var game = new GameApp();

            Console.Write("Play a game? [Y/N]: ");
            char response = Console.ReadLine().ToUpper()[0];
            var playGame = response.Equals('Y') ? true : false;

            while (playGame)
            {
                Console.Write($"Enter a wager or -1 to quit (Player balance {game.Balance:C}): ");
                game.Wager = ValidateWager(game.Balance);

                if (game.Wager == -1) break;

                game.Play();
                Console.WriteLine();

                if (game.Balance <= 0) break;

            }

            Console.WriteLine("Good bye.");
        }

        private static decimal ValidateWager(decimal balance)
        {
            var wager = decimal.Parse(Console.ReadLine());

            while (wager <= 0 || wager > balance)
            {
                Console.Write($"{wager} is invalid, must be greater than 0 and cannot exceed {balance:C}: ");
                wager = decimal.Parse(Console.ReadLine());
            }
            return wager;
        }
    }
}
