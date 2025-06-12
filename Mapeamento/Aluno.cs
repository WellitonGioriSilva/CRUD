using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Mapeamento
{
    internal class Aluno
    {
        public int _id;
        public string _nome;
        public string _cpf;
        public DateTime _dataNasc;
        public char _sexo;
        public double _altura;
        public string _telefone;

        public Aluno(string nome, string cpf, DateTime dataNasc, char sexo, double altura, string telefone)
        {
            _nome = nome;
            _cpf = cpf;
            _dataNasc = dataNasc; 
            _sexo = sexo;
            _altura = altura;
            _telefone = telefone;
        }

        public Aluno()
        { 
        
        }
    }
}
