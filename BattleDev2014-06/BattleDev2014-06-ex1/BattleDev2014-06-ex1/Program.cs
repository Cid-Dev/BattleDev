using System;

namespace BattleDev2014_06_ex1
{
    class Program
    {
        static string[] build_cards()
        {
            string[] all_cards = new string[52];
            string[] colors = { "C", "P", "Q", "T" };
            string[] hi_cards = { "V", "D", "R", "A" };
            int l = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 2; j <= 10; j++)
                    all_cards[l++] = colors[i] + j.ToString();
                for (int k = 0; k < hi_cards.Length; k++)
                    all_cards[l++] = colors[i] + hi_cards[k];
            }
            return (all_cards);
        }

        static void Main(string[] args)
        {
            string line;
            string[] recv_cards = null;
            string[] all_cards;
            string answer = "";

            while ((line = Console.ReadLine()) != null)
                recv_cards = line.Split(' ');
            all_cards = build_cards();
            bool flag = true;
            for (int i = 0; i < all_cards.Length; i++)
            {
                flag = false;
                for (int j = 0; (!flag && j < recv_cards.Length); j++)
                    if (string.Compare(all_cards[i], recv_cards[j]) == 0)
                        flag = true;
                if (!flag)
                    answer += ((answer.Length > 1) ? (" ") : ("")) + all_cards[i];
            }
            Console.WriteLine(answer);
        }
    }
}
