using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDev2014_06_ex5
{
    class Comp_Tree
    {
        public string name;
        public List<Comp_Tree> branch;
        public List<string> ignore;
        public Comp_Tree(string name)
        {
            this.name = name;
            this.branch = null;
            this.ignore = new List<string>();
        }
    }

    class Comp_List
    {
        public string name;
        public string contact;
        public bool ignored;

        public Comp_List(string name,
                         string contact,
                         bool ignored)
        {
            this.name = name;
            this.contact = contact;
            this.ignored = ignored;
        }
    }

    class Program
    {
        static string get_the_result0(List<Comp_Tree> root, List<string> ignore, int d)
        {
            string temp = "";

            if (d >= 0)
                for (int i = 0; i < root.Count; i++)
                {
                    bool flag = false;
                    for (int j = 0; j < ignore.Count; j++)
                        if (ignore[j] == root[i].name)
                            flag = true;
                    if (!flag)
                        temp += root[i].name + " ";
                    if (root[i].branch != null)
                        temp += get_the_result0(root[i].branch, ignore, d - 1);
                }
            return (temp);
        }

        static string get_the_result(List<Comp_Tree> root, string start, int d)
        {
            string temp = "";

            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].name == start)
                    return (get_the_result0(root, root[i].ignore, d));
                if (root[i].branch != null)
                    temp = get_the_result(root[i].branch, start, d);
            }
            return (temp);
        }

        static void swap(ref string str1, ref string str2)
        {
            string temp;

            temp = str1;
            str1 = str2;
            str2 = temp;
        }

        static string[] bbsort(string[] result)
        {
            bool flag = false;
            
            while (!flag)
            {
                flag = true;
                for (int i = 1; i < result.Length; i++)
                    if (String.Compare(result[i - 1], result[i]) > 0)
                    {
                        flag = false;
                        swap(ref result[i - 1], ref result[i]);
                    }
            }
            return (result);
        }

        static bool not_in(List<Comp_Tree> root, string name)
        {
            bool flag = true;
            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].name == name)
                    return (false);
                if (root[i].branch != null)
                    flag = not_in(root[i].branch, name);
            }
            return (flag);
        }

        static List<Comp_List> add_list(List<Comp_List> prelist, string name, string contact, bool ignored)
        {
            bool flag = false;
            for (int i = 0; i < prelist.Count; i++)
                if (prelist[i].name == name
                    && prelist[i].contact == contact)
                {
                    flag = true;
                    if (ignored)
                        prelist[i].ignored = true;
                }
            if (!flag)
                prelist.Add(new Comp_List(name, contact, ignored));
            return (prelist);
        }

        static List<Comp_Tree> build_tree(List<Comp_Tree> root, List<Comp_List> prelist, int d)
        {
            if (d >= 0)
                for (int j = 0; j < root.Count; j++)
                    for (int i = 0; i < prelist.Count; i++)
                        if (root[j].name == prelist[i].name)
                        {
                            if (prelist[i].ignored)
                                root[j].ignore.Add(prelist[i].contact);
                            else
                            {
                                if (root[j].branch == null)
                                    root[j].branch = new List<Comp_Tree>();
                                root[j].branch.Add(new Comp_Tree(prelist[i].contact));
                                root[j].branch = build_tree(root[j].branch, prelist, d - 1);
                            }
                        }
            return (root);
        }

        static void Main(string[] args)
        {
            string line;
            List<Comp_Tree> root = new List<Comp_Tree>();
            List<Comp_List> prelist = new List<Comp_List>();
            string[] temp_branch = null;
            string result0;
            string[] result;

            while ((line = Console.ReadLine()) != null)
            {
                temp_branch = line.Split(' ');
                if (temp_branch[1] == "-")
                    prelist = add_list(prelist, temp_branch[0], temp_branch[2], true);
                else if (temp_branch[1] == "+")
                    prelist = add_list(prelist, temp_branch[0], temp_branch[2], false);
            }
            root.Add(new Comp_Tree(temp_branch[0]));
            root = build_tree(root, prelist, Convert.ToInt32(temp_branch[2]));
            result0 = get_the_result(root, temp_branch[0], Convert.ToInt32(temp_branch[2]));
            if (result0[result0.Length - 1] == ' ')
                result0 = result0.Remove(result0.Length - 1);
            result = result0.Split(' ');
            result = bbsort(result);
            for (int i = 0; i < result.Length; i++)
            {
                if (i > 0)
                {
                    if (String.Compare(result[i - 1], result[i]) != 0)
                        Console.WriteLine(result[i]);
                }
                else
                    Console.WriteLine(result[i]);
            }
        }
    }
}
