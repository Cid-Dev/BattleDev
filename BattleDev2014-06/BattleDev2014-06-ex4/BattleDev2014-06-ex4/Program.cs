using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDev2014_06_ex4
{
    class Comp_Tree
    {
        public string name;
        public List<Comp_Tree> branch;

        public Comp_Tree(string name)
        {
            this.name = name;
            this.branch = null;
        }
    }

    class Program
    {
        static List<Comp_Tree> add_branch(List<Comp_Tree> root, string name, string[] branch)
        {
            for (int i = 0; i < root.Count; i++)
                if (root[i].name == name)
                {
                    root[i].branch = new List<Comp_Tree>();
                    for (int j = 1; j < branch.Length; j++)
                        root[i].branch.Add(new Comp_Tree(branch[j]));
                }
                else if (root[i].branch != null)
                    root[i].branch = add_branch(root[i].branch, name, branch);
            return (root);
        }

        static int get_the_longest(List<Comp_Tree> root, int n)
        {
            int temp;
            int temp2 = 0;

            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].branch != null)
                    temp = get_the_longest(root[i].branch, n + 1);
                else
                    temp = n;
                if (temp > temp2)
                    temp2 = temp;
            }
            return (temp2);
        }

        static void Main(string[] args)
        {
            string line;
            List<Comp_Tree> root = null;
            string[] temp_branch;
            int count;

            while ((line = Console.ReadLine()) != null)
            {
                temp_branch = line.Split(' ');
                if (root == null)
                {
                    root = new List<Comp_Tree>();
                    if (temp_branch.Length > 0)
                        root.Add(new Comp_Tree(temp_branch[0]));
                }
                if (temp_branch.Length > 0)
                    root = add_branch(root, temp_branch[0], temp_branch);
            }
            count = get_the_longest(root, 0);
            Console.WriteLine(count);
        }
    }
}