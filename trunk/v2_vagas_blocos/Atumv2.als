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
	turnosDisciplina: Disciplina -> set Turno,
	turnosBloco: Bloco ->some Turno,
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
	all t: Turno | lone (at.turnosDisciplina).t 
}

// Garantir que um Bloco só tem um turno por disciplina
pred Um_Turno_Por_Disciplina [at: ATUM] {
	all b: at.turnosBloco.Turno, d :at.turnosDisciplina.Turno | lone at.turnosBloco[b] & at.turnosDisciplina[d]
}

// Garantir que um bloco não tem turnos sem disciplina
pred So_Turnos_Legitimos[at:ATUM]{
	no at.turnosBloco[Bloco] - at.turnosDisciplina[Disciplina]
}

// Dois blocos iguais são o mesmo bloco
pred Nao_Ha_Blocos_Iguais[at:ATUM]{
--	all disj b1, b2: at.turnosBloco.Turno | no (b1-b2)
	all disj b1, b2 : at.turnosBloco.Turno | at.turnosBloco[b1] != at.turnosBloco[b2]
}

//===============================
// ----- Predicados sobre Alunos -----------------

// Um aluno só quer blocos para os quais está inscrito a todas as disciplinas
pred So_Quer_Blocos_Inscrito[at:ATUM]{
	all a : Aluno | at.turnosBloco[(at.prefereBloco[a])] in at.turnosDisciplina[(at.inscritos[a])]
}

// Garantir que todos os turnos a que um aluno foi alocado pertencem a UM mesmo bloco preferido do aluno
pred Aluno_Ta_Num_Bloco[at:ATUM]{
	all a:at.processados | (one b:at.prefereBloco[a] | at.alocados[a] = at.turnosBloco[b]) or no at.alocados[a]
}

// Não alocar alunos que ainda não foram processados
pred Aluno_Nao_Foi_Alocado[at:ATUM]{
	all a: Aluno - at.processados | no at.alocados[a] 
}

// Aluno apenas é alocado a turnos que pertençam a um dos seus blocos preferidos
pred Apenas_Alocado_Se_Tem_Preferencia [at: ATUM] {
	all a: at.processados | at.alocados[a] in at.turnosBloco[(at.prefereBloco[a])]
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
	all t: at.turnosBloco[b] | at.vagas[t] != first
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

	at'.turnosDisciplina=at.turnosDisciplina
	--at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados
	at'.vagas=at.vagas
	
	at'.turnosBloco = at.turnosBloco
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
	d not in at.turnosDisciplina.Turno

-- UMA DISC ENTRA SEMPRE COM UM TURNO	
	some t : Turno-at.turnosDisciplina[Disciplina]| at'.turnosDisciplina = at.turnosDisciplina + d->t

	at'.inscritos=at.inscritos
	--at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados
	at'.vagas=at.vagas

	at'.turnosBloco = at.turnosBloco
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
	t not in at.turnosDisciplina[Disciplina]
	t not in at.turnosBloco[Bloco]

	at'.vagas=at.vagas+(t->c)
	at'.turnosDisciplina=at.turnosDisciplina+(d->t)

	at'.inscritos=at.inscritos
--	at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados

	at'.turnosBloco = at.turnosBloco
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

--------------------------
// ALOCAR ALUNO

pred Aloca_Aluno[at,at': ATUM, a: Aluno] {
	no at.alocados[a]
	a not in at.processados
	some at.prefereBloco[a]
	
	no at'.alocados[a] => all b:at.prefereBloco[a] | not Bloco_Tem_Vagas[at,b]
	one b:at.prefereBloco[a] | at.turnosBloco[b]=at'.alocados[a] or no at'.alocados[a]

	all t: at'.alocados[a] | at'.vagas[t] = at.vagas[t].prev

	at'.inscritos = at.inscritos
	at'.turnosDisciplina = at.turnosDisciplina
	at'.turnosBloco = at.turnosBloco
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
run Aloca_Aluno_Teste for 3 but exactly 2 ATUM, 1 Aluno

run Inv_AllPreds for 3 but 1 ATUM
