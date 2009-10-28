module ATUM

open util/ordering[Vagas]

//===============================
// ----- Assinaturas ----------------------------
//===============================

sig ATUM {
	inscritos: Aluno -> set Disciplina,

	turnos: Disciplina -> set Turno,

	preferencias: Aluno -> set Turno,

	alocados: Aluno -> set Turno,

	processados: set Aluno,

	vagas: Turno -> one Capacidade
}

sig Aluno {}

sig Disciplina {}

sig Turno {}

sig Capacidade {}

//===============================
// ----- Predicados ----------------------------
//===============================

//===============================
// ----- Predicados sobre Turnos -----------------

// Garantir que um Turno pretence apenas a uma Disciplina
pred Turno_Pertence_Uma_Disciplina [at: ATUM] {
	all t: Turno | lone (at.turnos).t 
}

//===============================
// ----- Predicados sobre Alunos -----------------

// Garantir que um Aluno apenas é alocado num turno por Disciplina
pred Alocado_Num_Turno_Por_Disciplina [at: ATUM] {
	all a: at.processados, d: at.inscritos[a] | some (at.preferencias[a] & at.turnos[d]) => one (at.alocados[a] & at.turnos[d])
	all a: Aluno - at.processados | no at.alocados[a] 
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
	Apenas_Alocado_Se_Tem_Preferencia [at]
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

	at'.processados = at.processados + a
	at'.alocados = at.alocados + (a -> at.preferencias[a])
	all d: at.inscritos[a] | some (at.preferencias[a] & at.turnos[d]) => one (at'.alocados[a] & at.turnos[d])
}

// Nova alocação é igual a alocação velha mais 
//umas novas alocações quaisquer tais que “regras de alocação” (aloc in prefs… )
assert Alocacao_Ok {
	all at, at': ATUM | all a: Aluno | Inv_AllPreds[at] && Alocacao[at,at',a] => Inv_AllPreds[at']
}

pred Alocacao_Teste [at, at' : ATUM, a : Aluno] {
	Inv_AllPreds[at]
	Alocacao[at,at',a]
}

//===============================
// ----- Comandos -----------------------------
//===============================

run {}

run Todos_Predicados for 3 but exactly 1 ATUM

run Alocacao_Teste for 3 but 2 ATUM, exactly 1 Aluno, exactly 2 Disciplina

check Alocacao_Ok for 3 but exactly 1 Aluno, exactly 2 Disciplina, exactly 2 ATUM
