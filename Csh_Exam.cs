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
            public void AddEn(string s)
            {
                Eng.Add(s);
                Console.WriteLine($"Enter translate for \"{s}\":");
                string tr = Console.ReadLine();
                Ukr.Add(tr);
            }
            public void AddUkr(string s)
            {
                Ukr.Add(s);
                Console.WriteLine($"Enter translate for \"{s}\":");
                string tr = Console.ReadLine();
                Eng.Add(tr);
            }
            public void AddUkrTranslateForExist(string s)
            {
                foreach (string st in Eng)
                {
                    if(st==s)
                    {
                        Console.WriteLine($"Add translate for \"{s}\":");
                        string tr = Console.ReadLine();
                        Ukr.Add(tr);
                    }
                }
            }
            public void AddEnTranslateForExist(string s)
            {
                foreach (string st in Ukr)
                {
                    if (st == s)
                    {
                        Console.WriteLine($"Add translate for \"{s}\":");
                        string tr = Console.ReadLine();
                        Eng.Add(tr);
                    }
                }
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
            public void AddUrkTrans(string s)
            {
                foreach (Dictionary d in lst)
                {
                    foreach (string w in d.Eng)
                    {
                        if (s == w)
                        {

                            d.AddUkrTranslateForExist(s);

                        }
                    }
                }
                    
            }
            public void AddEngTrans(string s)
            {
                foreach (Dictionary d in lst)
                {
                    foreach (string w in d.Ukr)
                    {
                        if (s == w)
                        {

                            d.AddEnTranslateForExist(s);

                        }
                    }
                }

            }
            public void Show(string s)
           {
               foreach(Dictionary d in lst)
                {
                    foreach (string w in d.Eng)
                    {
                        if (s == w)
                        {

                            for (int i = 0; i < d.Ukr.Count; i++)
                                Console.WriteLine(d.Ukr[i]);
                            
                        }
                    }
                        
                }
                    
           }

            public void ChangeEngWord(string o,string n)
            {
                foreach (Dictionary d in lst)
                {
                    for (int i=0;i< d.Eng.Count;i++)
                    {
                        if (o == d.Eng[i])
                        {

                            d.Eng[i] = n;

                        }
                    }

                }
            }

            public void ChangeUkrWord(string o, string n)
            {
                foreach (Dictionary d in lst)
                {
                    for (int i = 0; i < d.Ukr.Count; i++)
                    {
                        if (o == d.Ukr[i])
                        {

                            d.Ukr[i] = n;

                        }
                    }

                }
            }

            void SaveJSON(Library lb)
            {
                string path = "library.json";
                string json = JsonConvert.SerializeObject(lb);
                File.WriteAllText(path, json);
            }

        }
        

        static void Main(string[] args)
        {
            
            Library lb = new Library();
            //lb.AddWordEn("dog");
            //lb.AddWordEn("cat");

                lb.AddWordEn("fish");
                lb.AddWordEn("bird");
                lb.Show("fish");
                lb.AddUrkTrans("fish");
                lb.Show("fish");
           
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
