﻿using System.Net;

/// N3rdy Dzn - n3rdydzn.xyz, github.com/n3rdydzn
/// Algoritmo Desenvolvido como Atividade Escolar
/// Dados podem não estar 100% correto/atualizado
/// 
///Não use este Aplicativo/Programa para uso continuo


///Variáveis
double salario = 0;
double descontos = 0;
double valor_final = 0;
double inss = 0;
double irrf = 0;
double roubo = 0;
string logo = string.Empty;
WebClient webc = new WebClient();
string logomsg = webc.DownloadString("https://pastebin.com/raw/Vp41Tzgf");
string my_ft = webc.DownloadString("https://pastebin.com/raw/0bnnUP9i");


Console.Title = "Calculadora de Valor Líquido - n3rdydzn.xyz";


//===============VALORES INSS================
///até 1.100R$
double aters1100 = 0.0075;
//de 1.100,01 até 2.203,00
double ate2203 = 0.09;
//de R$2.203,00 até 3.305
double ate3305 = 0.012;
//de R$3.305 até 6.433
double ate6433 = 0.014;
//inss teto
double teto_inss = 0.020;


//=============TABELA DE IRRF================
//até 1.903,98 = 0%

//de 1.903,98 até 2.826,65 = 7.50%
double ate2826 = 0.075;
//de 2.826,66 até 3.751,05 = 15%;
double ate3751 = 0.015;
//de 3.751,06 até 4.664,68 = 22,50%
double ate4664 = 0.0225;
//acima de 4.664,68 = 27,50%
double acima46646 = 0.0275;
//===========================================


//Funções
void logo_msg()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(logomsg);
    Console.ForegroundColor= ConsoleColor.White;
}
void user_menu()
{
    Console.Clear();
    logo_msg();
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("[1] Calcular");
    Console.WriteLine("[2] Sobre");
    string user_perg = Console.ReadLine();

if (user_perg == "1")
    {
        Console.Clear();
        user_ask();
    }
else
    {
        Console.Clear();
        creditos();
    }
}
void user_ask()
{ 
logo_msg();
Console.WriteLine("Digite Valor Salário");
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("dica: não use pontuação ou acentos.");
Console.ForegroundColor = ConsoleColor.White;
salario = Convert.ToDouble(Console.ReadLine());
Console.Clear();

logo_msg();
Console.WriteLine("Digite Valor dos DESCONTOS (Opcional; Digite 0 caso não há)");
descontos = Convert.ToDouble(Console.ReadLine());
Console.Clear();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Calculando...");
calc_inss();
calc_irrf();
Console.ForegroundColor = ConsoleColor.White;
}
void calc_irrf()
{
    //apenas calculo IRRF
    switch (salario)
    {
        //caso se for menor ou igual á R$1.100
        case <= 1903:
            irrf = 0;
            break;
        case <= 2826:
            irrf = Convert.ToDouble(salario * ate2826);
            break;
        case <= 3751:
            irrf = Convert.ToDouble(salario * ate3751);
            break;
        case <= 4664:
            irrf = Convert.ToDouble(salario * ate4664);
            break;
        case >= 4664:
            irrf = Convert.ToDouble(salario * acima46646);
            break;
    }
}
void calc_inss()
{
    //APENAS CALCULO INSS
    switch (salario)
    {
        //caso se for menor ou igual á R$1.100
        case <= 1100:
            inss = Convert.ToDouble(salario * aters1100);
            break;
        case <= 2203:
            inss = Convert.ToDouble(salario * ate2203);
            break;
        case <= 3305:
            inss = Convert.ToDouble(salario * ate3305);
            break;
        case >= 6433:
            inss = Convert.ToDouble(salario * ate6433);
            break;
    }

}
void creditos()
{
    Console.WriteLine(my_ft);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("N3rdyDzn");
    Console.WriteLine("Algoritmo Desenvolvido como Atividade Escolar");
    Console.WriteLine("Dados podem não estar 100% correto/atualizado");
    Console.WriteLine("Não use este Aplicativo/Programa para uso continuo");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("n3rdydzn.xyz");
    Console.WriteLine("github.com/n3rdydzn");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    user_menu();
}

//Loader
user_menu();
roubo = (inss + irrf);
valor_final = (salario - roubo);
if (descontos == 0)
{
    //sem Descontos (Valor Bruto)
    System.Threading.Thread.Sleep(1500);
    Console.Clear();
    Console.WriteLine("Você recebeu apenas:");
    Console.WriteLine("R$" + valor_final);
    Console.WriteLine("Governo roubou de você: R$" + roubo);
    Console.WriteLine("Salario:" + salario);
    Console.WriteLine("Inss:" + inss);
    Console.WriteLine("IRRF:" + irrf);
    Console.ReadKey();
    user_menu();
}
else
{
    //com descontos (valor liquido)
    double valor_final_descontado = (valor_final - descontos);
    System.Threading.Thread.Sleep(1500);
    Console.Clear();
    Console.WriteLine("Era pra você receber: R$" + salario);
    Console.WriteLine("Você recebeu apenas:");
    Console.WriteLine("R$" + valor_final);
    Console.WriteLine("Governo roubou de você: R$" + roubo);
    Console.WriteLine("Salario: R$" + salario);
    Console.WriteLine("Inss: R$" + inss);
    Console.WriteLine("IRRF: R$" + irrf);
    Console.WriteLine("Descontos: R$" + valor_final_descontado);
    Console.ReadKey();
    user_menu();
}


//fim