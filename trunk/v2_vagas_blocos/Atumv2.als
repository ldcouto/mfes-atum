module ATUM

open util/ordering[Capacidade]

-- VAMOS PRECISAR DE PREFERENCIA TOTAL SOBRE OS TURNOS
-- PACKS DE CADEIRAS - escolher horarios completos

//===============================
// ----- Assinaturas ----------------------------
//===============================

sig ATUM {
	inscritos: Aluno -> set Disciplina,
	alocados: Aluno -> set Turno,
	processados: set Aluno,
	prefereBloco: Aluno -> set Bloco,
	turnos: Disciplina -> set Turno,
	blocos: Bloco ->some Turno,
	vagas: Turno -> one Capacidade
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
// --- Predicados sobre Turnos e Blocos ------

// Garantir que um Turno pretence apenas a uma Disciplina
pred Turno_Pertence_Uma_Disciplina [at: ATUM] {
	all t: Turno | lone (at.turnos).t 
}

// Garantir que um Bloco só tem um turno por disciplina
pred Um_Turno_Por_Disciplina [at: ATUM] {
	all b: at.blocos.Turno, d :at.turnos.Turno | lone at.blocos[b] & at.turnos[d]
}

// Garantir que um bloco não tem turnos sem disciplina
pred So_Turnos_Legitimos[at:ATUM]{
	no at.blocos[Bloco] - at.turnos[Disciplina]
}


//===============================
// ----- Predicados sobre Alunos -----------------

// Dois blocos iguais são o mesmo bloco
pred Nao_Ha_Blocos_Iguais[at:ATUM]{
	all disj b1, b2: at.blocos.Turno | no (b1-b2)
}

// Um aluno só quer blocos para os quais está inscrito a todas as disciplinas
pred So_Quer_Blocos_Inscrito[at:ATUM]{
	all a : Aluno | at.blocos[(at.prefereBloco[a])] in at.turnos[(at.inscritos[a])]
}

// Garantir que todos os turnos a que um aluno foi alocado pertencem a UM mesmo bloco preferido do aluno
pred Aluno_Ta_Num_Bloco[at:ATUM]{
	all a:at.processados | (one b:at.prefereBloco[a] | at.alocados[a] = at.blocos[b]) or no at.alocados[a]
}

// Não alocar alunos que ainda não foram processados
pred Aluno_Nao_Foi_Alocado[at:ATUM]{
	all a: Aluno - at.processados | no at.alocados[a] 
}

// Aluno apenas é alocado a turnos que pertençam a um dos seus blocos preferidos
pred Apenas_Alocado_Se_Tem_Preferencia [at: ATUM] {
	all a: at.processados | at.alocados[a] in at.blocos[(at.prefereBloco[a])]
}

// Garantir que a Alocação foi bem feita
pred Bem_Alocados[at:ATUM]{
	all a: at.processados |  no at.alocados[a]  => all b:at.prefereBloco[a] | not Bloco_Tem_Vagas[at,b]	
}

//Todos os Invariantes
pred Inv_AllPreds[at:ATUM] {
	Nao_Ha_Blocos_Iguais[at]
	Turno_Pertence_Uma_Disciplina [at]
	So_Turnos_Legitimos[at]
	Um_Turno_Por_Disciplina[at]
	So_Quer_Blocos_Inscrito[at]
	Aluno_Ta_Num_Bloco[at]
	Aluno_Nao_Foi_Alocado[at]
	Apenas_Alocado_Se_Tem_Preferencia[at]
	Bem_Alocados[at]
}


//===============================
// ----- Predicados Auxiliares  -----------------

pred Bloco_Tem_Vagas [at: ATUM, b: Bloco] {
	all t: at.blocos[b] | at.vagas[t] != first
}


//===============================
// ----- Operações -----------------------------
//===============================

// INSERIR ALUNO
pred Inserir_Aluno[at, at' : ATUM, a:Aluno]{
	a not in at.inscritos.Disciplina
	--a not in at.preferencias.Turno
	a not in at.alocados.Turno
	a not in at.processados
	a not in at.prefereBloco.Bloco

	some insc : ( a->some Disciplina) | at'.inscritos = at.inscritos + insc

	a in at'.inscritos.Disciplina	

	at'.turnos=at.turnos
	--at'.preferencias=at.preferencias
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
	--at'.preferencias=at.preferencias
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
--	at'.preferencias=at.preferencias
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

/*
// ALOCAR ALUNO
pred Alocacao [at, at' : ATUM, a: Aluno] {
	no at.alocados[a]
	some at.preferencias[a]

-- TEM DE TER VAGaS!
	at'.inscritos = at.inscritos
	at'.turnos = at.turnos
	at'.preferencias = at.preferencias	
	at'.processados = at.processados + a

---------Para Apagar----------
	at'.blocos =at.blocos
	at'.prefereBloco = at.prefereBloco
---------Para Apagar----------

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
	Alocacao[at,at',a]
}
*/

pred Aloca_Aluno[at,at': ATUM, a: Aluno] {
	no at.alocados[a]
	some at.prefereBloco[a]

	at'.alocados[a] in at.blocos[at.prefereBloco[a]]
	

	all t: at'.alocados[a] | at'.vagas[t] = at.vagas[t].prev

	at'.inscritos = at.inscritos
	at'.turnos = at.turnos
	at'.blocos = at.blocos
	at'.prefereBloco = at.prefereBloco

	all x: Aluno - a | at'.alocados[x] = at.alocados[x]
	all t: at.vagas.Capacidade - at'.alocados[a] | at'.vagas[t] = at.vagas[t]
	at'.processados = at.processados + a
}

assert Aloca_Aluno_Ok{
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Aloca_Aluno[at,at',a] => Inv_AllPreds[at']
}

pred Aloca_Aluno_Teste[at,at': ATUM, a: Aluno] {
	Inv_AllPreds[at]
	Aloca_Aluno[at,at',a]
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

check Aloca_Aluno_Ok for 3 but exactly 2 ATUM, 1 Aluno
run Aloca_Aluno_Teste for 3 but exactly 2 ATUM

run Inv_AllPreds for 3 but 1 ATUM, exactly 2 Bloco
