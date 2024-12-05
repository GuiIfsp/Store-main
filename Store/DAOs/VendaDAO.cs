
using System;
using System.Collections.Generic;

namespace Store
{
    
    internal class VendaDAO {

        private readonly List<Venda> _vendas;

        public VendaDAO() {
            this._vendas = new List<Venda>();
        }

        public Venda NovaVenda(Venda venda) {
            this._vendas.Add(venda);
            Console.WriteLine(venda.Code);
            return venda;
        }

        public Venda BuscarVenda(int codigo) {
            Venda venda = this._vendas.Find(x => x.Code == codigo);
            if(venda == null) {
                throw new Exception($"Não encontrada a venda no código {codigo}");
            }
                return venda;
        }

        public void MostrarVendas(){
            foreach(Venda venda in this._vendas){
                Console.WriteLine($"\nCodigo da venda: { venda.Code }");
                Console.WriteLine($"Valor total: { venda.PrecoTotal() }");
            }
            if(this._vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda registrada");
            }
        }
        
        public void TotaldeVendas() {
            int totalDeVendas = 0;
            double valorTotal = 0;
            foreach (var venda in this._vendas)
            {
                totalDeVendas++;
                foreach (var produto in venda.Produtos)
                {
                    valorTotal += produto.Preco;
                }
            }

            Console.WriteLine($"Valor total: {valorTotal}");
            Console.WriteLine($"Total de vendas: {totalDeVendas}");
        }

        public void DeletarVenda(int codigo)
        {
            try
            {
                Venda venda = this.BuscarVenda(codigo);
                this._vendas.Remove(venda);
                Console.WriteLine("Venda deletada");
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public List<Venda> BuscarVendasUsuario(int codigoUsuario)
        {
            List<Venda> vendas = this._vendas.FindAll(venda => venda.Customer == codigoUsuario);
            return vendas;
        }
        public List<Venda> VendasComProduto(int codigoProduto) { 
            return this._vendas.FindAll(venda => venda.Produtos.Find(produto => produto.Code == codigoProduto) != null);
        }

    }

}
