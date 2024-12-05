using System;

namespace Store
{
    internal class Produto
    {
        private static int _nextID = 1;

        private int code;
        private string marca;
        private string modelo;
        private string descricao;
        private double preco;


        public Produto(string marca, string modelo, string descricao, double preco)
        {
            this.code = this.generateID();
            this.marca = marca;
            this.modelo = modelo;
            this.descricao = descricao;
            this.preco = preco;
        }


        private int generateID()
        {
            return Produto._nextID++;
        }


        public int Code
        {
            get => code;
            set => code = value;
        }

        public string Marca
        {
            get => marca;
            set => marca = value;
        }

        public string Modelo
        {
            get => modelo;
            set => modelo = value;
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public double Preco
        {
            get => preco;
            set => preco = value;
        }

        public override string ToString()
        {
            return $"Código: {Code}, Marca: {Marca}, Modelo: {Modelo}, Descrição: {Descricao}, Preço: {Preco} R$";
        }
    }
}
