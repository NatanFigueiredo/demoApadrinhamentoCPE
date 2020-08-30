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
        static Config Config = new Config();

        static void Main(string[] args)
        {
            LinkedList<Aluno> alunos = new LinkedList<Aluno>();
            string csvAlunos = Config.CsvAlunos;
            using (StreamReader sr = new StreamReader(csvAlunos))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] linha = currentLine.Split(';');
                    alunos.AddLast(new Aluno(linha[0], linha[1], linha[2], linha[3]));
                }
                alunos.RemoveFirst();
            }


            LinkedList<Padrinho> padrinhos = new LinkedList<Padrinho>();
            string csvADM = Config.CsvPadrinhos;
            using (StreamReader sr = new StreamReader(csvADM))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] linha = currentLine.Split(';');
                    padrinhos.AddLast(new Padrinho(linha[0], linha[1], linha[2], linha[3]));
                }
                padrinhos.RemoveFirst();
            }



            LinkedList<Match> matchesMBTI = new LinkedList<Match>();
            LinkedList<Match> matchesHorario = new LinkedList<Match>();

            Console.WriteLine(alunos.Count);


            /*
             * for(LinkedListNode<Object> node=list.First; node != null; node=node.Next){
             */

            LinkedListNode<Aluno> a = alunos.First;
            while (a != null)
            {
                bool hasMatch = false;
                foreach (Padrinho p in padrinhos)
                {
                    if (a.Value.mbti.Equals(p.mbti))
                    {
                        matchesMBTI.AddLast(new Match(a.Value, p));
                        hasMatch = true;
                    }

                    if (validaHorario(a.Value.horario, p.horario))
                    {
                        matchesHorario.AddLast(new Match(a.Value, p));
                        hasMatch = true;
                    }
                }

                LinkedListNode<Aluno> next = a.Next;
                if (hasMatch) alunos.Remove(a);

                a = next;
            }

            //SalvaMatch(matchesHorario, "Horario");
            SalvaMatch(matchesMBTI, "MBTI");
            SalvaAlunos(alunos, "Alunos");

            Console.WriteLine("Finalizado");
            Console.ReadLine();
        }

        static bool validaHorario(string hAluno, string hPadrinho)
        {
            if (((hAluno.Contains("Tarde") || hAluno.Contains("Manhã")) && (hPadrinho.Equals("Ambos") || hPadrinho.Equals("Vespertino"))) ||
                (hAluno.Contains("Noite") && (hPadrinho.Equals("Ambos") || hPadrinho.Equals("Noturno"))))
                return true;
            return false;
        }

        static void SalvaMatch(LinkedList<Match> list, string Name)
        {
            string path = Config.Saida;
            /*
             * (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")
             */
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, $"Match{Name}.csv")))
            {
                foreach (Match m in list)
                {
                    string linha;
                    linha = $"{m.afilhado.nome};{m.afilhado.turno};{m.afilhado.horario};{m.afilhado.mbti};";
                    linha += $"{m.padrinho.nome};{m.padrinho.ocupacao};{m.padrinho.horario};{m.padrinho.mbti};";
                    sw.WriteLine(linha);
                }
            }
        }

        static void SalvaAlunos(LinkedList<Aluno> list, string Name)
        {
            string path = Config.Saida;
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, $"{Name}SemMatch.csv")))
            {
                foreach (Aluno m in list)
                {
                    string linha;
                    linha = $"{m.nome};{m.turno};{m.horario};{m.mbti};;;;;";
                    sw.WriteLine(linha);
                }
            }

        }



    }
}
