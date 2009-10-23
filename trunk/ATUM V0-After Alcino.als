module ATUM

//===============================
// ----- Assinaturas ----------------------------
//===============================

sig ATUM {
	inscritos: Aluno -> set Disciplina,

	turnos: Disciplina -> set Turno,

	preferencias: Aluno -> set Turno,

	alocados: Aluno -> set Turno
}

sig Aluno {}

sig Disciplina {}

sig Turno {}

//===============================
// ----- Predicados ----------------------------
//===============================

pred Turno_Pertence_Uma_Disciplina [at: ATUM] {
	all t: Turno | one d: Disciplina | d = (at.turnos).t 
}

pred Alocado_Num_Turno_Por_Disciplina [at: ATUM] {
	all a: Aluno | all d: at.inscritos[a] | one t: Turno | t in at.turnos[d]
}

pred Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at: ATUM] {
	all a: Aluno | all t: at.alocados[a] | one d: at.inscritos[a] | t in at.turnos[d]
}

/*
pred Candidatura_Todos_Turno_Uma_Disciplina [at: ATUM] {
	all c: at.cands | (c.preferencias) = c.disciplina.turnos
}

pred Uma_Candidatura_Por_Disciplina [at: ATUM] {
	all a: at.alunos | all d: a.inscrito | lone disciplina.d
}

pred Alocado_Em_Disciplina_Candidatou [at: ATUM] {
	all a: at.alunos | a.alocado in a.candidaturas.preferencias
}
*/

pred Todos_Predicados [at: ATUM] {
	Turno_Pertence_Uma_Disciplina [at]
	Alocado_Num_Turno_Por_Disciplina [at]
	Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at]
--	Candidatura_Todos_Turno_Uma_Disciplina [at]
--	Uma_Candidatura_Por_Disciplina [at]
--	Alocado_Em_Disciplina_Candidatou [at]
}



//===============================
// ----- Operações- ----------------------------
//===============================

// Fazer uma candidatura
/*
pred Fazer_Uma_Candidatura [at, at':ATUM, c: Candidatura] {
	c not in at.cands

	at'.alunos = at.alunos
	at'.disciplinas = at.disciplinas
	at'.cands = at.cands + c
}

assert Fazer_Uma_Candidatura_Ok {
	all at,at': ATUM | all c: Candidatura | Todos_Predicados [at] && Fazer_Uma_Candidatura [at, at' , c] =>Todos_Predicados [at']
}*/

//
// Comandos
//

// Facto para ajudar com os testes. Apagar no fina!

run {}

run Todos_Predicados

//check Fazer_Uma_Candidatura_Ok

// Factos Velhos

// Garantir que um turno só pertençe a uma disciplina
/*
fact Turno_Pertence_Uma_Disciplina {
	// Para todos os turnos existe uma disciplina a qual o turno pertençe
	all t: Turno | one d: Disciplina | t in d.turnos
}*/


// Garantir que cada Aluno só tem um turno por disciplina 
/*
fact Alocado_Num_Turno_Por_Disciplina {
	// Para todos os alunos e para todas as disciplinas de cada aluno, 
	// existe apenas um turno dessa disciplina onde ele está alocado
	all a: Aluno | all d: a.inscrito | one t: a.alocado | t in d.turnos
}*/

// Garantir que cada Aluno só tem turnos de disciplinas a que se encontra matriculado
/*
fact Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado {
	// Para todos os alunos e para cada turno de cada aluno
	// existe apenas uma disciplina a que esse turno pertença
	all a: Aluno | all t: a.alocado | one d: a.inscrito | t in d.turnos
}*/

// Uma candidatura tem de ser para todos turnos da mesma disciplina
/*
fact Candidatura_Uma_So_Disciplina{
	all c: Candidatura | (c.preferencias) = c.disciplina.turnos
}
*/

// Garantir que cada aluno só faz uma candidatura por disciplina
/*
fact Uma_Candidatura_Por_Disciplina {
	// Para todos os Alunos, e todas as Disciplinas a que se encontra inscrito
	// Deverá existir np máximo uma candidatura por cada Disciplina
	all a: Aluno | all d: a.inscrito | lone disciplina.d
}
*/

// Carantir que um aluno só é alocado se existe uma candiidatura
/*
fact Alocado_Em_Diciplina_Candidatou {
	all a: Aluno | a.alocado in a.candidaturas.preferencias
}
*/