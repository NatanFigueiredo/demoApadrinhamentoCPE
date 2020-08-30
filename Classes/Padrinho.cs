using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento.Classes
{
    class Padrinho
    {
        public string nome { get; set; }
        public string mbti { get; set; }
        public string ocupacao { get; set; }
        public string horario { get; set; }

        public Padrinho(string nome, string mbti, string ocupacao, string horario)
        {
            this.nome = nome;
            this.mbti = mbti;
            this.ocupacao = ocupacao;
            this.horario = horario;
        }

        public override string ToString()
        {
            return nome + ' ' + mbti + ' ' + ocupacao + ' ' + horario;
        }
    }
}
