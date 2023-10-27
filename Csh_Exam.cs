using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DotNet
{
    class Csh_Exam
    {
        public class Dictionary
        {
            public List<string> Eng; //
            public List<string> Ukr; //{ get; set; }
            public Dictionary()
            {
                Eng = new List<string>();
                Ukr = new List<string>();
            }
            public void AddEn(string s) //Добавить английское слово и его перевод
            {
                Eng.Add(s);
                Console.WriteLine($"Enter translate for \"{s}\":");
                string tr = Console.ReadLine();
                Ukr.Add(tr);
            }
            public void AddUkr(string s)//Добавить русское слово и его перевод
            {
                Ukr.Add(s);
                Console.WriteLine($"Enter translate for \"{s}\":");
                string tr = Console.ReadLine();
                Eng.Add(tr);
            }
            public void AddUkrTranslateForExist(string s)//Добавить перевод к английскому слову
            {
                bool stat = false;
                foreach (string st in Eng)
                {
                    if(st==s)
                    {
                        stat = true;
                        Console.WriteLine($"Add translate for \"{s}\":");
                        string tr = Console.ReadLine();
                        Ukr.Add(tr);
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");

            }
            public void AddEnTranslateForExist(string s)//Добавить перевод к русскому слову
            {
                bool stat = false;
                foreach (string st in Ukr)
                {
                    if (st == s)
                    {
                        stat = true;
                        Console.WriteLine($"Add translate for \"{s}\":");
                        string tr = Console.ReadLine();
                        Eng.Add(tr);
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
            }
            public void Out()
            {
                foreach(string m in Eng)
                    Console.WriteLine(m);
                foreach (string n in Ukr)
                    Console.WriteLine(n);

            }
        }

        public class Library
        {
            List<Dictionary> lst;
            public Library()
            {
               lst = new List<Dictionary>();
            }
            public void AddWordEn(string s)
            {
                Dictionary d = new Dictionary();
                lst.Add(d);
                d.AddEn(s);
            }

            public void AddWordUkr(string s)
            {
                Dictionary d = new Dictionary();
                lst.Add(d);
                d.AddUkr(s);
            }

            public void DeleteEngWord(string s)
            {
                bool stat = false;
                for(int i=0;i<lst.Count;i++)
                {
                    for (int j = 0; j < lst[i].Eng.Count; j++)
                    {
                        if (s == lst[i].Eng[j])
                        {
                            stat = true;
                            lst.RemoveAt(i);

                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
            }

            public void DeleteUkrWord(string s)
            {
                bool stat = false;
                for (int i = 0; i < lst.Count; i++)
                {
                    for (int j = 0; j < lst[i].Ukr.Count; j++)
                    {
                        if (s == lst[i].Ukr[j])
                        {
                            stat = true;
                            lst.RemoveAt(i);

                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
            }

            public void AddUrkTrans(string s)//Добавить перевод к английскому слову
            {
                bool stat = false;
                foreach (Dictionary d in lst)
                {
                    foreach (string w in d.Eng)
                    {
                        if (s == w)
                        {
                            stat = true;
                            d.AddUkrTranslateForExist(s);

                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
            }
            public void AddEngTrans(string s)//Добавить перевод к русскому слову
            {
                bool stat = false;
                foreach (Dictionary d in lst)
                {
                    foreach (string w in d.Ukr)
                    {
                        if (s == w)
                        {
                            stat = true;
                            d.AddEnTranslateForExist(s);

                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
            }
            

            public void ChangeEngWord(string o,string n)
            {
                bool stat = false;
                foreach (Dictionary d in lst)
                {
                    for (int i=0;i< d.Eng.Count;i++)
                    {
                        if (o == d.Eng[i])
                        {
                            stat = true;
                            d.Eng[i] = n;

                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{o}\" is not exist in dictionary");
            }

            public void ChangeUkrWord(string o, string n)
            {
                bool stat = false;
                foreach (Dictionary d in lst)
                {
                    for (int i = 0; i < d.Ukr.Count; i++)
                    {
                        if (o == d.Ukr[i])
                        {
                            stat = true;
                            d.Ukr[i] = n;

                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{o}\" is not exist in dictionary");
            }


            public void DeleteEngTrans(string s)//удаляет русский перевод англ. слова
            {
                bool stat = false;
                for(int j=0;j<lst.Count;j++)
                {
                    for (int i = 0; i < lst[j].Ukr.Count; i++)
                    {
                        if (s == lst[j].Ukr[i])
                        {
                            stat = true;
                            if (lst[j].Ukr.Count == 1)
                                lst.RemoveAt(j);
                            else
                                lst[j].Ukr.RemoveAt(i);
                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
            }

            public void DeleteUkrTrans(string s)//удаляет англ. перевод русского слова
            {
                bool stat = false;
                for (int j = 0; j < lst.Count; j++)
                {
                    for (int i = 0; i < lst[j].Eng.Count; i++)
                    {
                        if (s == lst[j].Eng[i])
                        {
                            stat = true;
                            if (lst[j].Eng.Count == 1)
                                lst.RemoveAt(j);
                            else
                                lst[j].Eng.RemoveAt(i);
                        }
                    }
                }
                if (stat == false)
                    Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
            }

            public void ShowEng(string s)
            {
                if (lst.Count < 1)
                    Console.WriteLine("Dictionary is empty");
                else
                {
                    bool exist = false;
                    foreach (Dictionary d in lst)
                    {
                        foreach (string w in d.Eng)
                        {
                            if (s == w)
                            {
                                Console.WriteLine($"Translate for \"{s}\":");
                                exist = true;
                                for (int i = 0; i < d.Ukr.Count; i++)
                                    Console.WriteLine(d.Ukr[i]);

                            }
                        }

                    }
                    if (exist == false)
                        Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
                }

            }

            public void ShowUkr(string s)
            {
                if (lst.Count < 1)
                    Console.WriteLine("Dictionary is empty");
                else
                {
                    bool exist = false;
                    foreach (Dictionary d in lst)
                    {
                        foreach (string w in d.Ukr)
                        {
                            if (s == w)
                            {
                                Console.WriteLine($"Translate for \"{s}\":");
                                exist = true;
                                for (int i = 0; i < d.Eng.Count; i++)
                                    Console.WriteLine(d.Eng[i]);

                            }
                        }

                    }
                    if (exist == false)
                        Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
                }

            }

            public void SaveEngFile(string s)
            {
                if (lst.Count < 1)
                    Console.WriteLine("Dictionary is empty");
                else
                {
                    bool exist = false;
                    string pathToFile = s;
                    pathToFile+=".txt";
                    foreach (Dictionary d in lst)
                    {
                        foreach (string w in d.Eng)
                        {
                            if (s == w)
                            {
                                if (!File.Exists(pathToFile))
                                {
                                    var file = File.Create(pathToFile);
                                    file.Close();
                                    File.WriteAllText(pathToFile, $"Translate for \"{s}\":");
                                }
                                
                                exist = true;
                                for (int i = 0; i < d.Ukr.Count; i++)
                                File.AppendAllText(pathToFile, d.Ukr[i] + " ");

                            }
                        }

                    }
                    if (exist == false)
                        Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
                }
            }

            public void SaveUkrFile(string s)
            {
                if (lst.Count < 1)
                    Console.WriteLine("Dictionary is empty");
                else
                {
                    bool exist = false;
                    string pathToFile = s;
                    pathToFile += ".txt";
                    foreach (Dictionary d in lst)
                    {
                        foreach (string w in d.Ukr)
                        {
                            if (s == w)
                            {
                                if (!File.Exists(pathToFile))
                                {
                                    var file = File.Create(pathToFile);
                                    file.Close();
                                    File.WriteAllText(pathToFile, $"Translate for \"{s}\":");
                                }

                                exist = true;
                                for (int i = 0; i < d.Eng.Count; i++)
                                    File.AppendAllText(pathToFile, d.Eng[i] + " ");

                            }
                        }

                    }
                    if (exist == false)
                        Console.WriteLine($"Word \"{s}\" is not exist in dictionary");
                }
            }

        }
        public static void Menu()
        {
            Console.WriteLine("Select action:");
            Console.WriteLine("1. Add word");//+
            Console.WriteLine("2. Add translate");//+
            Console.WriteLine("3. Delete word");//+
            Console.WriteLine("4. Delete translate");//+
            Console.WriteLine("5. Show word and its translate");//+
            Console.WriteLine("6. Save dictionary");//+
            Console.WriteLine("7. Save word and its translate to file");
            Console.WriteLine("8. Exit");
         
        }
        

        static void Main(string[] args)
        {
            
            Library lb = new Library();
            int choise;
            string s;
            
            Menu();
            choise = Convert.ToInt32(Console.ReadLine());
            while (choise > 0 && choise < 8)
            {
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Enter word to add");
                        s = Console.ReadLine();
                        if ((int)s[0] >= 65 && (int)s[0] <= 90 || (int)s[0] >= 97 && (int)s[0] <= 122)
                            lb.AddWordEn(s);
                        else if ((int)s[0] >= 1040 && (int)s[0] <= 1103)
                            lb.AddWordUkr(s);
                        break;
                    case 2:
                        Console.WriteLine("Enter word that need translate");
                        s = Console.ReadLine();
                        if ((int)s[0] >= 65 && (int)s[0] <= 90 || (int)s[0] >= 97 && (int)s[0] <= 122)
                            lb.AddUrkTrans(s);
                        else if ((int)s[0] >= 1040 && (int)s[0] <= 1103)
                            lb.AddEngTrans(s);
                        break;
                    case 3:
                        Console.WriteLine("Enter word to delete");
                        s = Console.ReadLine();
                        if ((int)s[0] >= 65 && (int)s[0] <= 90 || (int)s[0] >= 97 && (int)s[0] <= 122)
                            lb.DeleteEngWord(s);
                        else if ((int)s[0] >= 1040 && (int)s[0] <= 1103)
                            lb.DeleteUkrWord(s);
                        break;
                    case 4:
                        Console.WriteLine("Enter translate-word to delete");
                        s = Console.ReadLine();
                        if ((int)s[0] >= 65 && (int)s[0] <= 90 || (int)s[0] >= 97 && (int)s[0] <= 122)
                            lb.DeleteUkrTrans(s);
                        else if ((int)s[0] >= 1040 && (int)s[0] <= 1103)
                            lb.DeleteEngTrans(s);
                        break;
                    case 5:
                        Console.WriteLine("Enter word to translate");
                        s = Console.ReadLine();
                        if ((int)s[0] >= 65 && (int)s[0] <= 90 || (int)s[0] >= 97 && (int)s[0] <= 122)
                            lb.ShowEng(s);
                        else if ((int)s[0] >= 1040 && (int)s[0] <= 1103)
                            lb.ShowUkr(s);
                        break;
                    case 6:
                        string path = "library.json";
                        string json = JsonConvert.SerializeObject(lb);
                        File.WriteAllText(path, json);
                        break;
                    case 7:
                        Console.WriteLine("Enter word to save");
                        s = Console.ReadLine();
                        if ((int)s[0] >= 65 && (int)s[0] <= 90 || (int)s[0] >= 97 && (int)s[0] <= 122)
                            lb.SaveEngFile(s);
                        else if ((int)s[0] >= 1040 && (int)s[0] <= 1103)
                            lb.SaveUkrFile(s);
                        break;
                    case 8:
                        Console.WriteLine("Bye!");
                        break;

                }
                Menu();
                choise = Convert.ToInt32(Console.ReadLine());
            }
            if(choise==8)
                Console.WriteLine("Goodbye!");
            
            /*
             char c = 'A';//65
            char c1 = 'Z';//90
            char d = 'a';//97
            char d1 = 'z';//122
            char e = 'А';//1040
            char e1 = 'Я';//1071
            char f = 'а';//1072
            char f1 = 'я';//1103

            Console.WriteLine((int)c+" "+(int)d+" "+(int)c1 + " " + (int)d1 + " " + (int)e + " " + (int)f + " " + (int)e1 + " " + (int)f1);
             */


        }
    }
}
