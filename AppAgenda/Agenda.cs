using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppAgenda
{
    class Agenda : Pessoa
    {
        List<Pessoa> ListaPessoas = new List<Pessoa>();
        

        public Agenda()
        {

        }

        public void Menu()
        {
            bool v = false;

            try
            {
                while(!v)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("________AGENDA________");
                    Console.Write("[1] Cadastrar Pessoa\n[2] Remover Pessoa\n[3] Busca ID da pessoa\n[4] Busca pessoa pelo ID\n[5] Mostrar adenda\n[6] Sair\n______________________\n >>  ");
                    int opcao = int.Parse(Console.ReadLine());
                    Console.ResetColor();


                    switch (opcao)
                    {
                        case 1:
                            if(ListaPessoas.Count <= 9)
                                ArmazenaPessoa();
                            else{
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Atingiu capacidade máxima da agenda!");
                                Console.ResetColor();
                                Console.WriteLine();
                            }
                            break;
                        case 2:
                            RemovePessoa();
                            break;
                        case 3:
                            ImprimePessoaByName();
                            break;
                        case 4:
                            ImprimePessoaById();
                            break;
                        case 5:
                            ImprimeAgenda();
                            break;
                        case 6:
                            Console.WriteLine("tchau!");
                            v = true;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Digito inválido. Tente novamente!"+ e.Message);
            }
        }
        public void ArmazenaPessoa()
        {   
            int tamanhoLista = ListaPessoas.Count;
                        
            Console.Clear();
            Console.Write(tamanhoLista+"\n");
            Console.WriteLine("Insira os dados da pessoa: ");
            
            Console.Write("Nome:\n >> ");
            string nome = Console.ReadLine();

            Console.Write("Data de nascimento:\n >> ");
            DateTime nascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Altura: \n >> ");
            float altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            ListaPessoas.Add(new Pessoa(nome, nascimento, altura));
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Retorno();
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        // REMOVE UMA PESSOA PELO NOME
        public void RemovePessoa()
        {
            Console.Clear();
            Console.WriteLine("___ REMOVER PESSOA DA LISTA ___\n");

            foreach(Pessoa p in ListaPessoas){
                Console.WriteLine(p.ToString());
            }
            
            Console.Write("Nome da pessoa que deseja remover: \n >>  ");
            string buscaNome = Console.ReadLine();

            int tamLista = ListaPessoas.Count;
            int indexDaPessoa = 0;
            
            for(int i = 0; i < tamLista; i++)
            {
                if(ListaPessoas[i].PegaNome() == buscaNome){
                    indexDaPessoa+=i;
                    Retorno();
                    i++;
                    
                }
            }
            ListaPessoas.RemoveAt(indexDaPessoa);

        }
        
        //IMPRIME TODA A AGENDA
        public void ImprimeAgenda()
        {
            Console.Clear();
            Console.WriteLine("Pessoas Cadastradas:\n");
           
            foreach (Pessoa pessoa in ListaPessoas)
            {   
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(pessoa.ToString());
                Console.ResetColor();
            }
            Console.WriteLine("*********************************");       
        }

        //BUSCA ID DA PESSOA PASSANDO O NOME
        public void ImprimePessoaByName()
        {   
            Console.Clear();
            Console.Write("Nome da pessoa que deseja localizar o índice: \n >>  ");
            string buscaNome = Console.ReadLine();

            int tamLista = ListaPessoas.Count;
            int indexDaPessoa = 0;
            
            for(int i = 0; i < tamLista; i++)
            {
                if(ListaPessoas[i].PegaNome() == buscaNome){
                    indexDaPessoa+=i;
                    i++;
                }
            }

            Console.WriteLine("\nPessoa localizada:\n{0} - {1}",indexDaPessoa,buscaNome+"\n");
        }

        //IMPRIME PESSOA BUSCANDO POR ID
         public void ImprimePessoaById()
        {   
            Console.Clear();
            Console.Write("Informe o índice da pessoa: \n >>  ");
            int buscaID = int.Parse(Console.ReadLine());
        
            Console.WriteLine(ListaPessoas[buscaID]);
        }

        public void Retorno()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Operação realizada com sucesso\n");
            Console.ResetColor();
        }

    }
}
