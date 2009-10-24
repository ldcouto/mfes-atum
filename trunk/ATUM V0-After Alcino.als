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

//===============================
// ----- Predicados sobre Turnos -----------------

// Garantir que um Turno pretence apenas a uma Disciplina
pred Turno_Pertence_Uma_Disciplina [at: ATUM] {
	all t: Turno | one d: Disciplina | d = (at.turnos).t 
}

//===============================
// ----- Predicados sobre Alunos -----------------

// Garantir que um Aluno apenas é alocado num turno por Disciplina
pred Alocado_Num_Turno_Por_Disciplina [at: ATUM] {
	all a: Aluno | all d: at.inscritos[a] | one t: Turno | t in at.turnos[d]
}

// Garantir que um Aluno apenas é alocado em Turnos 
// de Disciplinas em que está matriculado
pred Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at: ATUM] {
	all a: Aluno | all t: at.alocados[a] | one d: at.inscritos[a] | t in at.turnos[d]
}

// Garantir que um Aluno apenas tem preferencia por 
// Disciplinas a que se encontra inscrito 
pred Apenas_Tem_Preferencia_Se_Inscrito [at: ATUM] {
	all a: Aluno | at.preferencias[a] in at.inscritos[a].(at.turnos) 
}

// Garantir que um Aluno apenas é alocado se tiver preferencia por um turno
pred Apenas_Alocado_Se_Tem_Preferencia [at: ATUM] {
	all a: Aluno | at.alocados[a] in at.preferencias[a]
}

pred Todos_Predicados [at: ATUM] {
	Turno_Pertence_Uma_Disciplina [at]
	Alocado_Num_Turno_Por_Disciplina [at]
	Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at]
	Apenas_Alocado_Se_Tem_Preferencia [at]
	Apenas_Tem_Preferencia_Se_Inscrito [at]
}




//===============================
// ----- Invariantes -----------------------------
//===============================

pred Inv_AllPreds[at:ATUM] {
	Turno_Pertence_Uma_Disciplina [at]
	Alocado_Num_Turno_Por_Disciplina [at]
	Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at]
	Apenas_Alocado_Se_Tem_Preferencia [at]
	Apenas_Tem_Preferencia_Se_Inscrito [at]
}

pred Inv_PreAloc [at: ATUM] {
	Turno_Pertence_Uma_Disciplina [at]
	Apenas_Tem_Preferencia_Se_Inscrito [at]
}

pred Inv_PosAloc [at: ATUM] {
	Inv_PreAloc [at]

	Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at]
	Alocado_Num_Turno_Por_Disciplina [at]
//	Apenas_Alocado_Se_Tem_Preferencia [at]
}


//===============================
// ----- Operações -----------------------------
//===============================

pred Alocacao [at, at' : ATUM, a: Aluno] {
	no at.alocados[a]
	some at.preferencias[a]

	at'.inscritos = at.inscritos
	at'.turnos = at.turnos
	at'.preferencias = at.preferencias
	all d: at.inscritos[a] | one al: (at.turnos[d]) & (at.preferencias[a]) | at'.alocados = at.alocados + (a->al)

--	one al : Turno |  at'.alocados[a] |

	--	no 
	--	at'.alocados = at.alocados +(a->al)
		
}

/*
pred Alocacao [at, at' : ATUM, a: Aluno] {
	no at.alocados[a]
	some at.preferencias[a]

	at'.inscritos = at.inscritos
	at'.turnos = at.turnos
	one al : at.alocados[a] | 	at'.alocados = at.alocados +(a->al)
}
*/
assert Alocacao_Ok {
	all at, at': ATUM | all a: Aluno | Inv_PreAloc[at] && Alocacao[at,at',a] => Inv_PosAloc[at']
}

check Alocacao_Ok for 3 but exactly 1 Aluno, exactly 2 ATUM

/*
pred Alocacao_Test [at, at' : ATUM, a: Aluno] {
	Inv[fs]
	mkdir[fs,fs',d]
}

run mkdir_TEST for 3 but 2 FS
*/
//===============================
// ----- Comandos -----------------------------
//===============================

// Facto para ajudar com os testes. Apagar no fina!

run {}

run Todos_Predicados for 3 but exactly 1 ATUM



//===============================
// ----- Tralha Velha Pra Apagar-----------
//===============================



/*assert TestaPrefsInsc {

	all at : ATUM |  Todos_Predicados[at] => no at.preferencias[Aluno] - (at.inscritos[Aluno]).(at.turnos)
}*/


--check TestaPrefsInsc for 3 but exactly 1 ATUM

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
