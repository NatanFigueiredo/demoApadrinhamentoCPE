using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento.Classes
{
    class Aluno
    {
        string nome;
        string turno;
        string mbti;
        string horário;

        public Aluno(string nome, string turno, string mbti, string horário)
        {
            this.Nome = nome;
            this.Turno = turno;
            this.Mbti = mbti;
            this.Horário = horário;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Turno { get => turno; set => turno = value; }
        public string Mbti { get => mbti; set => mbti = value; }
        public string Horário { get => horário; set => horário = value; }
    }
}
