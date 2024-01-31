using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ReadCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReadCompare_Click(object sender, EventArgs e)
        {
            List<string> listOriginal_User = new List<string>();
            List<string> listOriginal_Tipo = new List<string>();
            List<string> listOriginal_Otorgado = new List<string>();
            var lastUser = "";
            using (var reader = new StreamReader(@"C:\Data\Development SO\Historial Votos - 30012024.csv"))
            {               
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0].Trim().Equals(""))
                    {
                        values[0] = lastUser;
                    }
                    if (/*Tipo*/(values[1].Trim().Equals("dn")) || (values[2].Trim().Equals("dn"))) //Se puede encontrar en primer o segunda columna "dn"
                    {
                        listOriginal_User.Add(values[0]);
                        listOriginal_Tipo.Add(values[1]);
                        if (values[2].Trim().Equals("dn")){
                            listOriginal_Otorgado.Add(values[3]);
                        } else { 
                            listOriginal_Otorgado.Add(values[2]);
                        }
                    }
                    lastUser = values[0];
                }
                Debug.WriteLine("Elementos listOriginal: " + listOriginal_User.Count);
            }

            List<string> listTarget_User = new List<string>();
            List<string> listTarget_Tipo = new List<string>();
            List<string> listTarget_Otorgado = new List<string>();

            using (var reader = new StreamReader(@"C:\Data\Development SO\Historial Votos 30012050.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0].Trim().Equals(""))
                    {
                        values[0] = lastUser;
                    }
                    if (/*Tipo*/(values[1].Trim().Equals("dn")) || (values[2].Trim().Equals("dn"))){ //Se puede encontrar en primer o segunda columna "dn"
                        listTarget_User.Add(values[0]);
                        listTarget_Tipo.Add(values[1]);
                        if (values[2].Trim().Equals("dn"))
                        {
                            listTarget_Otorgado.Add(values[3]);
                        }
                        else
                        {
                            listTarget_Otorgado.Add(values[2]);
                        }
                    }
                    lastUser = values[0];
                }

                Debug.WriteLine("Elementos listTarget: " + listTarget_User.Count);

            }

            compareDownVotes(listOriginal_User, listOriginal_Otorgado, listTarget_User, listTarget_Otorgado);

        }

        private void compareDownVotes(List<string> listOriginal_User, List<string> listOriginal_Otorgado, List<string> listTarget_User, List<string> listTarget_Otorgado)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listOriginal_User.Count; i++)
            {
                int originalValue = Int32.Parse(listOriginal_Otorgado[i].Split('/')[0].Trim());
                int newValue = Int32.Parse(listTarget_Otorgado[i].Split('/')[0].Trim());
                if (originalValue != newValue)
                {
                    sb.Append("• El usuario \"" +listOriginal_User[i] +"\"\naumento su votación negativa de: "+ originalValue +" hacía: " +newValue + "\n");
                }
            }
            ShowDialog("Votación negativa https://es.stackoverflow.com/", sb.ToString());

        }
        public static int ShowDialog(string caption, string text)
        {
            Form prompt = new Form();
            prompt.Width = 1000;
            prompt.Height = 500;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 10, Top = 10, Text = text };
            textLabel.Size = new Size(1000, 500);
            textLabel.BorderStyle = BorderStyle.Fixed3D;
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 270 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return 0;
        }

    }
}
