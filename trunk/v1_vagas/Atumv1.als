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
	Apenas_Alocado_Se_Tem_Preferencia [at]
	Apenas_Tem_Preferencia_Se_Inscrito [at]
	Bem_Alocados[at]
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

	some insc : ( a->some Disciplina) | at'.inscritos = at.inscritos + insc

	a in at'.inscritos.Disciplina	

	at'.turnos=at.turnos
	at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados
	at'.vagas=at.vagas
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

	at'.vagas=at.vagas+(t->c)
	at'.turnos=at.turnos+(d->t)

	at'.inscritos=at.inscritos
	at'.preferencias=at.preferencias
	at'.alocados=at.alocados
	at'.processados=at.processados
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
	at != at'

	Alocacao[at,at',a]
}


// TROCAR ALUNO DE TURNO
// Trocar um aluno entre os turnos duma disciplina
pred Troca_Aluno [at: ATUM, a: Aluno, d:Disciplina]{
	a in at.processados
	some t: ( (at.preferencias[a] & at.turnos[d]) - at.alocados[a]) | at.vagas[t] != first
}

pred Faz_A_Troca[at, at' : ATUM, a:Aluno, d: Disciplina]{
	at'.inscritos = at.inscritos
	at'.turnos = at.turnos
	at'.preferencias = at.preferencias
	at'.processados = at.processados
	all a2 : Aluno - a | at'.alocados[a2] = at.alocados[a2]
	
		one t1 : (at.alocados[a] & at.turnos[d]) | 
			one t2 : (at.preferencias[a] & at.turnos[d] - at.alocados[a] ) |
				at'.vagas[t1] = at.vagas[t1].next
				and at'.vagas[t2] = at.vagas[t2].prev
				and at'.alocados[a] = at.alocados[a] - t1 + t2
				and all t : Turno - (t1+t2) | at'.vagas[t] = at.vagas[t]
	
}

assert Faz_A_Troca_Ok {
	all at, at': ATUM | all a: Aluno | all d:Disciplina |
		Inv_AllPreds[at] && Faz_A_Troca[at,at',a,d] => Inv_AllPreds[at']
}

pred Faz_A_Troca_Teste [at,at': ATUM, a: Aluno,d:Disciplina] {
	Inv_AllPreds[at]
	Troca_Aluno[at,a,d]
	Faz_A_Troca[at,at',a,d]
}

check Faz_A_Troca_Ok for 4 but exactly 1 Aluno, exactly 2 ATUM
run Faz_A_Troca_Teste for 4 but exactly 2 ATUM, exactly 1 Aluno, 2 Capacidade


// FAZER ALOCAÇÃO COM TROCA
pred Aloca_Com_Troca2[at,at',atx : ATUM, a:Aluno]{
-- não pode haver vagas!
	some d:at.turnos.Turno | some a2: at.processados | Troca_Aluno[at,a2,d] and Faz_A_Troca[at,atx,a2,d]
	Alocacao[atx,at',a]
}

assert ACT2_OK{
	all at, at': ATUM | all a: Aluno | Inv_AllPreds[at] 
		&& Aloca_Com_Troca[at,at',a] => Inv_AllPreds[at']
}
pred ACT2_Teste[at,at',atx:ATUM, a:Aluno]{
	Inv_AllPreds[at]
	Aloca_Com_Troca2[at,at',atx,a]
}

pred Aloca_Com_Troca[at,at' :ATUM, a:Aluno]{
	Alocacao[at,at',a] or 
	(not Alocacao[at,at',a] and one atx : ATUM 
	| Inv_AllPreds[atx] and Aloca_Com_Troca2[at,at',atx,a])
}

assert Aloca_Com_Troca_Ok {
	all at, at': ATUM | all a: Aluno | Inv_AllPreds[at] && Aloca_Com_Troca[at,at',a] => Inv_AllPreds[at']
}
pred Aloca_Com_Troca_Teste [at,at': ATUM, a: Aluno] {
	Inv_AllPreds[at]
	Aloca_Com_Troca [at,at',a]
}

pred Pos_Alocado[at:ATUM]{
	--at.inscritos.Disciplina = at.processados
	Aluno = at.processados
}

pred ATUMs_Iguais[at,at': ATUM]{
	at.inscritos = at'.inscritos
	at.turnos = at'.turnos
	at.preferencias = at'.preferencias
	at.processados = at'.processados
	at.vagas = at'.vagas
}

assert Melhor_Aloc{
 no at:ATUM | all at':ATUM-at |
	Inv_AllPreds[at'] and Inv_AllPreds[at] and Pos_Alocado[at] and Pos_Alocado[at'] and ATUMs_Iguais[at,at']
		and #at.alocados > #at'.alocados
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

check Aloca_Com_Troca_Ok for 4 but exactly 3 ATUM, exactly 2 Aluno
run Aloca_Com_Troca_Teste for 4 but exactly 3 ATUM, exactly 2 Aluno

check ACT2_OK  for 4 but exactly 3 ATUM, exactly 2 Aluno, 3 Capacidade, 1 Disciplina, 2 Turno
run ACT2_Teste  for 4 but exactly 3 ATUM, exactly 2 Aluno, 3 Capacidade, 1 Disciplina, 2 Turno

check Melhor_Aloc for 3 but exactly 8 ATUM, exactly 2 Aluno,  exactly 2 Disciplina, exactly 2 Turno, 5 int

run Inv_AllPreds for 3 but exactly 1 ATUM,  exactly 5 Aluno, exactly 3 Capacidade
