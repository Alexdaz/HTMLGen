using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTMLGen
{
    class ConvertText
    {
        public string TextToHtml(RichTextBox rtb)
        {

            int Spam = 0;

            byte R, G, B;

            string SomColrActual = "";
            string SomColrAnterior = "";

            string BackColrActual = "";
            string BackColrAnterior = "";

            string ColrActual = "";
            string ColrAnterior = "";

            string FontActual = "";
            string FontAnterior = "";

            float TamActual = 0;
            float TamAnterior = 0;

            System.Drawing.FontStyle EstiloAtual = 0;
            System.Drawing.FontStyle EstiloAnterior = 0;

            string Texto;

            Texto = "<html>\n<title>Mi Sitio Web</title>\n";

            for (int Cont = 0; Cont <= rtb.Text.Length - 1; Cont++)
            {

                rtb.Select(Cont, 1);

                if (rtb.SelectedText == "\n")
                {
                    Texto += "<br>";
                }
                else
                    if (rtb.SelectedText != "")
                {

                    R = rtb.SelectionColor.R;
                    G = rtb.SelectionColor.G;
                    B = rtb.SelectionColor.B;
                    ColrActual = HTML_RGBHex(R, G, B);

                    R = rtb.SelectionBackColor.R;
                    G = rtb.SelectionBackColor.G;
                    B = rtb.SelectionBackColor.B;
                    SomColrActual = HTML_RGBHex(R, G, B);

                    R = rtb.BackColor.R;
                    G = rtb.BackColor.G;
                    B = rtb.BackColor.B;
                    BackColrActual = HTML_RGBHex(R, G, B);

                    FontActual = rtb.SelectionFont.Name;
                    TamActual = rtb.SelectionFont.Size;
                    EstiloAtual = rtb.SelectionFont.Style;

                    if (ColrActual != ColrAnterior)
                    {
                        Texto += "<span style=color:" + ColrActual + ">";
                        Spam += 1;
                    }

                    //Sombra - Color
                    if (SomColrActual != SomColrAnterior)
                    {
                        Texto += "<span style=background-color:" + SomColrActual + ">";
                        Spam += 1;
                    }
                    //Background - Color
                    if (BackColrActual != BackColrAnterior)
                    {
                        Texto += "<body bgcolor=" + BackColrActual + " > ";
                        Spam += 1;
                    }


                    // Size Font
                    if (TamActual != TamAnterior)
                    {
                        Texto += "<span style=font-size:" + TamActual + "px>";
                        Spam += 1;
                    }

                    // Font
                    if (FontActual != FontAnterior)
                    {
                        Texto += "<span style=font-family:"+ "" + FontActual + "" +">";
                        Spam += 1;
                    }

                    // Estilo Font
                    switch (EstiloAtual)
                    {
                        case System.Drawing.FontStyle.Bold:
                            Texto += "<strong>" + rtb.SelectedText + "</strong>";
                            break;

                        case System.Drawing.FontStyle.Italic:
                            Texto += "<em>" + rtb.SelectedText + "</em>";
                            break;

                        case System.Drawing.FontStyle.Underline:
                            Texto += "<u>" + rtb.SelectedText + "</u>";
                            break;

                        case System.Drawing.FontStyle.Strikeout:
                            Texto += "<strike>" + rtb.SelectedText + "</strike>";
                            break;

                        default:
                            // colocar texto
                            Texto += rtb.SelectedText;
                            break;

                    }

                    TamAnterior = TamActual;
                    FontAnterior = FontActual;
                    ColrAnterior = ColrActual;
                    BackColrAnterior = BackColrActual;
                    SomColrAnterior = SomColrActual;
                    EstiloAnterior = EstiloAtual;
                }
            }

            for (int cont = 1; cont <= Spam; cont++)
            {
                Texto += "</span>";
            }

            Texto += "</div>";
            Texto += "</body>";
            Texto += "\n</html>";

            return Texto;

        }

        private string HTML_RGBHex(byte R, byte G, byte B)
        {

            Object HexR, HexB, HexG = new Object();

            //Rojo
            HexR = string.Format("{0:X}", R);
            if (HexR.ToString().Length < 2) { HexR = "0" + HexR; }

            //Verde
            HexG = string.Format("{0:X}", G);
            if (HexG.ToString().Length < 2) { HexG = "0" + HexG; }

            //Azul
            HexB = string.Format("{0:X}", B);
            if (HexB.ToString().Length < 2) { HexB = "0" + HexB; }

            return "#" + HexR + HexG + HexB;

        }
    }
}

