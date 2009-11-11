module ATUM

open util/ordering[Capacidade]

-- VAMOS PRECISAR DE PREFERENCIA TOTAL SOBRE OS TURNOS
-- PACKS DE CADEIRAS - escolher horarios completos

//===============================
// ----- Assinaturas ----------------------------
//===============================

sig ATUM {
	inscritos: Aluno -> set Disciplina,

	turnos: Disciplina -> set Turno,
	preferencias: Aluno -> set Turno,
	alocados: Aluno -> set Turno,
	vagas: Turno -> one Capacidade,

	processados: set Aluno,

	blocos: Bloco ->some Turno,
	prefereBloco: Aluno -> set Bloco
}

sig Bloco {}
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

// Disciplina tem Vagas
pred Ha_Vagas [at: ATUM, a: Aluno, d: Disciplina] {
	 some t: (at.preferencias[a] & at.turnos[d]) | at.vagas[t] !=first
}

// Alunos foram bem alocados
pred Bem_Alocados[at:ATUM]{
	all a: at.processados| all d : at.turnos.Turno | (some t :  (at.turnos[d] & at.preferencias[a]) | t in at.alocados[a])
                                                                       or (all t :  (at.turnos[d] & at.preferencias[a]) | at.vagas[t] = first)
}

//===============================
// ----- Predicados sobre Blocos -----------------

pred Um_Turno_Por_Disciplina [at: ATUM] {
	all b: at.blocos.Turno | all t1,t2: at.blocos[b] | at.turnos.t1 = at.turnos.t2 => t1 = t2
}

pred Apenas_Disciplinas_A_Que_Inscrito [at: ATUM] {
	all a: Aluno | all b: at.blocos.Turno | at.prefereBloco[a] = b => at.blocos[b] in at.turnos[at.inscritos[a]]
}

//===============================
// ----- Predicados sobre Alunos -----------------

// Garantir que um Aluno apenas é alocado num turno por Disciplina
pred Alocado_Num_Turno_Por_Disciplina [at: ATUM] {
	all a: at.processados, d: at.inscritos[a] | some (at.preferencias[a] & at.turnos[d]) => lone (at.alocados[a] & at.turnos[d])
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

pred Inv_AllPreds[at:ATUM] {
	Turno_Pertence_Uma_Disciplina [at]
	Alocado_Num_Turno_Por_Disciplina [at]
	--Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at]
	Apenas_Alocado_Se_Tem_Preferencia [at]
	Apenas_Tem_Preferencia_Se_Inscrito [at]
	Bem_Alocados[at]
	Um_Turno_Por_Disciplina[at]
	Apenas_Disciplinas_A_Que_Inscrito[at]
}

//===============================
// ----- Operações -----------------------------
//===============================

// INSERIR ALUNO
pred Inserir_Aluno[at, at' : ATUM, a:Aluno]{
	a not in at.inscritos.Disciplina
	a not in at.preferencias.Turno
	a not in at.alocados.Turno
	a not in at.processados
	a not in at.prefereBloco.Bloco

	some insc : ( a->some Disciplina) | at'.inscritos = at.inscritos + insc

	a in at'.inscritos.Disciplina	

	at'.turnos=at.turnos
	at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados
	at'.vagas=at.vagas
	
	at'.blocos = at.blocos
	at'.prefereBloco = at.prefereBloco
}

assert Inserir_Aluno_Ok {
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Inserir_Aluno[at,at',a] => Inv_AllPreds[at']
}
pred Inserir_Aluno_Teste[at,at': ATUM, a: Aluno]{
	Inv_AllPreds[at]
	Inserir_Aluno[at,at',a]
}

// INSERIR DISCIPLINA
pred Inserir_Disciplina[at, at' : ATUM, d:Disciplina]{
	no at.inscritos
	d not in at.turnos.Turno

-- UMA DISC ENTRA SEMPRE COM UM TURNO	
	some t : Turno-at.turnos[Disciplina]| at'.turnos = at.turnos + d->t

	at'.inscritos=at.inscritos
	at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados
	at'.vagas=at.vagas

	at'.blocos = at.blocos
	at'.prefereBloco = at.prefereBloco
}

assert Inserir_Disciplina_Ok {
	all at,at': ATUM | all d: Disciplina | Inv_AllPreds[at] && Inserir_Disciplina[at,at',d] => Inv_AllPreds[at']
}
pred Inserir_Disciplina_Teste[at,at': ATUM, d: Disciplina]{
	Inv_AllPreds[at]
	Inserir_Disciplina[at,at',d]
}

// ADICIONAR TURNO
pred Inserir_Turno[at, at' : ATUM, d:Disciplina, t:Turno, c:Capacidade]{
	no at.inscritos
	t not in at.turnos[Disciplina]
	t not in at.blocos[Bloco]

	at'.vagas=at.vagas+(t->c)
	at'.turnos=at.turnos+(d->t)

	at'.inscritos=at.inscritos
	at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados

	at'.blocos = at.blocos
	at'.prefereBloco = at.prefereBloco
}

assert Inserir_Turno_Ok {
	all at,at': ATUM | all d: Disciplina | all t:Turno | all c:Capacidade |
		Inv_AllPreds[at] && Inserir_Turno[at,at',d,t,c] => Inv_AllPreds[at']
}
pred Inserir_Turno_Teste[at,at': ATUM, d: Disciplina, t:Turno, c:Capacidade]{
	Inv_AllPreds[at]
	Inserir_Turno[at,at',d,t,c]
}

// ALOCAR ALUNO
pred Alocacao [at, at' : ATUM, a: Aluno] {
	no at.alocados[a]
	some at.preferencias[a]

-- TEM DE TER VAGaS!
	at'.inscritos = at.inscritos
	at'.turnos = at.turnos
	at'.preferencias = at.preferencias	
	at'.processados = at.processados + a
	at'.blocos =at.blocos
	at'.prefereBloco = at.prefereBloco

	at'.alocados[a] in at.preferencias[a]
	all x : Aluno - a | at'.alocados[x] = at.alocados[x]
	all d: at.inscritos[a] |  Ha_Vagas[at,a,d] => one (at'.alocados[a] & at.turnos[d])
	all t : at'.alocados[a] | at'.vagas[t] = at.vagas[t].prev
	all t: at.vagas.Capacidade - at.alocados[a] | at'.vagas[t] = at.vagas[t]
}

assert Alocacao_Ok {
	all at, at': ATUM | all a: Aluno | Inv_AllPreds[at] && Alocacao[at,at',a] => Inv_AllPreds[at']
}

pred Alocacao_Teste [at, at' : ATUM, a : Aluno] {
	Inv_AllPreds[at]
--	at != at'

	Alocacao[at,at',a]
}

//===============================
// ----- Comandos -----------------------------
//===============================

check Inserir_Aluno_Ok for 3 but exactly 2 ATUM
run Inserir_Aluno_Teste for 3 but exactly 2 ATUM

check Inserir_Disciplina_Ok for 3 but exactly 2 ATUM
run Inserir_Disciplina_Teste for 3 but exactly 2 ATUM

check Inserir_Turno_Ok for 3 but exactly 2 ATUM
run Inserir_Turno_Teste for 3 but exactly 2 ATUM

check Alocacao_Ok for 3 but exactly 2 ATUM
run Alocacao_Teste for 3 but exactly 2 ATUM

run Inv_AllPreds for 3 but 1 ATUM
