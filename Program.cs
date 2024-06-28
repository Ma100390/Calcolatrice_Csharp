/* —————————————————————————
 * Esecrizi Day 3
————————————————————————— */

/* 
 * Cosa deve fare il programma? (Indicativamente)
 * Non possiamo sapere a priori i dettagli; verranno man mano...
 * Definiamo un contenitore padre, che contenga la struttura generale.
 * SCOPO DELL'APP: Mini calcolatrice che esegue operazioni minimali su due numeri.
 * 
 * Definisco 2 campi, uno per il primo numero (first) a l'altro per il secondo (second).
 * Definisco le proprietà dei campi.
 * 
 * La calcolatrice deve svolgere queste operazioni:
 * 
 *      1) sommare i numeri;
 *      2) ...;
*/

/* TIPI DI DATO
 * 
 * Dati numerici:
 *      1) integer (int): numeri interi con segno;
 *      2) decimal (decimal): numeri decimali con segno;
 *      3) float (float): decimali fino a 7 cifre decimali con segno;
 *      4) double (double): decimali fino a 15 cifre decimali con segno.
 * 
 * Dati logici (booleani):
 *      1) blooean (bool): o vero (true) o falso (false); [oppure rispettivamente 1 e 0].
 *      
 * Dati stringa:
 *      1) char (char): carattere singolo;
 *      2) string (string): stringhe di testo.
 *      
 * Dati vari:
 *      1) class NomeClasse (class): classi: contengono attributi e metodi.
 *      
 * 
 * Le variabili e le costanti sono dei contenitori neei quali possiamo inserire dei dati.
 * Le variabili POSSONO essere riassegnate, le costanti NO!
 * Una variabile è «inizializzata» quando è stata dichiarata. */

Console.Clear();    // Pulisce la console

string xStr, yStr;  // Inizializza le variabili senza assegnare un valore
decimal xDec, yDec;

Console.WriteLine("Inserisci il primo numero:");
xStr = Console.ReadLine();              // In lettura da console i dati sono di tipo string (stringa)
xDec = Convert.ToDecimal(xStr);         // Dobbiamo convertirli in decimal (decimale)

Console.WriteLine("Inserisci il primo numero:");
yStr = Console.ReadLine();              // In lettura da console i dati sono di tipo string (stringa)
yDec = Convert.ToDecimal(yStr);         // Dobbiamo convertirli in decimal (decimale)


/* CLASSE nome_della_variabile = new COSTRUTTORE(parametri). */


Calcolatrice operazioni = new Calcolatrice(xDec, yDec); // Costruisce la classe calcolatrice con i valori acquisiti e convertiti
Console.WriteLine($"{operazioni.First} + {operazioni.second} = {operazioni.Somma()}");   // Stampa la somma fra i valori nella calcolatrice


Console.WriteLine("Premi <Enter> per terminare il programma.");
Console.ReadLine();                     // Ferma temporaneamente il flusso del programma


/* Creazione della classe calcolatrice */
public class Calcolatrice
{
    private decimal first;   // campo riservato al primo numero della calcolatrice
    public decimal second;  // campo riservato al secondo numero della calcolatrice
    public decimal temp;    // campo riservato a una variabile extra

    public decimal First                // proprietà per leggere/scrivere (riassegnare) la variabile first. 
    {                                   // Senza di essa, non possiamo leggerne/scrivere il contenuto dall'esterno 
        get { return first; }           // con il comando nomeOggetto.first: dobbiamo usare per forza nomeOggetto.First (lettura/scrittura)
        set { this.first = value; }
    }

    public decimal Second   // questa proprietà non è necessaria, perché il campo second è public; può essere richiamato direttamente con la sintassi nomeOggetto.second
    {
        get { return second; }
        set { this.second = value; }
    }

    public Calcolatrice(decimal _first, decimal _second)
    {
        this.first = _first;
        this.second = _second;
    }

    public decimal Somma()  // funzione che addiziona i due numeri della classe. Non ha bisogno di argomenti perché non richiede ulteriori elementi esterni
    {
        decimal result = this.first + this.second;  // this. è un puntatore autoreferenziale agli elementi della classe
        return result;                              // restituisce il dato che ci interessa, in questo caso il risultato (result)
                                                    // in questo caso, abbiamo creato una variabile temporanea (result) per immagazzinare il risultato
    }

    public decimal Differenza()  // funzione che sottrae first con second. Non ha bisogno di argomenti perché non richiede ulteriori elementi esterni
    {
        return this.first - this.second; // il valore della differenza viene restituito direttamente senza creare variabili temporanee per immagazzinarlo
    }

    public decimal Prodotto() // moltiplicazione
    {
        return this.first * this.second;
    }

    public decimal Quoziente() // divisione fra first e second
    {
        return this.first / this.second;
    }

    public decimal Resto() // resto fra first e second; first = second * qualche cosa + resto
    {
        return this.first % this.second;
    }

    public decimal MediaAritmetica() // media aritmetica
    {
        return (this.first + this.second) / 2;
    }

    public decimal QuadratoSomma() // quadrato della somma
    {
        decimal sum = this.Somma();
        return sum * sum;
    }

    // Best practice: DRY (Don't Repeat Yourself): snellire lo sviluppo
}


/* ESEMPIO SULLA DIFFERENZA TRA PUBLIC E PRIVATE
 * 
 * Creo un oggetto di tipo Calcolatrice: Calcolatrice pincoPallino = new Calcolatrice(...).
 * Se in qualche punto del programma inserisco: pincoPallino.first, allora richiamo il campo 'first' dell'oggetto pincoPallino.
 * Se first è private, non sarà possibile invocarlo perché l'uso è interno; dunque avrò un errore!
 * 
 * Il comportamento di default è public!
 * 
 * Lo si specifica in tal caso per una maggior comprensione del codice...
 * */