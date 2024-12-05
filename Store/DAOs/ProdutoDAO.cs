using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Store
{
    internal class ProdutoDAO {

        private readonly List<Produto> _produtos;
        private VendaDAO vendaDAO;

        public ProdutoDAO(VendaDAO vendaDAO)
        {
            this._produtos = new List<Produto>();
            this.vendaDAO = vendaDAO;
        }

        public Produto CadastrarProduto(Produto produto) {
            this._produtos.Add(produto);
            return produto;
        }

        public Produto BuscarPorCodigo(int codigo) {
            Produto produto = this._produtos.Find(x => x.Code == codigo);

            if (produto == null) {
                throw new Exception($"Produto não encontrado no código: {codigo}");
            }

            return produto;
        }

        public void ListarProdutos() {
            if(this._produtos.Count == 0)
                throw new Exception("Não existem produtos registrados");
            foreach (var produto in this._produtos)
            {
            Console.WriteLine($"{this._produtos.IndexOf(produto)+1} - {produto.Modelo} | {produto.Marca} : {produto.Preco}");
            }
        }

        public void DeletarProduto(int codigo) {
            Produto produto = this._produtos.Find(x => x.Code == codigo);
            try
            {
                if (this.vendaDAO.VendasComProduto(codigo).Count > 0)
                {
                    throw new Exception("Esse produto esta listado em venda(s)");
                }
                if (produto == null)
                {
                    throw new Exception("Produto não encontrado");
                }
                    this._produtos.Remove(produto);
                    Console.WriteLine("Produto Deletado");
            }
            catch (Exception ex) { 
                throw ex;
            }
        }


    }
}