module ATUM

// Nota: Certificar que há sempre um número de turnos igual ou superior ao de disciplinas

//
// Assinaturas
//

sig ATUM {
	objects: set Object
}

abstract sig Object {}

sig Aluno extends Object {
	inscrito: some Disciplina, // Um Aluno encontra-se matriculado num 
											 // conjunto (não vazio) de Disciplinas

	candidaturas: set Candidatura, // Um Aluno deve ter uma 
													 // candidatura por Disciplina

	alocado: some Turno // Um Aluno está alocado 
								    // num conjunto de Turno. 
}


sig Candidatura extends Object {
	disciplina: one Disciplina,
	preferencias: some Turno    // Cada Candidatura tem um conjunto 
											  // de preferencias para uma Disciplina
} 


sig Disciplina extends Object {
	turnos: set Turno // Cada disciplina tem um 
								  // conjunto (não vazio) de turnos
}

sig Turno extends Object {}

//
// Factos
//

// Garantir que um turno só pertençe a uma disciplina
fact Turno_Pertence_Uma_Disciplina {
	// Para todos os turnos existe uma disciplina a qual o turno pertençe
	all t: Turno | one d: Disciplina | t in d.turnos
}

// Garantir que cada Aluno só tem um turno por disciplina 
fact Alocado_Num_Turno_Por_Disciplina {
	// Para todos os alunos e para todas as disciplinas de cada aluno, 
	// existe apenas um turno dessa disciplina onde ele está alocado
	all a: Aluno | all d: a.inscrito | one t: a.alocado | t in d.turnos
}

// Garantir que cada Aluno só tem turnos de disciplinas a que se encontra matriculado
fact Alocado_Apenas_Em_Turnos_De_Disciplinas_Matriculado {
	// Para todos os alunos e para cada turno de cada aluno
	// existe apenas uma disciplina a que esse turno pertença
	all a: Aluno | all t: a.alocado | one d: a.inscrito | t in d.turnos
}

// Uma candidatura tem de ser para todos turnos da mesma disciplina
fact Candidatura_Uma_So_Disciplina{
	all c:Candidatura | (c.preferencias) = c.disciplina.turnos
}

// Garantir que cada aluno só faz uma candidatura por disciplina
fact Uma_Candidatura_Por_Disciplina {
	// Para todos os Alunos, e todas as Disciplinas a que se encontra inscrito
	// Deverá existir np máximo uma candidatura por cada Disciplina
	all a: Aluno | all d: a.inscrito | lone disciplina.d
}

// Carantir que um aluno só é alocado se existe uma candiidatura
fact Alocado_Em_Diciplina_Candidatou {
	all a: Aluno | a.alocado in a.candidaturas.preferencias
}

//
// Comandos
//

// Facto para ajudar com os testes. Apagar no fina!

run {}
