using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class CustomerDAO
    {
        private readonly List<Customer> _customers;
        private VendaDAO vendaDAO;

        public CustomerDAO(VendaDAO vendaDAO)
        {
            this._customers = new List<Customer>();
            this.vendaDAO = vendaDAO;
        }

        public int registerCustomer(Customer customer)
        {
            if(this._customers.Find(x => x.Cpf == customer.Cpf) != null)
            {
                throw new Exception("CPF JÁ REGISTRADO");
            }

            this._customers.Add(customer);
            return this._customers.Find(x => x.Cpf == customer.Cpf).Code;
        }

        public Customer findCustomerByCode(int code)
        {
            Customer customer = this._customers.Find(x => x.Code == code);

            if (customer == null) {
                throw new Exception($"Cliente não encontrado no codigo: {code}");
            }

            return customer;
        }

        public void deleteCustomer(int code)
        {
            try
            {
                Customer customer = this.findCustomerByCode(code);
                if (customer != null)
                { 
                    List<Venda> vendas = this.vendaDAO.BuscarVendasUsuario(code);
                    if(vendas.Count > 0)
                    {
                        throw new Exception("Existem venda associada a esse usuário");
                    }

                    this._customers.Remove(customer);
                    Console.WriteLine("Cliente deletado com sucesso!");
                }

            } catch(Exception err)
            {
                throw err;
            }
            
        }

    }
}
