using System;
using System.IO;
using System.Collections.Generic;

namespace AvaliacaoDotNet
{
    public class Persistencia
    {

        public void CarregarArquivosAdvogado()
        {
            // ListaAdvogados.advogados.Clear();
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/residenciaDotNet/AvaliacaoDotNet/BancoDeDados/dadosadvogados.txt");

            try
            {

                using (StreamReader reader = new StreamReader(caminhoArquivo))
                {
                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine()!;
                        string[] dados = linha.Split(',');

                        // Certifique-se de que existam dados suficientes na linha
                        if (dados.Length >= 5)
                        {
                            string nome = dados[0];
                            DateTime dataNascimento = DateTime.Parse(dados[1]);
                            string cpf = dados[2];
                            int cna = int.Parse(dados[3]);
                            string especialidade = dados[4];
                            // advogados.Add(new Advogado(nome, dataNascimento, cpf, cna, especialidade));

                        }
                        else
                        {
                            Console.WriteLine("A linha no arquivo não contém dados suficientes para um Advogado.");
                        }
                    }
                }

                Console.WriteLine("Dados dos advogados carregados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao carregar o arquivo de advogados: {ex.Message}");
            }
        }

        public void CarregarArquivosCliente(ListaCliente listaClientes)
        {
            listaClientes.clientes.Clear();
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/residenciaDotNet/AvaliacaoDotNet/BancoDeDados/dadosclientes.txt");

            try
            {
                using (StreamReader reader = new StreamReader(caminhoArquivo))
                {
                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine()!;

                        // Verifique se a linha é nula (fim do arquivo)
                        if (linha != null)
                        {
                            string[] dados = linha.Split(',');

                            // Certifique-se de que existam dados suficientes na linha
                            if (dados.Length >= 5)
                            {
                                string nome = dados[0];
                                string cpf = dados[1];
                                DateTime dataNascimento = DateTime.Parse(dados[2]);
                                string estadoCivil = dados[3];
                                string profissao = dados[4];
                                listaClientes.AdicionarCliente(new Cliente(nome, cpf, dataNascimento, estadoCivil, profissao));
                            }
                            else
                            {
                                Console.WriteLine($"A linha no arquivo não contém dados suficientes para um Cliente. Linha: {linha}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("A linha lida é nula (fim do arquivo).");
                        }
                    }
                }

                Console.WriteLine("Dados dos clientes carregados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao carregar o arquivo de clientes: {ex.Message}");
            }
            App.Pause();
        }

        public void SalvarArquivosCliente(ListaCliente listaClientes)
        {
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/residenciaDotNet/AvaliacaoDotNet/BancoDeDados/dadosclientes.txt");

            try
            {
                using (StreamWriter arquivo = new StreamWriter(caminhoArquivo))
                {
                    foreach (Cliente cliente in listaClientes.clientes)
                    {
                        // Formatando os dados para gravar no arquivo
                        string linha = $"{cliente.Nome},{cliente.Cpf},{cliente.DataNascimento.ToShortDateString()},{cliente.EstadoCivil},{cliente.Profissao}";
                        arquivo.WriteLine(linha);
                    }
                }

                Console.WriteLine("\n\tDados dos clientes foram salvos com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\tOcorreu um erro ao salvar os dados dos clientes: {ex.Message}");
            }
            App.Pause();
        }

        public void SalvarArquivosAdvogado(ListaAdvogado ListaAdvogados)
        {
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/residenciaDotNet/AvaliacaoDotNet/BancoDeDados/dadosadvogados.txt");

            try
            {
                using (StreamWriter arquivo = File.CreateText(caminhoArquivo))
                {
                    foreach (Advogado advogado in ListaAdvogados.advogados)
                    {
                        arquivo.WriteLine($"{advogado.Nome};{advogado.Cpf};{advogado.DataNascimento.ToShortDateString()};{advogado.Cna};{advogado.Especialidade}");
                    }
                }

                Console.WriteLine("\n\tDados dos advogados foram salvos com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\tOcorreu um erro ao salvar os dados dos advogados: {ex.Message}");
            }
        }

    }
}