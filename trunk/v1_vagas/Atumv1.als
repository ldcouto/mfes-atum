module ATUM

open util/ordering[Capacidade]

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

// Disciplina tem VagasUm turno tem vagas
pred Ha_Vagas [at: ATUM, a: Aluno, d: Disciplina] {
	 some t: (at.preferencias[a] & at.turnos[d]) | at.vagas[t] !=first
}

// Trocar um aluno entre os turnos duma disciplina
pred Troca_Aluno [at: ATUM, a: Aluno, d:Disciplina]{
	a in at.processados
	some t: ( (at.preferencias[a] & at.turnos[d]) - at.alocados[a]) | at.vagas[t] != first
}

pred Troca_Teste [at: ATUM, a : Aluno, d : Disciplina] {
	Inv_AllPreds[at]
	Troca_Aluno[at,a,d]
}

run Troca_Teste for 3 but exactly 1 ATUM,  exactly 1 Aluno

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
	all d: at.inscritos[a] |  Ha_Vagas[at,a,d] => one (at'.alocados[a] & at.turnos[d])
	all t : at'.alocados[a] | at'.vagas[t] = at.vagas[t].prev
	all t: at.vagas.Capacidade - at.preferencias[a] | at'.vagas[t] = at.vagas[t]

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

check Faz_A_Troca_Ok for 4 but exactly 2 Aluno, exactly 2 ATUM
run Faz_A_Troca_Teste for 4 but exactly 2 ATUM, exactly 2 Aluno, 2 Capacidade


pred Aloca_Com_Troca[at,at',at'':ATUM, a:Aluno]{
	Alocacao[at,at',a] or 
	lone d: Disciplina |	lone a2 : at.processados | Troca_Aluno[at,a2,d] =>
			 Faz_A_Troca[at,at',a2,d] and  Alocacao[at',at'',a]
}


/*pred Aloca_Com_Troca[at, at' : ATUM, a: Aluno] {
	no at.alocados[a]
	some at.preferencias[a]

	at'.inscritos = at.inscritos
	at'.turnos = at.turnos
	at'.preferencias = at.preferencias	

	at'.processados = at.processados + a
	at'.alocados = at.alocados + (a -> at.preferencias[a])
---	all d: at.inscritos[a] |  Ha_Vagas[at,a,d] => one (at'.alocados[a] & at.turnos[d]) 
		--						else lone a2 : at.processados | Troca_Aluno[at, a2, d] =>
	all d: at.inscritos[a] | lone a2 : at.processados | Troca_Aluno[at,a2,d] =>			
						one t2: (at'.alocados[a2] & at.turnos[d]) - at.alocados[a2] |
										   at'.vagas[t2] = at.vagas[t2].prev
									and one t3: (at.preferencias[a] & at'.preferencias[a2]) |
											at'.vagas[t3] = at.vagas[t3].next
									
									//and at'.vagas[
									and one (at'.alocados[a] & at.turnos[d]) 

	all t : at'.alocados[a] | at'.vagas[t] = at.vagas[t].prev
	all t: at.vagas.Capacidade - at.preferencias[a] | at'.vagas[t] = at.vagas[t]

}*/


// Nova alocação é igual a alocação velha mais 
//umas novas alocações quaisquer tais que “regras de alocação” (aloc in prefs… )
assert Alocacao_Ok {
	all at, at': ATUM | all a: Aluno | Inv_AllPreds[at] && Alocacao[at,at',a] => Inv_AllPreds[at']
}

pred Alocacao_Teste [at, at' : ATUM, a : Aluno] {
	Inv_AllPreds[at]
	Alocacao[at,at',a]
}

assert Aloca_Com_Troca_Ok {
	all at, at',at'': ATUM | all a: Aluno | Inv_AllPreds[at] && Aloca_Com_Troca[at,at',at'',a] => Inv_AllPreds[at']
}

pred Aloca_Com_Troca_Teste [at,at',at'': ATUM, a: Aluno] {
	Inv_AllPreds[at]
	Aloca_Com_Troca [at,at',at'',a]
}

//===============================
// ----- Comandos -----------------------------
//===============================

run {}

run Todos_Predicados for 3 but exactly 1 ATUM, exactly 5 Turno

run Alocacao_Teste for 3 but 2 ATUM, exactly 1 Aluno, exactly 2 Disciplina

run Aloca_Com_Troca_Teste for 4 but exactly 2 ATUM, exactly 2 Aluno, 2 Capacidade

check Alocacao_Ok for 3 but exactly 1 Aluno, exactly 2 Disciplina, exactly 2 ATUM

check Aloca_Com_Troca_Ok for 4 but exactly 2 Aluno, exactly 3 ATUM

