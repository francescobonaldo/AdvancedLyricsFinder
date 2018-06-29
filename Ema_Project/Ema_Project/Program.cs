using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace advancedLyricsFinder
{
    class Program
    {
        static List<string> nomi_canzoni = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("ALF, the advanced lyrics finder, a project of the cxemabonny company");
            start();

            Console.ReadKey(); //fine programma

            //tutto il cuore del programma, serve per qunado il cliente vuole ricominciare, basta richiamarlo
            void start()
            {
                Console.Write("type the lyric you need here:");
                string mySong = Console.ReadLine(); //nome canzone
                Console.Write(mySong); //cosa inutile ma figa da vedre
                Console.WriteLine("  ~elaborating ...");
                if (check(mySong, nomi_canzoni)) //se esiste la stampa
                    printSong(mySong);
                else //se non esiste la canzone
                {
                    Console.WriteLine("The text doesn't exist, do you want to add it? (y/n)");
                    if (Console.ReadLine() == "y")
                        addNewText(mySong);
                    else
                        start();
                }
            }

            //method per il primo testo aka Cups~Anna Kendric
            void cups()
            {
                StreamReader tx = new StreamReader("cups.txt");
                string t = tx.ReadLine();
                List<string> lyric = new List<string>();

                while (t != null)
                {
                    lyric.Add(t);
                    t = tx.ReadLine();
                }
                tx.Close();
                foreach (var item in lyric)
                    Console.WriteLine(item);
            }

            //controlla se c'è il testo
            bool check(string s, List<string> n)
            {
                foreach (var item in n)
                    if (n.Contains(s))
                        return true; //se trova la canzone
                return false; //se non trova la canzone
            }

            //gli passo il nome della canzone e lui la stampa
            void printSong(string nome)
            {
                nome += ".txt";
                StreamReader sr = new StreamReader(nome);
                string s = sr.ReadLine();
                while (s != null)
                {
                    Console.WriteLine(s);
                    s = sr.ReadLine();
                }
                sr.Close();
            }

            //per aggiundere il titolo sulla lista e il testo della conzone
            void addNewText(string nome)
            {
                nomi_canzoni.Add(nome); //aggiungo il nome alla lista
                nome += ".txt";
                Console.WriteLine("Write here the text of the song");
                StreamWriter sw = new StreamWriter(nome);
                sw.Write(Console.ReadLine()); //scrive dentro al file creato il testo della canzone
                sw.Close();
            }
        }
    }
}
