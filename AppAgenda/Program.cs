using System;
using System.Globalization;

namespace AppAgenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //Instanciando a classe Agenda
            Agenda agenda = new Agenda();
            agenda.Menu();
        }
    }
}
