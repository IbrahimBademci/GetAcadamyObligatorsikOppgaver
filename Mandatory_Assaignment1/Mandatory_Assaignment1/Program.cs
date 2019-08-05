using System;
using System.Collections.Generic;

namespace Mandatory_Assaignment1
{
    class Program
    {
        public static Person[] Persons;
        static void Main(string[] args)
        {
            ShowFirstConsoleScreen();
            while (true)
            {
                var text = Console.ReadLine();

                People();
                CheckingWhatYouTypeInConsoleAndShows(text);
                if (text == string.Empty) break;
                if (text.ToLower() == "hjelp") ShowHelpText();
            }
        }

        private static void ShowHelpText()
        {
            Console.WriteLine("hjelp => viser en hjelpetekst som forklarer alle kommandoene");
            Console.WriteLine("liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. ");
            Console.WriteLine("vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)");
        }

        private static void People()
        {
            var sverreMagnus = new Person(1) {Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005};
            var ingridAlexandra = new Person(2) {Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004};
            var haakon = new Person(3) {Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973};
            var metteMarit = new Person(4) {Id = 4, FirstName = "Mette-Marit", BirthYear = 1973};
            var marius = new Person(5) {Id = 5, FirstName = "Marius", LastName = "Borg Høiby", BirthYear = 1997};
            var harald = new Person(6) {Id = 6, FirstName = "Harald", BirthYear = 1937};
            var sonja = new Person(7) {Id = 7, FirstName = "Sonja", BirthYear = 1937};
            var olav = new Person(8) {Id = 8, FirstName = "Olav", BirthYear = 1903, DeathYear = "1991"};

            sverreMagnus.Father = haakon;
            sverreMagnus.Mother = metteMarit;
            ingridAlexandra.Father = haakon;
            ingridAlexandra.Mother = metteMarit;
            marius.Mother = metteMarit;
            haakon.Father = harald;
            haakon.Mother = sonja;
            harald.Father = olav;
            Persons = new[]
            {
                sverreMagnus,
                ingridAlexandra,
                haakon,
                metteMarit,
                marius,
                harald,
                sonja,
                olav
            };
        }

        private static void ShowFirstConsoleScreen()
        {
            Console.WriteLine("Skriv \"hjelp\" hvis du står fast!");
        }

        public static void CheckingWhatYouTypeInConsoleAndShows(string text)
        {
            Console.Clear();
            foreach (var person in Persons)
            {
                if (text.ToLower() != $"vis {person.Id}" && text.ToLower() != "liste") continue;
                if (person.Mother != null && person.Father != null)
                {
                    person.Show("Navn:");
                    person.Mother.Show("      -Mor:");
                    person.Father.Show("      -Far:");
                }
                else if (person.Mother != null && person.Father == null)
                {
                    person.Show("Navn:");
                    person.Mother.Show("      -Mor:");
                }
                else if (person.Mother == null && person.Father != null)
                {
                    person.Show("Navn:");
                    person.Father.Show("      -Far:");
                }
                else person.Show("Navn:");

                foreach (var kid in Persons)
                {
                    // if person has mother or father Person is a kid to someone, and this foreach searches the array and finds it.
                    if (kid.Father == person || kid.Mother == person) kid.Show("      -Barn:");
                }
            }
        }
    }
}
