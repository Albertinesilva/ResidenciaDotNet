using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P003
{
    public class Produto : ProdutoRepository
    {
        // Tupla representando os elementos do produto
        private (int id, int Codigo, string Nome, int Quantidade, double Preco) dadosProduto;

        public Produto(int codigo, string nome, int quantidade, double preco)
        {
            PeopleID++;
            dadosProduto = (PeopleID, codigo, nome, quantidade, preco);
        }

        private static int PeopleID { get; set; } = 2023000;

        public int id { get => dadosProduto.id; }

        public int codigo { get => dadosProduto.Codigo; }

        public string nome { get => dadosProduto.Nome; }

        public int quantidade { get => dadosProduto.Quantidade; }

        public double preco { get => dadosProduto.Preco; }  

        public void cadastrar()
        {
            Console.WriteLine("Cadastrando produto...");
        }

        public void listar(){}

        public void editar(){}

        public void excluir(){}

        public void pesquisar(){}
    }
}