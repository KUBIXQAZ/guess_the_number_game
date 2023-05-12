namespace guess_the_number
{
    internal class Program
    {
        static void Main()
        {
            string range = "";

            while (range == "" || !(int.TryParse(range, out int result)) || int.Parse(range) <= 1)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Guess The Number where you have to guess the number with hints that i will give you.");
                Console.WriteLine("type the end number of range that you want to play on.");

                range = Console.ReadLine();
            }

            Console.Clear();
            int parsed_range = int.Parse(range);

            string answer = "0";

            Random random = new Random();
            int x = random.Next(1, parsed_range + 1);

            int number_of_attempts = 0;

            while(int.Parse(answer) != x)
            {
                Console.WriteLine("type in your guess.");
                answer = Console.ReadLine();

                bool is_answer_int = int.TryParse(answer, out int parsed_answer);
                while(!(is_answer_int))
                {
                    Console.WriteLine("type in your guess.");
                    answer = Console.ReadLine();
                    is_answer_int = int.TryParse(answer, out parsed_answer);
                }
                number_of_attempts++;
                if (parsed_answer < 1 || parsed_answer > parsed_range) Console.WriteLine("out of range, range is 1-" + range);
                else if (parsed_answer > x) Console.WriteLine("your guess in above number that i picked");
                else if(parsed_answer < x) Console.WriteLine("your guess in below number that i picked");
            }

            Console.Clear();
            Console.WriteLine("you got it in " + number_of_attempts + " attempts good job!");
            Console.WriteLine("number that i picked was " + x);
            Console.WriteLine("do you want to play again? then type yes");
            string again = Console.ReadLine();
            if (again.ToLower() == "yes")
            {
                Console.Clear();
                Main();
            }
        }
    }
}