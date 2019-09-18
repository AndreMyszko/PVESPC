// # andre myszko # 2019102420
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroPessoas
{ 
    class Aluno
    {
        public Aluno(){}

        //Atributos da classe Pessoas:
        public string Cod { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Data { get; set; }
        public float Altura { get; set; }

        public Aluno(string cod, string nome, int idade, string data, float altura)
        {
            this.Cod = cod;
            this.Nome = nome;
            this.Idade = idade;
            this.Data = data;
            this.Altura = altura;
        }
    }
}
