using System;
using System.Globalization;

namespace AppAgenda
{
    class Pessoa
    {
        private string Nome { get;  set; }
        private DateTime Nascimento { get;  set; }
        private float Altura { get;  set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome, DateTime nascimento, float altura)
        {
            this.Nome = nome;
            this.Nascimento = nascimento;
            this.Altura = altura;
        }

        public string PegaNome()
        {
            return Nome;
        }
        
        public override string ToString()
        {
            return "Nome: " + Nome 
            + " - Idade: "+(DateTime.Now.Year - Nascimento.Year)
            + " - Altura: "+Altura.ToString("F2", CultureInfo.InvariantCulture)
            + " - Data de nascimento: " + Nascimento.ToShortDateString()+"\n";
        }


    }
}
