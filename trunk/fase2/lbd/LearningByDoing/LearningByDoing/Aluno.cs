using System;
using System.Collections.Generic;

namespace LearningByDoing
{
    public class Aluno
    {
        public String Identifier { get; set; }

        public IList<Disciplina> Inscrito { get; private set; }
        public IList<Turno> AlocadoTurno { get; private set; }
        public Bloco AlocadoBloco { get; set; }

        public Queue<Bloco> PreferenciasBlocos { get; private set; }

        public bool Processado { get; private set; }

        public Aluno(String id, IList<Disciplina> insc)
        {
            Identifier = id;

            Inscrito = insc;
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = new Queue<Bloco>();
            Processado = false;
        }

        public void AddInscricao(Disciplina d)
        {
            if (!Inscrito.Contains(d))
                Inscrito.Add(d);
        }

        public bool RemoveInscricao(Disciplina d)
        {
            return Inscrito != null && Inscrito.Remove(d);
        }

        public void AddPreferencia(Bloco b)
        {
            if (!PreferenciasBlocos.Contains(b))
                PreferenciasBlocos.Enqueue(b);
        }

        // Alocar - Tentativa
        public bool AlocaBloco()
        {
            foreach (Bloco bloco in PreferenciasBlocos)
            {
                if (bloco.TemVagas())
                {
                    AlocadoTurno = bloco.TurnosBloco;
                    bloco.DecrementarVagas();
                    return true;
                }
            }
            return false;
        }
    }
}
