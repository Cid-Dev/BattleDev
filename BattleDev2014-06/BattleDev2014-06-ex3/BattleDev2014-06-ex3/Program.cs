using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDev2014_06_ex3
{
    class Program
    {
        static string get_the_value(char c)
        {
            switch (c)
            {
                case 'a':
                case 'j':
                    return ("1");

                case 'b':
                case 'k':
                case 's':
                    return ("2");

                case 'c':
                case 'l':
                case 't':
                    return ("3");

                case 'd':
                case 'm':
                case 'u':
                    return ("4");

                case 'e':
                case 'n':
                case 'v':
                    return ("5");

                case 'f':
                case 'o':
                case 'w':
                    return ("6");

                case 'g':
                case 'p':
                case 'x':
                    return ("7");

                case 'h':
                case 'q':
                case 'y':
                    return ("8");

                case 'i':
                case 'r':
                case 'z':
                    return ("9");

                default:
                    return (c.ToString());
            }
        }

        static double get_vals(string inf, int size)
        {
            string val = "";
            if (inf.Length != size)
                return (-1);
            for (int i = 0; i < inf.Length; i++)
            {
                if (!((inf[i] >= '0' && inf[i] <= '9')
                    || (char.ToLower(inf[i]) >= 'a' && char.ToLower(inf[i]) <= 'z')))
                    return (-1);
                val += get_the_value(char.ToLower(inf[i]));
            }
            return (Convert.ToDouble(val));
        }

        static string check_rib(string[] infos)
        {
            double val = 0;
            double temp;
            if (infos.Length != 4)
                return ("KO\n");
            temp = 89 * get_vals(infos[0], 5);
            if (temp < 0)
                return ("KO\n");
            val += temp;
            temp = 15 * get_vals(infos[1], 5);
            if (temp < 0)
                return ("KO\n");
            val += temp;
            temp = 3 * get_vals(infos[2], 10);
            if (temp < 0)
                return ("KO\n");
            val += temp;
            for (int i = 0; i < infos[3].Length; i++)
                if (!(infos[3][i] >= '0' && infos[3][i] <= '9'))
                    return ("KO");
            if (Convert.ToInt32(infos[3]) == (97 - (val % 97)))
                return ("OK\n");
            return ("KO\n");
        }

        static void Main(string[] args)
        {
            string line;
            string[] infos;
            string result = "";

            while ((line = Console.ReadLine()) != null)
            {
                infos = line.Split(' ');
                result += check_rib(infos);
            }
            if (result != "")
                result.Remove(result.Length - 1);
            Console.WriteLine(result);
        }
    }
}
