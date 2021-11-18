using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUITools;

namespace fiszki
{
    

class menager_fiszek
    {
        
        Fiszka[] fishes;
        int count = 0, count_stats = 0;
       

        public menager_fiszek(int Volume)
        {
            fishes = new Fiszka[Volume];
        }

        public void add()
        {
            Console.WriteLine("-------Nowa Fiszka------");
            
            string front, back;
            bool check = false;
            ConsoleKeyInfo klawisz;
           
            
            do
            {
                Console.WriteLine();
                Console.WriteLine("podaj słowo po Polsku");
                front = Console.ReadLine();
                Console.WriteLine("podaj tlumaczenie po Angielsku");
                back = Console.ReadLine();
                Console.WriteLine();
                Fiszka newest = new Fiszka(front, back, check);
                fishes[count++] = newest;
                Console.WriteLine("--Aby zakonczyc dodawanie wciscinj esc--");
                klawisz = Console.ReadKey(true);
            } 
            while (klawisz.Key != ConsoleKey.Escape);
            


        }     
        
        public void show()
        {
            for(int i=0; i<count; i++)
            {
                
                Console.WriteLine($"{i+1}.{fishes[i].Front} - {fishes[i].Back}");
            }
        }
        public void show_known()
        {
            Console.WriteLine("---FISZKI KTÓRE JUŻ ZNASZ---");
            for (int i = 0; i < count; i++)
            {
                if (fishes[i].check == true)
                {
                    Console.WriteLine($"{i + 1}.{fishes[i].Front} - {fishes[i].Back}");
                }
            }
        }
        public void show_unknown()
        {
            Console.WriteLine("---FISZKI KTÓRYCH JESZCZE NIE ZNASZ---");
            for (int i = 0; i < count; i++)
            {
                if (fishes[i].check == false)
                {
                    Console.WriteLine($"{i + 1}.{fishes[i].Front} - {fishes[i].Back}");
                }
            }
        }




        public void start_all()
        {
            
            for (int i=0; i<count; i++)
            {
                playing(i);
            }
            Console.WriteLine("to koniec Fiszek, wróć do menu aby dodać nowe!");
        }
        public void start_unknown()
        {

            for (int i = 0; i < count; i++)
            {
                if(fishes[i].check == false)
                {
                    playing(i);
                }
                
            }
            Console.WriteLine("to koniec Fiszek, wróć do menu aby dodać nowe!");
        }

        public void playing(int i)
        {
            ConsoleKeyInfo yn;
            Console.WriteLine($"    słowo po Polsku: {fishes[i].Front}");
            Console.WriteLine("--odkryj mnie naciskając dowolny klawisz--");
            Console.ReadKey();
            Console.WriteLine($"    tłumaczenie po Angielsku: {fishes[i].Back}");
            Console.WriteLine();
            Console.WriteLine("czy wiedziales? t/n");
            bool flaga = false;
            do
            {
                yn = Console.ReadKey(true);
                if (yn.Key != ConsoleKey.T && yn.Key != ConsoleKey.N)
                {
                    Console.WriteLine("wpisz ponownie. 't' jeżeli wiedziales, 'n' jeżeli nie wiedziales.");
                }
                if (yn.Key == ConsoleKey.T)
                {

                    Console.WriteLine("Tak trzymaj! wcisnij enter aby przejsc do kolejnej");
                    Console.ReadKey();
                    Console.Clear();
                    fishes[i].check = true;
                    flaga = true;

                }
                if (yn.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Musisz to przećwiczyć! wcisnij enter aby przejsc do kolejnej");
                    Console.ReadKey();
                    Console.Clear();
                    fishes[i].check = false;
                    flaga = true;
                }

            } while (flaga != true);

        }

        public void stats()
        {
            count_stats = 0;
            for(int i=0; i<count; i++)
            {
                if(fishes[i].check)
                {
                    count_stats++;
                }
            }
            Console.WriteLine("----STATYSTYKI----");
            Console.WriteLine($"Wszystkich fiszek: {count}");
            Console.WriteLine($"poznanych fiszek: {count_stats}");
            Console.WriteLine($"niezapamiętanych fiszek: {count - count_stats}");
        }
    }
}
