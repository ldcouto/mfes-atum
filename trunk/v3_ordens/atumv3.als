module ATUM

open util/ordering[Capacidade] as cap
open util/ordering[Preferencia] as prefs
--open util/ordering[Posicao] as rank

open util/ordering[Aluno] as rank

-- VAMOS PRECISAR DE PREFERENCIA TOTAL SOBRE OS TURNOS
-- PACKS DE CADEIRAS - escolher horarios completos

//===============================
// ----- Assinaturas ----------------------------
//===============================

sig ATUM {
	inscritos: Aluno -> set Disciplina,
	alocadosTurnos: Aluno -> set Turno,
	alocadosBloco: Aluno -> lone Bloco,
	--ordem: Aluno -> one Posicao,
	processados: set Aluno,
	preferencias: Aluno -> set Preferencia,
	prefereBloco: Preferencia -> one Bloco,
	turnosDisciplina: Disciplina -> set Turno,
	turnosBloco: Bloco ->some Turno,
	vagasActuais: Turno -> one Capacidade,
	vagasIniciais: Turno -> one Capacidade
}

sig Preferencia{}
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
	no (at.turnosBloco[Bloco] - at.turnosDisciplina[Disciplina])
}

// As vagas batem certo
pred Vagas_Sync[at:ATUM]{
	all t : at.turnosDisciplina[Disciplina] | cap/lte[at.vagasActuais[t],at.vagasIniciais[t]]
	all t : at.turnosDisciplina[Disciplina] | #cap/prevs[at.vagasActuais[t]] + #(at.alocadosTurnos).t 
																			= # cap/prevs[at.vagasIniciais[t]]	
}

// Dois blocos iguais são o mesmo bloco
pred Nao_Ha_Blocos_Iguais[at:ATUM]{
	all disj b1, b2 : at.turnosBloco.Turno | at.turnosBloco[b1] != at.turnosBloco[b2]
}

//===============================
// ----- Predicados sobre Alunos -----------------

// Todas as ordens são diferentes
--pred Ordens_Diferentes[at:ATUM]{
	--all disj p1,p2 : at.ordem[Aluno] | p1 != p2
	--all disj a1,a2: Aluno | at.ordem[a1] != at.ordem[a2]
--}

// Se um aluno está alocado num bloco, então está alocado a todos os blocos dele
pred Aloca_Bloco_Turno[at: ATUM]{
	all a : at.processados | one at.alocadosBloco[a] => at.turnosBloco[at.alocadosBloco[a]] in at.alocadosTurnos[a]
}

// Um aluno só quer blocos para os quais está inscrito a todas as disciplinas
pred So_Quer_Blocos_Inscrito[at:ATUM]{
	all a : Aluno | at.turnosBloco[(getBlocos[at,a])] in at.turnosDisciplina[(at.inscritos[a])]
}

// Não alocar alunos que ainda não foram processados
pred Aluno_Nao_Foi_Alocado[at:ATUM]{
	all a: Aluno - at.processados | no at.alocadosTurnos[a] + at.alocadosBloco[a] 
}

// Só se alocam alunos inscritos
pred Alocar_Apenas_Inscritos[at:ATUM]{
	(at.alocadosTurnos).Turno in (at.inscritos).Disciplina
--	all a: Aluno | at.alocadosTurnosTurnos[a] in at.turnosDisciplina[at.inscritos[a]]
}

// Garantir que um Aluno apenas é alocado em Turnos 
// de Disciplinas em que está matriculado
pred Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado [at: ATUM] {
	all a: Aluno | at.alocadosTurnos[a] in at.turnosDisciplina[at.inscritos[a]]
}

// Não se aloca ninguém a turnos inúteis
pred Alocar_A_Turnos_Validos[at:ATUM]{
	at.alocadosTurnos[Aluno] in at.turnosDisciplina[Disciplina]
}

// Um aluno não pode preferir o mesmo bloco duas vezes
pred Nao_Duplica_Preferencias[at: ATUM]{
	all a: at.inscritos.Disciplina | all disj p,q: at.preferencias[a] | at.prefereBloco[p] != at.prefereBloco[q]
}

// Garantir que a Alocação foi bem feita
pred Bem_Alocados[at:ATUM]{

	all ap: at.processados | all anp: at.inscritos.Disciplina - at.processados | rank/lt[ap,anp]

	all a : at.processados | all d : at.inscritos[a] | lone at.alocadosTurnos[a] & at.turnosDisciplina[d]  

	all a : at.processados | at.turnosBloco[at.alocadosBloco[a]] in at.alocadosTurnos[a] and No_Better_Blocos[at,a,at.alocadosBloco[a]]

--	all a : at.processados | all d : at.inscritos[a] | Aluno_Tem_Vaga_Disc[at,a,d] => one at.alocadosTurnos[a] & at.turnosDisciplina[d]
--	all a : at.processados | Ha_Bloco_Disponivel[at,a] => one b : getBlocos[at,a] | at.turnosBloco[b] in at.alocadosTurnos[a] 
--																					and No_Better_Blocos[at,a,b]
}

//Todos os Invariantes
pred Inv_AllPreds[at:ATUM] {
	Turno_Pertence_Uma_Disciplina [at]
	Um_Turno_Por_Disciplina[at]	
	So_Turnos_Legitimos[at]
	Vagas_Sync[at]	
	Nao_Ha_Blocos_Iguais[at]

	So_Quer_Blocos_Inscrito[at]
	Aluno_Nao_Foi_Alocado[at]
	Alocar_Apenas_Inscritos[at]
	Alocar_A_Turnos_Validos[at]
	Bem_Alocados[at]

---------------------------

	Aloca_Bloco_Turno[at]
	Nao_Duplica_Preferencias[at]
	Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado[at]
	
---------------------------

--	Aluno_Ta_Num_Bloco[at]
--	Apenas_Alocado_Se_Tem_Preferencia[at]
}


// Aluno apenas é alocado a turnos que pertençam a um dos seus blocos preferidos
/* Já não é preciso. Agora o sistema pode meter um aluno em dois blocos ao tentar maximizar-lhe as cadeiras!
pred Apenas_Alocado_Se_Tem_Preferencia [at: ATUM] {
--	all a: at.processados | one b : 

--	all a: at.processados | at.alocadosTurnos[a] in at.turnosBloco[(at.prefereBloco[a])]
}*/

// Garantir que se um Aluno está num Bloco, está em todas as disciplinas desse bloco
/* Já não é preciso
pred Aluno_Ta_Num_Bloco[at:ATUM]{
	all a:at.processados | lone b:at.prefereBloco[a] | at.turnosBloco[b] in at.alocadosTurnos[a] 
}*/

//===============================
// ----- Predicados Auxiliares  -----------------

--pred Best_Bloco[at:ATUM, a:Aluno]{ 
--	some b : getBlocos[at,a] | no getBetterBlocos[at,a,b] 
--}

pred No_Better_Blocos[at:ATUM, a:Aluno, b:Bloco]{
	--all bs : at.preferencias[a].(at.prefereBloco) - b | prefs/lte[(at.prefereBloco).b, (at.prefereBloco).bs]
	
	all bs: getBetterBlocos[at,a,b] | not Bloco_Tem_Vagas[at,bs]
	
	all ap: rank/nexts[a] | all bs: getBetterBlocos[at,a,b] | not (at.alocadosBloco[ap] in bs)
}

pred Bloco_Tem_Vagas [at: ATUM, b: Bloco] {
	all t: at.turnosBloco[b] | at.vagasActuais[t] != cap/first
}

pred Turno_Disponivel[at:ATUM, a:Aluno, t:Turno]{
	at.vagasActuais[t] !=cap/first
	t in at.inscritos[a].(at.turnosDisciplina)
}

pred Ha_Bloco_Disponivel[at:ATUM, a:Aluno]{
	some b: getBlocos[at,a] | Bloco_Tem_Vagas[at,b]
}

--pred Aluno_N_Quer_Turno[at:ATUM, a:Aluno, t:Turno]{
--	t not in getBlocos[at,a].(at.turnosBloco)
--}

pred Aluno_Tem_Vaga_Disc[at:ATUM, a:Aluno, d:Disciplina]{
	some t : at.turnosDisciplina[d] | Turno_Disponivel[at,a,t]
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
	{bs : (at.preferencias[a]).(at.prefereBloco) | prefs/lt[ (at.prefereBloco).bs, (at.prefereBloco).b ] }
}

--fun getPrevPrefs[at: ATUM, a: Aluno] : set Bloco {
--	{bs: }
--}

//===============================
// ----- Operações -----------------------------
//===============================

// INSERIR ALUNO
pred Inserir_Aluno[at, at' : ATUM, a:Aluno]{
	a not in at.inscritos.Disciplina
	a not in at.alocadosTurnos.Turno
	a not in at.processados
	a not in at.preferencias.Preferencia
	rank/last = a

	some insc : ( a->some Disciplina) | at'.inscritos = at.inscritos + insc
	a in at'.inscritos.Disciplina	

	at'.alocadosTurnos = at.alocadosTurnos
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosDisciplina = at.turnosDisciplina
	at'.turnosBloco = at.turnosBloco
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
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
	no at.inscritos.d
	d not in at.turnosDisciplina.Turno

-- UMA DISC ENTRA SEMPRE COM UM TURNO	
	some t : Turno-at.turnosDisciplina[Disciplina] | at.vagasIniciais = at.vagasActuais && at'.turnosDisciplina = at.turnosDisciplina + d->t

	at'.inscritos = at.inscritos
	at'.alocadosTurnos = at.alocadosTurnos
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosBloco = at.turnosBloco
	at'.vagasActuais = at.vagasActuais
	at'.vagasIniciais = at.vagasIniciais
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
	--no at.inscritos
	t not in at.turnosDisciplina[Disciplina]
	t not in at.turnosBloco[Bloco]

	at'.vagasActuais=at.vagasActuais+(t->c)
	at'.vagasIniciais=at.vagasIniciais+(t->c)
	at'.turnosDisciplina=at.turnosDisciplina+(d->t)

	at'.inscritos = at.inscritos
	at'.alocadosTurnos = at.alocadosTurnos
	at'.alocadosBloco = at.alocadosBloco
	at'.processados = at.processados
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosBloco = at.turnosBloco
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
pred Aloca_Aluno_PBloco[at,at': ATUM, a: Aluno] {
	no at.alocadosBloco[a]
	no at.alocadosTurnos[a]
	rank/prevs[a] = at.processados
	
	//ALOCAR
	at'.alocadosTurnos[a] in at.inscritos[a].(at.turnosDisciplina)
	all d : at.inscritos[a] | Aluno_Tem_Vaga_Disc[at,a,d] => one at'.alocadosTurnos[a] & at.turnosDisciplina[d]

	Ha_Bloco_Disponivel[at,a] => (one b: getBestBloco[at,a] | at'.alocadosBloco[a] = b && at.turnosBloco[b] in at'.alocadosTurnos[a])

	//RESTO
	at'.inscritos = at.inscritos
	at'.processados = at.processados + a
	at'.preferencias = at.preferencias
	at'.prefereBloco = at.prefereBloco
	at'.turnosDisciplina = at.turnosDisciplina
	at'.turnosBloco = at.turnosBloco
	all t: at'.alocadosTurnos[a] | at'.vagasActuais[t] = at.vagasActuais[t].cap/prev
	all x: Aluno - a | at'.alocadosTurnos[x] = at.alocadosTurnos[x] && at'.alocadosBloco[x] = at.alocadosBloco[x]
	all t: at.vagasActuais.Capacidade - at'.alocadosTurnos[a] | at'.vagasActuais[t] = at.vagasActuais[t]
	at.vagasIniciais = at'.vagasIniciais
}


assert Aloca_Aluno_PBloco_Ok{
	all at,at': ATUM | all a: Aluno | Inv_AllPreds[at] && Aloca_Aluno_PBloco[at,at',a] => Inv_AllPreds[at']
}

pred Aloca_Aluno_PBloco_Teste[at,at': ATUM, a: Aluno] {
	Inv_AllPreds[at]
	Aloca_Aluno_PBloco[at,at',a]
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

check Aloca_Aluno_PBloco_Ok for 3 but exactly 2 ATUM, 1 Aluno
run Aloca_Aluno_PBloco_Teste for 3 but exactly 2 ATUM, 1 Aluno

run Inv_AllPreds for 3 but 1 ATUM, 2 Aluno

fact Pelo_Menos_Uma_Pref{
	#ATUM.preferencias > 1
	#Bloco > 2
}
