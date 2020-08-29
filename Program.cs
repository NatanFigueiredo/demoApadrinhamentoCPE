using demoApadrinhamento.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Aluno> alunos = new LinkedList<Aluno>();


            LinkedList<Padrinho> padrinhos = new LinkedList<Padrinho>();
            string csvADM = @"C:\Users\natan\Desktop\CPE\Apadrinhamento 2020-2";

            using (StreamReader sr = new StreamReader(csvADM))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] linha = currentLine.Split(';');
                }
            }
            /*
             * 
             */



            LinkedList<Match> matchesMBTI = new LinkedList<Match>();
            LinkedList<Match> matchesHorario = new LinkedList<Match>();

            foreach (Aluno a in alunos)
            {
                bool hasMatch = false;
                foreach (Padrinho p in padrinhos)
                {
                    if (a.mbti.Equals(p.mbti))
                    {
                        matchesMBTI.AddLast(new Match(a, p));
                        hasMatch = true;
                    }
                    if (a.horario.Equals(p.horario))
                    {
                        matchesHorario.AddLast(new Match(a, p));
                        hasMatch = true;
                    }
                }

                if (hasMatch) alunos.Remove(a);
            }
        }

        void CSVtoList(StreamReader stream, LinkedList<Aluno> lista)
        {
            
        }
    }
}
