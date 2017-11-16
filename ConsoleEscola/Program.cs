using System;
using atividade.Essencial;

namespace ConsoleEscola
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco = new Endereco();
            Aluno aluno = new Aluno();
            Professor professor = new Professor();
            Materia materias = new Materia();
            Turma turma = new Turma();
            Sala sala = new Sala();

            int opcao = 0;
            while (opcao != 9){
                Console.Clear();
                Console.WriteLine("Bem-vindo ao Programa de Cadastro Escolar.");
                Console.WriteLine("");
                Console.WriteLine("Digite uma das opções abaixo para seguir:");
                Console.WriteLine("1 - Cadastro de Alunos.\n2 - Cadastro de Professores.\n3 - Cadastro de Materias.\n4 - Cadastro de Turmas.\n9 - Sair.");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite um código para o aluno: ");
                        aluno.Id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome do aluno: ");
                        aluno.Nome = Console.ReadLine();
                        Console.Write("Digite o email do aluno: ");
                        aluno.Email = Console.ReadLine();
                        Console.Write("Digite a idade do aluno: ");
                        aluno.Idade = int.Parse(Console.ReadLine());
                        Console.Write("Digite a rua da residência: ");
                        endereco.Logradouro = Console.ReadLine();
                        Console.Write("Digite o número da residência: ");
                        endereco.Numero = Console.ReadLine();
                        Console.Write("Digite o complemento: ");
                        endereco.Complemento = Console.ReadLine();
                        Console.Write("Digite o bairro: ");
                        endereco.Bairro = Console.ReadLine();
                        Console.Write("Digite a cidade: ");
                        endereco.Cidade = Console.ReadLine();
                        aluno.End = endereco;

                        Console.WriteLine(aluno.Salvar());
                        break;

                        case 2:
                            Console.Write("Digite um código para o professor: ");
                            professor.Id = int.Parse(Console.ReadLine());
                            Console.Write("Digite o nome do professor: ");
                            professor.Nome = Console.ReadLine();
                            Console.Write("Digite a formação acadêmica do professor (ex: superior, pós graduado): ");
                            professor.Formacao = Console.ReadLine();
                            Console.Write("Digite o telefone: ");
                            professor.Telefone = Console.ReadLine();
                            Console.Write("Digite a rua da residência do professor: ");
                            endereco.Logradouro = Console.ReadLine();
                            Console.Write("Digite o número da residência: ");
                            endereco.Numero = Console.ReadLine();
                            Console.Write("Digite o complemento da residência: ");
                            endereco.Complemento = Console.ReadLine();
                            Console.Write("Digite o bairro da residência: ");
                            endereco.Bairro = Console.ReadLine();
                            Console.Write("Digite a cidade da residência: ");
                            endereco.Cidade = Console.ReadLine();

                            System.Console.WriteLine(professor.Salvar());
                            break;

                        case 3:
                            Console.Write("Digite um código para a matéria: ");
                            materias.Id = int.Parse(Console.ReadLine());
                            Console.Write("Digite o titulo da matéria: ");
                            materias.Titulo = Console.ReadLine();
                            Console.Write("Digite as carga horária da matéria(horas): ");
                            materias.CargaHoraria = Console.ReadLine();

                            Console.WriteLine(materias.Salvar());
                            break;
                        case 4:
                            Console.Write("Digite um código para a turma: ");
                            turma.Id = int.Parse(Console.ReadLine());
                            Console.Write("Digite o titulo da: ");
                            turma.TituloTurma = Console.ReadLine();
                            int adicionar = -1;
                            int qtd = 0;
                            Aluno[] novosAlunos = new Aluno[20];
                            while (adicionar != 0){
                                Console.WriteLine("Essa turma comporta 20 alunos. Digite os ids dos alunos que farão parte dessa turma. Para sair digite 0(zero).\nFaltam: "+(20-qtd));
                                adicionar = int.Parse(Console.ReadLine());
                                if(aluno.Pesquisar(adicionar) == null){
                                    Console.Write("Este aluno não existe.\nVerifique se o aluno está cadastrado e/ou o código foi digitado corretamente e tente novamente.");
                                    Console.WriteLine("Pressione qualquer tecla para continuar");
                                }
                                else{
                                    novosAlunos[qtd] = aluno.Pesquisar(adicionar);
                                    qtd++;
                                }
                            }
                            turma.Alunos = novosAlunos;

                            Console.Write("Digite o ID do professor: ");
                            professor.Id = int.Parse(Console.ReadLine());

                            Console.Write("Digite o nome do professor: ");
                            professor.Nome = Console.ReadLine();

                            turma.Prof = professor;

                            qtd = 0;
                            adicionar = -1;
                            Materia[] novaMateria = new Materia[5];
                            while(adicionar != 0){
                                Console.WriteLine("Digite no máximo 5 matérias. Digite os IDs das materias para adicioná-las. Para sair digite SAIR\nFaltam "+(5-qtd));
                                adicionar = int.Parse(Console.ReadLine());
                                if(materias.Pesquisar(adicionar) == null){
                                    Console.WriteLine("Materia não encontrada.\nVerifique se a matéria foi cadastrada e/ou o nome foi digitado corretamente e tente novamente.");
                                    Console.WriteLine("Pressine uma tecla para continuar.");
                                }
                                else{
                                    novaMateria[qtd] = materias.Pesquisar(adicionar);
                                    qtd++;
                                }
                            }

                            turma.Materias = novaMateria;

                            Console.WriteLine("Digite os dados da sala SEPARADOS por (;) (ex: Id; Numero da sala; Tipo de sala; Capacidade) e tecle ENTER");
                            string[] dadosSala = Console.ReadLine().Split(';');
                            sala.Id = int.Parse(dadosSala[0]);
                            sala.Numero = int.Parse(dadosSala[1]);
                            sala.TipoSala = dadosSala[2];
                            sala.Capacidade = int.Parse(dadosSala[3]);

                            turma.Sal = sala;

                            Console.WriteLine(turma.Salvar());
                            break;
                }

            }
            
        }
    }
}
