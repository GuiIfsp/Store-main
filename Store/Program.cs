using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Store{
    internal class Program
    {
        private static VendaDAO vendaDAO = new VendaDAO();
        private static CustomerDAO customerDAO = new CustomerDAO(vendaDAO);
        private static ProdutoDAO produtoDAO = new ProdutoDAO(vendaDAO);

        static void Main(string[] args)
        {

            int op;
            Console.WriteLine("SIMULADOR DE VENDAS");
            do{
                Console.WriteLine("Selecione uma das opções:\n [1] - Clientes\n [2] - Produtos\n [3] - Vendas\n [4] - Sair");
                op = LerInput<int>();
                switch (op){
                    case 1:
                        ClienteManager();
                        break;
                    case 2:
                        ProdutoManager();
                        break;
                    case 3:
                        VendaManager();
                        break;
                    case 4:
                        Console.WriteLine("Encerrando Programa");
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
            }while(op != 4);
        }

        static void ClienteManager() {
            int op;
            do {
                
                Console.WriteLine("\n==== GERENCIAR CLIENTE ====\n");
                Console.WriteLine("1. REGISTRAR CLIENTE");
                Console.WriteLine("2. BUSCAR CLIENTE");
                Console.WriteLine("3. DELETAR CLIENTE");
                Console.WriteLine("4. VOLTAR");
                op = LerInput<int>();

                switch (op) {
                    case 1:
                        RegistrarCustomer();
                        break;
                    case 2:
                        FindCustomer();
                        break;
                    case 3:
                        DeletarCustomer();
                        break;
                    case 4:
                        Console.WriteLine("Voltando ao menu");
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
                
            } while(op != 4);
            
            void RegistrarCustomer() {
                Console.WriteLine("\n==== REGISTRANDO CLIENTE====\n");
                Console.WriteLine("1. INSERIR NOME");
                string nome = LerInput<string>(
                    valor => valor.Length > 3, 
                    "O nome deve ter mais que 3 caracteres"
                );
                Console.WriteLine("2. INSERIR IDADE");
                int idade = LerInput<int>(
                    valor => valor > 18, 
                    "O cliente deve ter mais que 18 anos"
                );
                Console.WriteLine("3. INSERIR CPF");
                string cpf = LerInput<string>(
                    valor => valor.Length == 11, 
                    "CPF DEVE TER 11 DIGITOS"
                );

                try
                {
                    Customer customer = new Customer(nome, idade, cpf);
                    Console.WriteLine(customerDAO.registerCustomer(customer));
                } catch(Exception ex) { Console.WriteLine(ex.Message); }

                
            }

            void FindCustomer() {
                Console.WriteLine("\nBUSCANDO CLIENTE\n");

                int code = LerInput<int>(
                    valor => valor > 0, 
                    "Os códigos são número positivos"
                );

                try
                {
                    Customer customer = customerDAO.findCustomerByCode(code);
                    Console.WriteLine(customer.ToString());
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                }

            }  

            void DeletarCustomer()
            {
                Console.WriteLine("Insira o código do cliente que quer deletar (0 Para cancelar)");
                int codigo = LerInput<int>();
                if(codigo != 0)
                {
                    try
                    {
                        customerDAO.deleteCustomer(codigo);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        
        static void ProdutoManager(){
            int op;

            do
            {

                Console.WriteLine("\n==== GERENCIAR PRODUTO ====\n");
                Console.WriteLine("1. REGISTRAR PRODUTO");
                Console.WriteLine("2. BUSCAR PRODUTO");
                Console.WriteLine("3. LISTAR PRODUTOS");
                Console.WriteLine("4. DELETAR PRODUTO");
                Console.WriteLine("5. VOLTAR");
                op = LerInput<int>();

                switch (op) {
                    case 1:
                        RegistrarProduto();
                        break;
                    case 2:
                        EncontrarProduto();
                        break;
                    case 3:
                        ListarProdutos();
                        break;
                    case 4:
                        RemoverProduto();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                        break;
                }

            } while (op != 5);

            void RegistrarProduto(){
                Console.WriteLine("\n==== REGISTRANDO PRODUTO ====\n");
                Console.WriteLine("1. INSERIR MARCA");
                string marca = LerInput<string>();
                Console.WriteLine("2. INSERIR MODELO");
                string modelo = LerInput<string>();
                Console.WriteLine("3. INSERIR DESCRIÇÃO");
                string descricao = LerInput<string>();
                Console.WriteLine("4. INSERIR PREÇO");
                double preco = LerInput<double>();

                Produto produto = new Produto(marca, modelo, descricao, preco);
                produtoDAO.CadastrarProduto(produto);
            }

            void EncontrarProduto() {
                Console.WriteLine("\nBUSCANDO PRODUTO\n");

                int code = LerInput<int>(
                    valor => valor > 0, 
                    "Os códigos são número positivos"
                );
                try
                {
                    Produto produto = produtoDAO.BuscarPorCodigo(code);
                    Console.WriteLine(produto.ToString());

                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                }

            }

            void ListarProdutos()
            {
                try
                {
                    produtoDAO.ListarProdutos();
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                }
                
            }

            void RemoverProduto()
            {
                Console.WriteLine("\n==== Remoção de produto ====\n");
                Console.WriteLine("Insira o codigo do produto que deseja remover");
                int codigo = LerInput<int>();
                try
                {
                    produtoDAO.DeletarProduto(codigo);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void VendaManager()
        {
            int op;
            do
            {
                Console.WriteLine("\n==== GERENCIAR VENDA ====\n");
                Console.WriteLine("1. REGISTRAR VENDA");
                Console.WriteLine("2. BUSCAR VENDA");
                Console.WriteLine("3. MOSTRAR VENDAS");
                Console.WriteLine("4. TOTAL DAS VENDAS");
                Console.WriteLine("5. DELETAR VENDA");
                Console.WriteLine("6. VOLTAR");
                op = LerInput<int>();

                switch (op)
                {
                    case 1:
                        CriarVenda();
                        break;
                    case 2:
                        BuscarVenda();
                        break;
                    case 3:
                        MostrarVendas();
                        break;
                    case 4:
                        TotalVendas();
                        break;
                    case 5:
                        RemoverVenda();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }

            } while (op != 6);

            void CriarVenda()
            {
                Console.WriteLine("Digite o ID do cliente");

                Customer customer = null;
                int clienteID;

                do
                {
                    clienteID = LerInput<int>();
                    try
                    {
                        customer = customerDAO.findCustomerByCode(clienteID);
                    }
                    catch (Exception err)
                    { Console.WriteLine(err.Message); }

                } while (customer == null);

                Venda venda = new Venda(customer.Code);
                int codigoProduto;
                Console.WriteLine("Insira o código de produtos (0 para parar)");
                do
                {
                    Console.WriteLine("Insira um produto");
                    codigoProduto = LerInput<int>();

                    if(codigoProduto != 0)
                    {
                        try
                        {
                            Produto produto = produtoDAO.BuscarPorCodigo(codigoProduto);
                            venda.AddProduto(produto);
                            Console.WriteLine("Produto adicionado!\n");
                        }
                        catch (Exception ex) {
                            Console.WriteLine("\n" + ex.Message + "\n");
                        }
                        
                    } else
                    {
                        vendaDAO.NovaVenda(venda);
                    }

                } while (codigoProduto != 0);
            }

            void BuscarVenda()
            {
                Console.WriteLine("Insira o código da venda");
                int codigo = LerInput<int>();

                try
                {
                    Venda venda = vendaDAO.BuscarVenda(codigo);
                    Console.WriteLine(venda.ToString());
                }
                catch (Exception ex) {
                    Console.WriteLine("\n" + ex.Message + "\n");
                }
                
            }

            void MostrarVendas()
            {
                vendaDAO.MostrarVendas();
            }

            void TotalVendas()
            {
                vendaDAO.TotaldeVendas();
            }

            void RemoverVenda()
            {
                Console.WriteLine("Insira o código da venda a ser removida");
                int codigo = LerInput<int>();

                try
                {
                    vendaDAO.DeletarVenda(codigo);
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static T LerInput<T>(Func<T, bool> verificacao = null, string mensagemErro = null)
        {
            while (true)
            {
                Console.Write("Digite o valor: ");
                string input = Console.ReadLine();

                try
                {
                    T valor = (T)Convert.ChangeType(input, typeof(T));

                    if (verificacao != null && !verificacao(valor))
                    {
                        Console.WriteLine(mensagemErro ?? "Entrada inválida! Por favor, tente novamente.");
                        continue;
                    }

                    return valor;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de entrada inválido! Por favor, insira o valor corretamente.");
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Tipo de entrada inválido! Certifique-se de inserir o tipo correto.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }
        }

    }
}