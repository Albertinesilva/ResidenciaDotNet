using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recursos
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade;
        public DateTime DataNascimento { get; set; }

        public Pessoa(string nome, DateTime dataNascimento, string cpf, int idade)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Cpf = cpf;
            this.Idade = idade;
        }
        
    }
}