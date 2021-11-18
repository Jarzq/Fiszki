using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUITools;

namespace fiszki
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menuZadan = new Menu();
            menager_fiszek menager = new menager_fiszek(100);
            Menu menuStart = new Menu();
            menuStart.Konfiguruj(new string[] { "wszystkie", "tylko niezapamiętane", "powrót"});
            menuZadan.Konfiguruj(new string[] { "Rozpocznij", "Dodaj fiszke", "Pokaz które już umiesz","pokaż których nie umiesz","statystyki","zakoncz" });
            int decyzja =0, decyzjaStart = 0;

            do
            {
                decyzja = menuZadan.Otworz();
                if (decyzja == 0)
                {
                    CzyszczenieEkranu();
                    do
                    {
                        decyzjaStart = menuStart.Otworz();
                        if (decyzjaStart == 0) 
                        {
                            CzyszczenieEkranu();
                            menager.start_all();
                            Console.ReadKey();
                            
                        }
                        if (decyzjaStart == 1) 
                        {
                            CzyszczenieEkranu();
                            menager.start_unknown();
                            Console.ReadKey();
                        }
                        CzyszczenieEkranu();
                    } while (decyzjaStart != 2);
                    
                    
                    
                    
                    

                }
                if (decyzja == 1)
                {
                    CzyszczenieEkranu();
                    menager.add();
                   

                }
                if (decyzja == 2)
                {
                    CzyszczenieEkranu();
                    menager.show_known();
                    Console.ReadKey();
                }
                if (decyzja == 3)
                {
                    CzyszczenieEkranu();
                    menager.show_unknown();
                    Console.ReadKey();

                }
                if (decyzja == 4)
                {
                    CzyszczenieEkranu();
                    menager.stats();
                    Console.ReadKey();

                }

                CzyszczenieEkranu();
                    
            } while (decyzja != -1 && decyzja != 5);

        }
        private static void CzyszczenieEkranu()
        {
            Console.ResetColor();
            Console.Clear();
        }
    }
}
