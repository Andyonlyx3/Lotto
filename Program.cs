namespace Lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //# Teil1

            //Lottozahlen
            //Erstellen Sie ein int[] lottozahlen mit der Länge 49.
            //Schreiben Sie dann einen Code der dieses Array automatisch mit den Zahlen 1 - 49 befüllt.

            //# Teil2

            //Ziehung der Lottozahlen
            //Aus dem Array unserer Lottozahlen sollen nun sechs Zahlen zufällig gezogen werden.
            //Diese sechs Zahlen müssen in einem neuen Array abgelegt werden. 
            //Verwenden Sie auch wieder Random für die Zufällige Ziehung.
            //Bei den gezogenen Zahlen darf es zu keiner Dopplung kommen.

            //# Teil3

            //User-Eingabe und Gewinnausgabe
            //Der User soll in der Lage sein, sechs Zahlen einzugeben.
            //Diese werden in einem Array abgelegt.
            //Danach soll überprüft werden, wieviele Zahlen der User im Vergleich zu den gezogenen Lottozahlen richtig getippt hat.
            //Geben Sie in der Konsole aus, wieviele Richtige getippt wurden.

            //Sollten Sie in der vorherigen Aufgabe zu keiner Lösung gekommen sein, schreiben Sie von Hand ein Array mit gezogenen Zahlen.

            Console.ForegroundColor = ConsoleColor.Green;
            int[] lottozahlen = new int[49];

            for (int i = 0; i < lottozahlen.Length; i++)
            {
                lottozahlen[i] = i + 1;
            }
            //foreach (int i in lottozahlen)
            //{
            //    Console.WriteLine(i);
            //}
            int[] ziehung = new int[6];
            Random random = new Random();

            for (int i = 0; i < ziehung.Length; i++)
            {
                int randomZahl;
                do
                {
                    randomZahl = lottozahlen[random.Next(lottozahlen.Length)];
                }
                while (Array.Exists(ziehung, a => a == randomZahl)); //# Überprüft ob die Zahl schon gezogen wurde und zieht ggf. eine andere Random Zahl durch eine Lambda-Funktion (a => a == ranomzahl) a dient hier als bool.

                ziehung[i] = randomZahl;
            }
            Console.WriteLine("Guten Tag User!\nLass uns Lotto spielen");
            int[] userZahlen = new int[6];
                 
            Console.WriteLine("Bitte tippe nacheinander 6 unterschiedliche Zahlen zwischen 1-49\nund Bestätige deine jeweilige eingabe mit enter");
                      
                for (int i = 0; i < userZahlen.Length; i++)
                {
                int userZahl;
                do
                {
                    Console.WriteLine($"Zahl {i + 1}:");
                    userZahl = int.Parse(Console.ReadLine() ?? "0");

                    if (userZahl < 1 || userZahl > 49 || Array.Exists(userZahlen, b => b == userZahl))
                        {
                        Console.WriteLine("Eingabe ungültig! Zahl muss zwischen 1 und 49 liegen und darf nicht mehrmals gewählt werden.");
                        userZahl = 0;
                    }
                } while (userZahl == 0);
                userZahlen[i] = userZahl;
                }

            Console.WriteLine("\nDeine Zahlen:\n");
            foreach (int i in userZahlen)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nDie Gezogenen Zahlen:\n");
            foreach (int i in ziehung)
            {
                Console.WriteLine(i);
            }
            
            int gleich = userZahlen.Count(c => Array.Exists(ziehung, d => d == c));
            Console.WriteLine($"\nDu hast {gleich} Zahl(en) die Übereinstimmen!");
        }
    }
}
