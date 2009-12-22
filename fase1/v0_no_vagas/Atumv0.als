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

------ Não é preciso
// Garantir que um Aluno apenas é alocado em Turnos 
// de Disciplinas em que está matriculado
//pred Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at: ATUM] {
//	all a: Aluno | all t: at.alocados[a] | one d: at.inscritos[a] | t in at.turnos[d]
//}
------ Não é preciso

check {
all at :ATUM | Inv_AllPreds[at]  => Inv_AllPreds[at] and all a: Aluno | all t: at.alocados[a] | one d: at.inscritos[a] | t in at.turnos[d]
} for 6

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
	Apenas_Alocado_Se_Tem_Preferencia [at]
	Apenas_Tem_Preferencia_Se_Inscrito [at]
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

	some insc : ( a->some Disciplina) | at'.inscritos = at.inscritos + insc

	a in at'.inscritos.Disciplina	

	at'.turnos=at.turnos
	at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados
}

/*
assert Inserir_Aluno_Conseq{
		all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Inserir_Aluno[at,at',a] 
			=> Inv_AllPreds[at'] and at.inscritos[Aluno] != at.inscritos[a]
}

check Inserir_Aluno_Conseq for 3 but exactly 2 ATUM
*/

assert Inserir_Aluno_Ok {
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Inserir_Aluno[at,at',a] => Inv_AllPreds[at']
}

pred Inserir_Aluno_Teste[at,at': ATUM, a: Aluno]{
	Inv_AllPreds[at]
	Inserir_Aluno[at,at',a]
}

// Remoção de Aluno
pred Remover_Aluno [at,at': ATUM, a: Aluno]{
	at'.inscritos = at.inscritos - (a -> at.inscritos[a])
	at'.turnos = at.turnos
	at'.alocados = at.alocados - (a -> at.alocados[a])
	at'.processados = at.processados - a
	at'.preferencias = at.preferencias - (a -> at.preferencias[a])
}

assert Remover_Aluno_Ok {
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Remover_Aluno[at,at',a] => Inv_AllPreds[at']
}

pred Remover_Aluno_Teste[at,at': ATUM, a: Aluno]{
	Inv_AllPreds[at]
	Remover_Aluno[at,at',a]
}

// Inserção de disciplinas
pred Inserir_Disciplina[at, at' : ATUM, d:Disciplina]{
	no at.inscritos
	d not in at.turnos.Turno

-- UMA DISC ENTRA SEMPRE COM UM TURNO	
	some t : Turno-at.turnos[Disciplina]| at'.turnos = at.turnos + (d->t)

	at'.inscritos=at.inscritos
	at'.alocados=at.alocados
	at'.processados=at.processados
	at'.preferencias=at.preferencias
}

assert Inserir_Disciplina_OK {
	all at,at': ATUM | all d: Disciplina | Inv_AllPreds[at] && Inserir_Disciplina[at,at',d] => Inv_AllPreds[at']
}

pred Inserir_Disciplina_Teste [at,at':ATUM, d: Disciplina] {
	Inv_AllPreds[at]
	Inserir_Disciplina[at,at',d]
}

// Remoção de disciplinas
pred Remover_Disciplina[at,at': ATUM, d: Disciplina]{
	at'.inscritos = at.inscritos - (at.inscritos.d -> d)
	at'.turnos = at.turnos - (d -> at.turnos[d])
	at'.alocados = at.alocados - (Aluno -> at.turnos[d])
	at'.processados = at.processados
	at'.preferencias = at.preferencias - (Aluno -> at.turnos[d])
}

assert Remover_Disciplina_OK {
	all at,at': ATUM | all d: Disciplina | Inv_AllPreds[at] && Remover_Disciplina[at,at',d] => Inv_AllPreds[at']
}

pred Remover_Disciplina_Teste [at,at':ATUM, d: Disciplina] {
	Inv_AllPreds[at]
	Remover_Disciplina[at,at',d]
}

// Inserir Turno
pred Inserir_Turno[at, at' : ATUM, d:Disciplina, t:Turno]{
	no at.inscritos
	t not in at.turnos[Disciplina]

	at'.turnos = at.turnos + (d->t)

	at'.inscritos=at.inscritos
	at'.alocados=at.alocados
	at'.processados=at.processados
	at'.preferencias=at.preferencias
}

assert Inserir_Turno_OK {
	all at,at': ATUM | all d: Disciplina | all t:Turno | Inv_AllPreds[at] && Inserir_Turno[at,at',d,t] => Inv_AllPreds[at']
}

pred Inserir_Turno_Teste [at,at':ATUM, d: Disciplina, t:Turno] {
	Inv_AllPreds[at]
	Inserir_Turno[at,at',d,t]
}

// Remoção de Turno
pred Remover_Turno[at, at' : ATUM, t:Turno]{
	no at.alocados.t

	at'.inscritos = at.inscritos
	at'.alocados = at.alocados
	at'.turnos = at.turnos - (at.turnos.t -> t)
	at'.processados = at.processados
	at'.preferencias = at.preferencias - (at.preferencias.t -> t)
}

assert Remover_Turno_OK {
	all at,at': ATUM | all t:Turno | Inv_AllPreds[at] && Remover_Turno[at,at',t] => Inv_AllPreds[at']
}

pred Remover_Turno_Teste [at,at':ATUM, d: Disciplina, t:Turno] {
	Inv_AllPreds[at]
	Remover_Turno[at,at',t]
}

//===============================
// ----- Comandos -----------------------------
//===============================

run {}

check Alocacao_Ok for 3 but exactly 2 ATUM
run Alocacao_Teste for 3 but exactly 2 ATUM

check Inserir_Aluno_Ok for 3 but exactly 2 ATUM
run Inserir_Aluno_Teste for 3 but exactly 2 ATUM

check Remover_Aluno_Ok for 3 but exactly 2 ATUM
run Remover_Aluno_Teste for 3 but exactly 2 ATUM

check Inserir_Disciplina_OK for 3 but exactly 2 ATUM
run Inserir_Disciplina_Teste for 3 but exactly 2 ATUM

check Remover_Disciplina_OK for 3 but exactly 2 ATUM
run Remover_Disciplina_Teste for 3 but exactly 2 ATUM

check Inserir_Turno_OK for 3 but exactly 2 ATUM
run Inserir_Turno_Teste for 3 but exactly 2 ATUM

check Remover_Turno_OK for 3 but exactly 2 ATUM
run Remover_Turno_Teste for 3 but exactly 2 ATUM

run Inv_AllPreds for 6 but exactly 1 ATUM

