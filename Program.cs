using System;
using System.Collections.Generic;

// Título do sistema utilizando sequências de escape (\n) para pular linha
Console.WriteLine("\n--- PROJETO CONCLUSÃO MÓDULO 1: SALESTRACKER CLI ---");

// DEFINIÇÃO DA ESTRUTURA DE DADOS:
// No Módulo 1, utilizei listas paralelas para manter a relação entre os dados.
List<string> listaProdutos = new List<string>();
List<decimal> listaPrecosCusto = new List<decimal>();
List<decimal> listaPrecosVendas = new List<decimal>();

// ENTRADA DE CONFIGURAÇÃO:
// Determina quantas vezes o loop de captura de dados irá rodar.
Console.Write("\nQual a quantidade de vendas a registrar? ");
int qtd = int.Parse(Console.ReadLine()!);

// LOOP DE ENTRADA (MÓDULO DE CAPTURA):
for (int i = 1; i<=qtd; i++)
{
    Console.Write($"\nDigite o nome do {i}° produto: ");
    string produto = Console.ReadLine()!;

    Console.Write($"Digite o preço de custo do {produto}: R$ ");
    decimal precoCusto = decimal.Parse(Console.ReadLine()!);

    Console.Write($"Digite o preço da venda do {produto}: R$ ");
    decimal precoVenda = decimal.Parse(Console.ReadLine()!);

    // Lógica imediata: Cálculo de lucro individual para feedback ao usuário
    decimal lucro = precoVenda - precoCusto;
    Console.WriteLine($"Valor do lucro do {produto}: R$ {lucro}");

    // Persistência em memória: Adicionando os dados às suas respectivas listas
    listaProdutos.Add(produto);
    listaPrecosCusto.Add(precoCusto);
    listaPrecosVendas.Add(precoVenda);

}

// LOOP DE SAÍDA (GERAÇÃO DE RELATÓRIO):
Console.WriteLine("\n--- RELATÓRIO FINAL ---");

// Acumulador global para o balanço financeiro do sistema
decimal lucroTotalGeral = 0;

for (int i = 0; i < listaProdutos.Count; i++)
{
    // Recuperação de dados baseada no índice [i]
    decimal lucroIndividual = listaPrecosVendas[i] - listaPrecosCusto[i];

    // Atualização do acumulador (lucroTotalGeral = lucroTotalGeral + lucroIndividual)
    lucroTotalGeral += lucroIndividual;

    // Formatação de saída: PadRight para alinhar colunas e :N2 para 2 casas decimais
    Console.WriteLine($"Produto: {listaProdutos[i].PadRight(10)} | Lucro: R$ {lucroIndividual:N2}");
}

// LÓGICA DE NEGÓCIO FINAL:
// Verificação do balanço para determinar o status da operação
Console.WriteLine("-----------------------------------");
Console.WriteLine($"LUCRO TOTAL ACUMULADO: R$ {lucroTotalGeral:N2}");

if (lucroTotalGeral > 0)
{
    Console.WriteLine("STATUS: Operação Lucrativa!🚀");
}
else if (lucroTotalGeral < 0)
{
    Console.WriteLine("STATUS: Alerta de Prejuízo!⚠️");
}
else
{
    Console.WriteLine("STATUS: Empate(Sem lucro, sem prejuizo).");
}

Console.WriteLine("-----------------------------------");