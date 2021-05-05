using System;

namespace Coloracao{
    public class Texto{
        private static void ChoiceBackGroundColor(string color)
        {
            switch (color)
            {
                case "Black":
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "Blue":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case "Cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case "DarkBlue":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case "DarkCyan":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case "DarkGray":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case "DarkGreen":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case "DarkMagenta":
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "DarkRed":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case "DarkYellow":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case "Gray":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case "Green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "Magenta":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case "Red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "White":
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case "Yellow":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.WriteLine($"Valor da cor de background é inválido: {color}");
                    break;
            }
        }
        private static void ChoiceLetterColor(string color)
        {
            switch (color)
            {
                case "Black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "DarkBlue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "DarkCyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "DarkGray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "DarkGreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "DarkMagenta":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "DarkRed":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "DarkYellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "Gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "White":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.WriteLine($"Valor da cor de letra é inválido: {color}");
                    break;
            }
        }
        public static void ColorirTexto(string texto)
        {
            string[] Novotexto = texto.Split(" ");
            foreach (string palavra in Novotexto)
            {  
                if (palavra.Contains("(B=") && !palavra.EndsWith(")") && !palavra.Contains("(.)"))
                {
                    string[] opt_word = palavra.Split(")");
                    string[] options = opt_word[0].Replace("(", "").Split("|");
                    string BackGround = options[0].Replace("B=", "");
                    BackGround = char.ToUpper(BackGround[0]) + BackGround.Substring(1);

                    string Letter = options[1].Replace("L=", "");
                    Letter = char.ToUpper(Letter[0]) + Letter.Substring(1);
                    ChoiceBackGroundColor(BackGround);
                    ChoiceLetterColor(Letter);
                    Console.Write(opt_word[1] + " ");
                }
                else if (palavra.Contains("(B=") && !palavra.Contains("."))
                {
                    string removeParenteses = palavra.Replace("(", "").Replace(")", "");
                    string[] options = removeParenteses.Split("|");
                    string BackGround = options[0].Replace("B=", "");
                    BackGround = char.ToUpper(BackGround[0]) + BackGround.Substring(1);

                    string Letter = options[1].Replace("L=", "");
                    Letter = char.ToUpper(Letter[0]) + Letter.Substring(1);
                    ChoiceBackGroundColor(BackGround);
                    ChoiceLetterColor(Letter);
                }
                else if (palavra.Contains("(B=") && palavra.Contains("(.)"))
                {
                    string novaP = palavra.Replace(")", ") ").Replace("(", " (").Replace("(.) ", "(.)");
                    // (B=Yellow|L=Black) G(.) (B=Magenta|L=Black) A(.) (B=White|L=Black) Y(.)
                    ColorirTexto(novaP);
                }
                else if (palavra.Contains("(.)"))
                {
                    if (palavra.StartsWith("("))
                    {
                        ChoiceBackGroundColor("Black");
                        ChoiceLetterColor("White");
                        Console.Write(palavra.Replace("(.)", "") + " ");
                    }
                    else
                    {
                        Console.Write(palavra.Replace("(.)", ""));
                        ChoiceBackGroundColor("Black");
                        ChoiceLetterColor("White");
                        Console.Write(" ");
                    }

                }
                else
                {
                    Console.Write(palavra + " ");
                }
            }
            //Console.Write("\n");
        }
    }
}