module ATUM

//===============================
// ----- Assinaturas ----------------------------
//===============================

sig ATUM {
	inscritos: Aluno -> set Disciplina,

	turnos: Disciplina -> set Turno,

	preferencias: Aluno -> set Turno,

	alocados: Aluno -> set Turno,

	processados: set Aluno
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

// Alocação

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

assert Alocacao_Ok {
	all at, at': ATUM | all a: Aluno | Inv_AllPreds[at] && Alocacao[at,at',a] => Inv_AllPreds[at']
}

pred Alocacao_Teste [at, at' : ATUM, a : Aluno] {
	Inv_AllPreds[at]
	Alocacao[at,at',a]
}

// Inserção de alunos

pred Inserir_Aluno [at, at': ATUM, a: Aluno] {
	a not in at.inscritos.Disciplina
	a not in at.preferencias.Turno
	a not in at.alocados.Turno
	a not in at.processados
	
	at'.inscritos = at.inscritos + (a -> set Disciplina)
	at'.turnos = at.turnos
	at'.preferencias = at.preferencias + (a -> set Turno)
	at'.processados = at.processados
	at'.alocados = at.alocados
}

assert Inserir_Aluno_Ok {
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Inserir_Aluno[at,at',a] => Inv_AllPreds[at']
}

pred Inserir_Aluno_Teste[at,at': ATUM, a: Aluno]{
	Inv_AllPreds[at]
	Inserir_Aluno[at,at',a]
}

// Inserção de disciplina

pred Inserir_Disciplina [at,at': ATUM, d: Disciplina] {
	d not in at.inscritos[Aluno]
	d not in at.turnos.Turno
	
	at'.inscritos = at.inscritos
	at'.turnos = at.turnos + (d -> set Turno)
	at'.preferencias = at.preferencias
	at'.processados = at.processados
	at'.alocados = at.alocados
}

//===============================
// ----- Comandos -----------------------------
//===============================

run {}

run Inv_AllPreds for 6 but exactly 1 ATUM

run Alocacao_Teste for 6 but exactly 2 ATUM, exactly 1 Aluno

check Alocacao_Ok for 6 but exactly 2 ATUM, exactly 1 Aluno

run Inserir_Aluno_Teste for 6 but exactly 2 ATUM

check Inserir_Aluno_Ok for 6 but exactly 2 ATUM

