using System;
using InventarioSystem;
using System.Text.RegularExpressions;
using Coloracao;
namespace Projeto
{
    public class RunInventaryCode
    {
        public void Start(IFerreiro novoFerreiro, IMercado novoMercado)
        {
            //Criando o ferreiro e o mercado


            //Criando os itens equipáveis
            IEquipamento helmoGuerreiroGuardiao = novoFerreiro.criarHelmo();
            IEquipamento helmoGuerreiroInfernal = novoFerreiro.criarHelmo();
            helmoGuerreiroGuardiao.Nome = "Helmo guerreiro guardião";
            helmoGuerreiroInfernal.Nome = "Helmo guerreiro Infernal";

            //Criando os itens consumiveis
            IConsumivel PoteDeVida = novoMercado.criarPoteVida();
            IConsumivel PoteDeMana = novoMercado.criarPoteMana();
            PoteDeVida.Nome = "Pote de vida 200Ml";
            PoteDeMana.Nome = "Pote de mana 200Ml";

            //Criando um novo inventário
            Inventario novoInventario = new Inventario();

            //Adicionando os itens equipáveis no inventário geral
            novoInventario.AdicionarItemInventarioGeral(helmoGuerreiroGuardiao);
            novoInventario.AdicionarItemInventarioGeral(helmoGuerreiroInfernal);
            novoInventario.AdicionarItemInventarioGeral(PoteDeVida);
            novoInventario.AdicionarItemInventarioGeral(PoteDeMana);

            //Verificando a alteração entre equipar um item e equipar outro do mesmo tipo
            Console.WriteLine("Inventario Geral após ser adicionado 2 Helmos: \n");
            novoInventario.ListarItensInventarioGeral();
            Console.WriteLine("\n________________________________\n\nInventario de equipamentos: \n");
            novoInventario.ListarItensInventarioEquipamento();
            novoInventario.EquiparItem(1);
            Console.WriteLine("\n________________________________\n\nInventario de equipamentos após equipar o primeiro item: \n");
            novoInventario.ListarItensInventarioEquipamento();
            Console.WriteLine("\n________________________________\n\nInventario Geral após ter sido equipado o item: \n");
            novoInventario.ListarItensInventarioGeral();
            novoInventario.EquiparItem(1);
            Console.WriteLine("\n________________________________\n\nInventario de equipamento após ter equipado um item do mesmo tipo: \n");
            novoInventario.ListarItensInventarioEquipamento();
            Console.WriteLine("\n________________________________\n\nInventario geral após ter equipado um item do mesmo tipo: \n");
            novoInventario.ListarItensInventarioGeral();


            //Tentando equipar um item consumível
            Console.WriteLine("\n________________________________\n\nTentando equipar um consumível: \n");
            novoInventario.ListarItensInventarioGeral();
            novoInventario.EquiparItem(1);

            //Filtrando a lista dos itens pelo tipo
            Console.WriteLine("\n________________________________\n\nListando itens do inventário apenas por equipavel: \n");
            novoInventario.ListarItensDoTipo("equipavel");
            Console.WriteLine("\n________________________________\n\nListando itens do inventário apenas por consumivel: \n");
            novoInventario.ListarItensDoTipo("consumivel");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RunInventaryCode InventarioProject = new RunInventaryCode();
            InventarioProject.Start(new FerreiroDeGuerreiro(), new MercadoVila());
            /* string pattern = @"[abc]";
            string input = "abcabcabcabc";
            Match match = Regex.Match(input, pattern);
            Texto.ColorirTexto($"(B=White|L=Black)Matchs encontrados na string \"{input}\" (.)\n");
            Texto.ColorirTexto($"Valores corretos estarão coloridos de (B=Green|L=Black) VERDE.(.) Já os incorretos em (B=Red|L=Black) VERMELHO(.). \n");
            
            while (match.Value != null)
            {

                if (match.Success)
                {
                    Texto.ColorirTexto($"(B=DarkGreen|L=Black){match.Value} | {match.Index} | {match.Success}(.)");
                }
                else
                {
                    Texto.ColorirTexto($"(B=Red|L=Black){match.Value} | {match.Index} | {match.Success}(.)");
                }
                match = match.NextMatch();
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.P || key == ConsoleKey.RightArrow)
                {
                    break;
                }
            } */
        }
    }
}
