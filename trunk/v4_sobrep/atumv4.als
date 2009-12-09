module ATUM

open util/ordering[Capacidade] as cap
open util/ordering[Preferencia] as prefs
open util/ordering[Aluno] as rank

//===============================
// ----- Assinaturas ----------------------------
//===============================

sig ATUM {
	inscritos: Aluno -> set Disciplina,
	alocadosTurno: Aluno -> set Turno,
	alocadosBloco: Aluno -> lone Bloco,
	processados: set Aluno,
	preferencias: Aluno -> set Preferencia,
	prefereBloco: Preferencia -> one Bloco,
	turnosDisciplina: Disciplina -> set Turno,
	turnosBloco: Bloco ->some Turno,
	vagasActuais: Turno -> one Capacidade,
	vagasIniciais: Turno -> one Capacidade,
	turnoSpot: Turno -> one Spot
}

sig Preferencia{}
sig Bloco {}
sig Aluno {}
sig Disciplina {}
sig Turno {}
sig Capacidade {}
sig Spot {}

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
	no (at.turnosBloco[Bloco] - at.turnosDisciplina[Disciplina])
}

// As vagas batem certo
pred Vagas_Sync[at:ATUM]{
	all t : at.turnosDisciplina[Disciplina] | cap/lte[at.vagasActuais[t],at.vagasIniciais[t]]
	all t : at.turnosDisciplina[Disciplina] | #cap/prevs[at.vagasActuais[t]] + #(at.alocadosTurno).t 
																			= # cap/prevs[at.vagasIniciais[t]]	
}

// Dois blocos iguais são o mesmo bloco
pred Nao_Ha_Blocos_Iguais[at:ATUM]{
	all disj b1, b2 : at.turnosBloco.Turno | at.turnosBloco[b1] != at.turnosBloco[b2]
}

// Um bloco não pode conter turnos sobre opostos
pred Nao_Ha_Turnos_Sobrepostos [at: ATUM]{
	all b: Bloco | all disj t1,t2: at.turnosBloco[b] | at.turnoSpot[t1] != at.turnoSpot[t2]
}

//===============================
// ----- Predicados sobre Alunos -----------------

// Se um aluno está alocado num bloco, então está alocado a todos os turnos dele
pred Aloca_Bloco_Turno[at: ATUM]{
	all a : (at.alocadosBloco).Bloco| one at.alocadosBloco[a] <=> at.turnosBloco[at.alocadosBloco[a]] in at.alocadosTurno[a]
}

// Um aluno só quer blocos para os quais está inscrito a todas as disciplinas
pred So_Quer_Blocos_Inscrito[at:ATUM]{
	all a : at.inscritos.Disciplina | at.turnosBloco[(getBlocos[at,a])] in at.turnosDisciplina[(at.inscritos[a])]
}

// Não alocar alunos que ainda não foram processados
pred Aluno_Nao_Foi_Alocado[at:ATUM]{
	all a: Aluno - at.processados | no at.alocadosTurno[a] + at.alocadosBloco[a] 
}

// Só se alocam alunos inscritos
pred Alocar_Apenas_Inscritos[at:ATUM]{
	(at.alocadosTurno).Turno in (at.inscritos).Disciplina
}

// Garantir que um Aluno apenas é alocado em Turnos de Disciplinas em que está matriculado
pred Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at: ATUM] {
	all a: at.inscritos.Disciplina | at.alocadosTurno[a] in at.turnosDisciplina[at.inscritos[a]]
}

// Não se aloca ninguém a turnos inúteis
pred Alocar_A_Turnos_Validos[at:ATUM]{
	at.alocadosTurno[Aluno] in at.turnosDisciplina[Disciplina]
}

// Um aluno não pode preferir o mesmo bloco duas vezes
pred Nao_Duplica_Preferencias[at: ATUM]{
	all a: at.inscritos.Disciplina | all disj p,q: at.preferencias[a] | at.prefereBloco[p] != at.prefereBloco[q]
}

// Um aluno não pode estar alocado em turnos sobre opostos
pred Nao_Aloca_Sobrepostos[at: ATUM] {
	all a: at.alocadosTurno.Turno | all disj t1,t2: at.alocadosTurno[a] | at.turnoSpot[t1] != at.turnoSpot[t2]
}

// Garantir que a Alocação foi bem feita
pred Bem_Alocados[at:ATUM]{
	// Os melhores são processados primeiro
	all ap: at.processados | all anp: at.inscritos.Disciplina - at.processados | rank/lt[ap,anp]
		
	// Para todos os processados há no máximo um turno por disc
	all a : at.processados | all d : at.inscritos[a] | lone at.alocadosTurno[a] & at.turnosDisciplina[d] 

	// Apenas Melhores estão onde ele não está	
	all a : at.processados | all d: at.inscritos[a] | no at.alocadosTurno[a] & at.turnosDisciplina[d]  => So_Melhores_Disc[at,a,d]
	all a: at.processados  | no at.alocadosBloco[a] => So_Melhores_Bloco[at,a]
	
	// Os Alunos Estão no melhor bloco possível
	all a: (at.processados & (at.alocadosBloco).Bloco) | No_Better_Blocos[at,a,at.alocadosBloco[a]]

}

pred Inv_AllPreds[at:ATUM] {
	Turno_Pertence_Uma_Disciplina [at]
	Um_Turno_Por_Disciplina[at]	
	So_Turnos_Legitimos[at]
	Vagas_Sync[at]	
	Nao_Ha_Blocos_Iguais[at]
	Nao_Ha_Turnos_Sobrepostos[at]

	Aloca_Bloco_Turno[at]
	So_Quer_Blocos_Inscrito[at]
	Aluno_Nao_Foi_Alocado[at]
	Alocar_Apenas_Inscritos[at]
	Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado[at]
	Alocar_A_Turnos_Validos[at]	
	Nao_Duplica_Preferencias[at]
	Nao_Aloca_Sobrepostos[at]
	Bem_Alocados[at]
}

//===============================
// ----- Predicados Auxiliares  -----------------

pred So_Melhores_Disc[at:ATUM, a:Aluno, d:Disciplina]{
	all a' : (at.alocadosTurno).(at.turnosDisciplina[d]) | rank/lt[a',a]
}

pred So_Melhores_Bloco[at:ATUM, a:Aluno]{
	all b : getBlocos[at,a]  | all a': (at.alocadosBloco).b | rank/lt[a',a]
}

pred No_Better_Blocos[at:ATUM, a:Aluno, b:Bloco]{
	(no getBetterBlocos[at,a,b]) or
	(So_Melhores_Bloco[at, a] and all bs : getBetterBlocos[at,a,b] | not Bloco_Tem_Vagas[at,bs])
}

pred Bloco_Tem_Vagas [at: ATUM, b: Bloco] {
	all t: at.turnosBloco[b] | at.vagasActuais[t] != cap/first
}

pred Turno_Disp_SemSobrep[at:ATUM, a:Aluno, t:Turno]{
	at.vagasActuais[t] !=cap/first
	t in at.inscritos[a].(at.turnosDisciplina)
	all s : (at.inscritos[a].(at.turnosDisciplina)-t).(at.turnoSpot) | s != at.turnoSpot[t]
}

pred Ha_Bloco_Disponivel[at:ATUM, a:Aluno]{
	some b: getBlocos[at,a] | Bloco_Tem_Vagas[at,b]
}

pred Aluno_Tem_Vaga_Nao_Sobreposta[at:ATUM, a:Aluno, d:Disciplina]{
	some t : at.turnosDisciplina[d] | Turno_Disp_SemSobrep[at,a,t]
}


//===============================
// ----- Funções Auxiliares  -----------------

fun getBlocos[at: ATUM, a:Aluno] : set Bloco{
	at.preferencias[a].(at.prefereBloco)
}

fun getBlocosDisp[at: ATUM, a:Aluno] : set Bloco{
	{b : at.preferencias[a].(at.prefereBloco) | Bloco_Tem_Vagas[at, b]}
}

fun getBestBloco[at:ATUM, a:Aluno] : some Bloco{
	{b:getBlocosDisp[at,a] | no getBetterBlocos[at,a,b] }
}

fun getBetterBlocos[at:ATUM, a:Aluno, b:Bloco] : set Bloco{
	{bs : getBlocos[at,a] | prefs/lt[ ((at.prefereBloco).bs & at.preferencias[a]), (at.prefereBloco).b  ] }
}

fun getTurnosSobrep [at: ATUM, a: Aluno, i: Spot] : set Turno {
	{ ts: at.turnosDisciplina[at.inscritos[a]] | ts in (at.turnoSpot).i }
}

fun getTodosSpots[at: ATUM, a: Aluno] : set Spot {
	( at.turnoSpot[at.turnosDisciplina[at.inscritos[a]]] )
}


//===============================
// ----- Operações -----------------------------
//===============================

// INSERIR ALUNO
pred Inserir_Aluno[at, at' : ATUM, a:Aluno]{
	a not in at.inscritos.Disciplina
	a not in at.alocadosTurno.Turno
	a not in at.processados
	a not in at.preferencias.Preferencia
	rank/last = a

	some insc : ( a->some Disciplina) | at'.inscritos = at.inscritos + insc
	a in at'.inscritos.Disciplina	

	at'.alocadosTurno = at.alocadosTurno
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosDisciplina = at.turnosDisciplina
	at'.turnosBloco = at.turnosBloco
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
}

assert Inserir_Aluno_Ok {
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Inserir_Aluno[at,at',a] => Inv_AllPreds[at']
}
pred Inserir_Aluno_Teste[at,at': ATUM, a: Aluno]{
	Inv_AllPreds[at]
	Inserir_Aluno[at,at',a]
}

// REMOVER ALUNO
pred Remover_Aluno[at, at' : ATUM, a:Aluno]{
	a in at.inscritos.Disciplina

	at'.inscritos = at.inscritos - (a -> at.inscritos[a])
	at'.alocadosTurno = at.alocadosTurno - (a -> at.alocadosTurno[a])

	all t: at.alocadosTurno[a] | at'.vagasActuais[t] = at'.vagasActuais[t].cap/next
	all t': at.vagasActuais.Capacidade - at.alocadosTurno[a] | at'.vagasActuais[t'] = at.vagasActuais[t']

	at'.alocadosBloco = at.alocadosBloco - (a -> at.alocadosBloco[a])
	at'.processados = at.processados - a
	at'.preferencias = at.preferencias - (a -> at.preferencias[a])
	at'.prefereBloco = at.prefereBloco
	at'.turnosDisciplina = at.turnosDisciplina
	at'.turnosBloco = at.turnosBloco
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
}

assert Remover_Aluno_Ok {
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Remover_Aluno[at,at',a] => Inv_AllPreds[at']
}
pred Remover_Aluno_Teste[at,at': ATUM, a: Aluno]{
	Inv_AllPreds[at]
	Remover_Aluno[at,at',a]
}

// INSERIR DISCIPLINA
pred Inserir_Disciplina[at, at' : ATUM, d:Disciplina]{
	no at.inscritos.d
	d not in at.turnosDisciplina.Turno

-- UMA DISC ENTRA SEMPRE COM UM TURNO	
	some t : Turno-at.turnosDisciplina[Disciplina] | at.vagasIniciais = at.vagasActuais && at'.turnosDisciplina = at.turnosDisciplina + d->t

	at'.inscritos = at.inscritos
	at'.alocadosTurno = at.alocadosTurno
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosBloco = at.turnosBloco
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
}

assert Inserir_Disciplina_Ok {
	all at,at': ATUM | all d: Disciplina | Inv_AllPreds[at] && Inserir_Disciplina[at,at',d] => Inv_AllPreds[at']
}
pred Inserir_Disciplina_Teste[at,at': ATUM, d: Disciplina]{
	Inv_AllPreds[at]
	Inserir_Disciplina[at,at',d]
}

// REMOVER DISCIPLINA
pred Remover_Disciplina[at, at' : ATUM, d:Disciplina]{
	no at.turnosDisciplina[d]

	at'.inscritos = at.inscritos - (at.inscritos.d -> d)
	at'.turnosDisciplina = at.turnosDisciplina - (d -> at.turnosDisciplina[d])
	at'.alocadosTurno = at.alocadosTurno - (Aluno -> at.turnosDisciplina[d])
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosBloco = at.turnosBloco - (Bloco -> at.turnosDisciplina[d])
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
}

assert Remover_Disciplina_Ok {
	all at,at': ATUM | all d: Disciplina | Inv_AllPreds[at] && Remover_Disciplina[at,at',d] => Inv_AllPreds[at']
}
pred Remover_Disciplina_Teste[at,at': ATUM, d: Disciplina]{
	Inv_AllPreds[at]
	Remover_Disciplina[at,at',d]
}

// ADICIONAR TURNO
pred Inserir_Turno[at, at' : ATUM, d:Disciplina, t:Turno, c:Capacidade]{
	t not in at.turnosDisciplina[Disciplina]
	t not in at.turnosBloco[Bloco]

	at'.vagasActuais=at.vagasActuais+(t->c)
	at'.vagasIniciais=at.vagasIniciais+(t->c)
	at'.turnosDisciplina=at.turnosDisciplina+(d->t)

	at'.inscritos = at.inscritos
	at'.alocadosTurno = at.alocadosTurno
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosBloco = at.turnosBloco
	at'.turnoSpot = at.turnoSpot
}

assert Inserir_Turno_Ok {
	all at,at': ATUM | all d: Disciplina | all t:Turno | all c:Capacidade |
		Inv_AllPreds[at] && Inserir_Turno[at,at',d,t,c] => Inv_AllPreds[at']
}

pred Inserir_Turno_Teste[at,at': ATUM, d: Disciplina, t:Turno, c:Capacidade]{
	Inv_AllPreds[at]
	Inserir_Turno[at,at',d,t,c]
}

// REMOVER TURNO
pred Remover_Turno[at, at' : ATUM, t:Turno]{
	no at.alocadosTurno.t
	no at.turnosBloco.t
	
	at'.alocadosTurno = at.alocadosTurno - (at.alocadosTurno.t -> t)
	at'.turnosDisciplina = at.turnosDisciplina - (at.turnosDisciplina.t -> t)
	at'.turnosBloco = at.turnosBloco - (at.turnosBloco.t -> t)

	at'.inscritos = at.inscritos
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
}

assert Remover_Turno_Ok {
	all at,at': ATUM | all t:Turno  |
		Inv_AllPreds[at] && Remover_Turno[at,at',t] => Inv_AllPreds[at']
}

pred Remover_Turno_Teste[at,at': ATUM, t:Turno]{
	Inv_AllPreds[at]
	Remover_Turno[at,at',t]
}

// INSERIR BLOCO
pred Inserir_Bloco[at,at': ATUM, b: Bloco, t:Turno]{
	no at.turnosBloco[b]
	no at.prefereBloco.b
	no at.alocadosBloco.b

	at'.turnosBloco = at.turnosBloco + (b -> t)
	
	at'.inscritos = at.inscritos
	at'.alocadosTurno = at.alocadosTurno
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosDisciplina = at.turnosDisciplina
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
}

assert Inserir_Bloco_Ok{
	all at,at':ATUM | all b: Bloco | all t: Turno | 
		Inv_AllPreds[at] && Inserir_Bloco[at,at',b,t] => Inv_AllPreds[at']
}

pred Inserir_Bloco_Teste[at,at': ATUM, b: Bloco, t: Turno]{
	Inv_AllPreds[at]
	Inserir_Bloco[at,at',b,t]
}

// REMOVER BLOCO
pred Remover_Bloco[at,at': ATUM, b: Bloco]{
	at'.turnosBloco = at.turnosBloco - (b -> at.turnosBloco[b])
	at'.alocadosBloco = at.alocadosBloco - (at.alocadosBloco.b -> b)
	at'.prefereBloco = at.prefereBloco - (at.prefereBloco.b -> b)
	
	at'.inscritos = at.inscritos
	at'.alocadosTurno = at.alocadosTurno
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.turnosDisciplina = at.turnosDisciplina
	all b': Bloco - b | at'.turnosBloco[b'] = at.turnosBloco[b']
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
}

assert Remover_Bloco_Ok{
	all at,at':ATUM | all b: Bloco | 
		Inv_AllPreds[at] && Remover_Bloco[at,at',b] => Inv_AllPreds[at']
}

pred Remover_Bloco_Teste[at,at': ATUM, b: Bloco]{
	Inv_AllPreds[at]
	Remover_Bloco[at,at',b]
}

--------------------------
// ALOCAR ALUNO
pred Aloca_Aluno[at,at': ATUM, a: Aluno] {
	no at.alocadosBloco[a]
	no at.alocadosTurno[a]
	rank/prevs[a] = at.processados
	
	//ALOCAR
	at'.alocadosTurno[a] in at.inscritos[a].(at.turnosDisciplina)
	all d : at.inscritos[a] |Aluno_Tem_Vaga_Nao_Sobreposta[at,a,d] => one at'.alocadosTurno[a] & at.turnosDisciplina[d]
		else  all i: getTodosSpots[at,a] | one at'.alocadosTurno[a] & getTurnosSobrep[at,a,i] 
	
	Ha_Bloco_Disponivel[at,a] => (one b: getBestBloco[at,a] | at'.alocadosBloco[a] = b and at.turnosBloco[b] in at'.alocadosTurno[a])
													else no at'.alocadosBloco[a]

	//RESTO
	at'.inscritos = at.inscritos
	at'.processados = at.processados + a
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosDisciplina = at.turnosDisciplina
	at'.turnosBloco = at.turnosBloco
	all t: at'.alocadosTurno[a] | at'.vagasActuais[t] = at.vagasActuais[t].cap/prev
	all x: Aluno - a | at'.alocadosTurno[x] = at.alocadosTurno[x] 
	all x: Aluno - a | at'.alocadosBloco[x] = at.alocadosBloco[x]
	all t: at.vagasActuais.Capacidade - at'.alocadosTurno[a] | at'.vagasActuais[t] = at.vagasActuais[t]
	at'.vagasIniciais = at.vagasIniciais
	at'.turnoSpot = at.turnoSpot
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

check Remover_Aluno_Ok for 3 but exactly 2 ATUM
run Remover_Aluno_Teste for 3 but exactly 2 ATUM

check Inserir_Disciplina_Ok for 3 but exactly 2 ATUM
run Inserir_Disciplina_Teste for 3 but exactly 2 ATUM

check Remover_Disciplina_Ok for 3 but exactly 2 ATUM
run Remover_Disciplina_Teste for 3 but exactly 2 ATUM

check Inserir_Turno_Ok for 3 but exactly 2 ATUM
run Inserir_Turno_Teste for 3 but exactly 2 ATUM

check Remover_Turno_Ok for 3 but exactly 2 ATUM
run Remover_Turno_Teste for 3 but exactly 2 ATUM

check Inserir_Bloco_Ok for 3 but exactly 2 ATUM
run Inserir_Bloco_Teste for 3 but exactly 2 ATUM

check Remover_Bloco_Ok for 3 but exactly 2 ATUM
run Remover_Bloco_Teste for 3 but exactly 2 ATUM

check Aloca_Aluno_Ok for 3 but exactly 2 ATUM, 1 Aluno
run Aloca_Aluno_Teste for 3 but exactly 2 ATUM, 1 Aluno

run Inv_AllPreds for 3 but 1 ATUM


