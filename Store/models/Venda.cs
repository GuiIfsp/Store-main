using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    internal class Venda
    {
        private static int _nextID = 1;
        private int code;
        private int customer;
        private List<Produto> produtos;

        public Venda(int customer)
        {
            this.produtos = new List<Produto>();
            this.code = this.generateID();
            this.customer = customer;
        }


        public void AddProduto(Produto produto)
        {
            this.produtos.Add(produto);
        }


        public void ShowProdutos()
        {
            foreach (Produto produto in this.produtos)
            {
                Console.WriteLine($"{this.produtos.IndexOf(produto) + 1} - {produto.Modelo} | {produto.Marca} : {produto.Preco}");
            }
        }


        public double PrecoTotal()
        {
            double total = 0;

            foreach (Produto produto in this.produtos)
            {
                total += produto.Preco;
            }

            return total;
        }

        private int generateID()
        {
            return Venda._nextID++;
        }

        public int Code
        {
            get => code;
            set => code = value;
        }

        public int Customer
        {
            get => customer;
            set => customer = value;
        }

        public List<Produto> Produtos
        {
            get => produtos;
            set => produtos = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cliente [Codigo: {this.customer}]");
            sb.AppendLine($"Venda [Codigo: {Code}]");
            sb.AppendLine("Produtos:");

            foreach (var produto in produtos)
            {
                sb.AppendLine($"- {produto.Modelo} | {produto.Marca}: {produto.Preco:C}");
            }

            sb.AppendLine($"Preço Total: {PrecoTotal():C}");
            return sb.ToString();
        }

    }
}
