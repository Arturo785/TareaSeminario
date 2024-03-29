﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tarea1
{
    public partial class MainForm : Form
    {
        const int dataRows = 3;
        public MainForm()
        {
            InitializeComponent();
            createDataGrid();
        }

        private enum States{
            Start,
            Equal,
            Number,
            Word,
            Point,
            Float,
            GreaterThan,
            Less,
            And,
            Or,
            Different
        }

        private List<String> reservedWords = new List<String>(new string[] { "if", "while", "for", "switch", "return", "else","main" });
        private List<String> Types = new List<String>(new string[] { "int" ,"void ", "char" , "double" , "float" , "bool" });

        private void btnLoadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpener = new OpenFileDialog();
            myOpener.Filter = "*.txt|*.*";
            Stream myStream;
        
            try
            {
                if (myOpener.ShowDialog() == DialogResult.OK)
                {
                    if((myStream = myOpener.OpenFile()) != null)
                    {
                        loadToTextBox(myStream, myOpener);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void loadToTextBox(Stream myStream, OpenFileDialog myOpener)
        {
            if ((myStream = myOpener.OpenFile()) != null)
            {
                string strFileName = myOpener.FileName;
                string content = File.ReadAllText(strFileName);

                txtBoxFirst.Text = content;
            }
        }

        private void setDataToGrid()
        {
           
            string[] words = txtBoxFirst.Text.Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;

            while (index < words.Length)
            {
                string[] adder = new string[dataRows];
                for (int i = 0; i < dataRows; i++)
                {
                    if(index >= words.Length) { break; }
                    adder[i] = words[index];
                    index++;
                }
                dataGridView1.Rows.Add(adder);
            }
            MessageBox.Show("Numero de palabras; " + words.Length);
            
        }

        private void createDataGrid()
        {
            dataGridView1.ColumnCount = dataRows;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void brnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtBoxSecond.Text = txtBoxFirst.Text;
            evaluateCharacter(txtBoxFirst.Text);


        }

        private void evaluateCharacter(string data)
        {
            if(data == "")
            {
                return;
            }

            States myState = States.Start;
            string union = null;
            int counter = 0;

            data = data.Insert(data.Length, "$");
            
      

            while (counter < data.Length){
                Char myChar = data[counter];
                switch (myState)
                {
                    case States.Start:

                        if (Char.IsLetter(myChar))
                        {
                            union += myChar;
                            myState = States.Word;
                        }

                        else if (Char.IsNumber(myChar))
                        {
                            union += myChar;
                            myState = States.Number;
                        }

                        else if (myChar == '!')
                        {
                            union += myChar;
                            myState = States.Different;
                        }

                        else if (myChar == '{')
                        {
                            dataGridView1.Rows.Add(new string[] { "{", "llave izq", "id: 6" });
                        }

                        else if (myChar == '}')
                        {
                            dataGridView1.Rows.Add(new string[] { "}", "llave der", "id: 7" });
                        }

                        else if (myChar == '(')
                        {
                            dataGridView1.Rows.Add(new string[] { "(", "parentesis izq", "id: 4" });
                        }

                        else if (myChar == ')')
                        {
                            dataGridView1.Rows.Add(new string[] { ")", "parentesis der", "id: 5" });
                        }

                        else if (myChar == ';')
                        {
                            dataGridView1.Rows.Add(new string[] { ";", "punto y coma", "id: 2" });
                        }

                        else if (myChar == ',')
                        {
                            dataGridView1.Rows.Add(new string[] { ",", "coma", "id: 3" });
                        }

                        else if (myChar == '+')
                        {
                            dataGridView1.Rows.Add(new string[] { "+", "suma", "id: 5" });
                        }

                        else if (myChar == '-')
                        {
                            dataGridView1.Rows.Add(new string[] { "-", "resta", "id: 17" });
                        }

                        else if (myChar == '*')
                        {
                            dataGridView1.Rows.Add(new string[] { "*", "multiplicación", "id: 16" });
                        }

                        else if (myChar == '/')
                        {
                            dataGridView1.Rows.Add(new string[] { "/", "division", "id: 16" });
                        }

                        else if (myChar == '=')
                        {
                            union += myChar;
                            myState = States.Equal;
                        }

                        else if (myChar == '>')
                        {
                            union += myChar;
                            myState = States.GreaterThan;
                        }

                        else if (myChar == '<')
                        {
                            union += myChar;
                            myState = States.Less;
                        }

                        else if (myChar == '&')
                        {
                            union += myChar;
                            myState = States.And;
                        }

                        else if (myChar == '|')
                        {
                            union += myChar;
                            myState = States.Or;
                        }

                        else if (myChar == '$')
                        {
                            dataGridView1.Rows.Add(new string[] { "$", "pesos", "id: 21" });
                        }

                        break;

                    case States.Number:

                        if (Char.IsNumber(myChar)){
                            union += myChar;
                        }
                        else if (myChar == '.')
                        {
                            union += myChar;
                            myState = States.Point;
                        }
                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "Entero", "id: 13" });
                            union = null;
                            counter--;
                            myState = States.Start;
                        }

                    break;

                    case States.Word:

                        if(Char.IsLetterOrDigit(myChar) || myChar == '_')
                        {
                            union += myChar;
                        }

                        else
                        {
                            if (reservedWords.Contains(union))
                            {
                                if (union == "if")
                                {
                                    dataGridView1.Rows.Add(new string[] { union, "if", "id:9" });
                                }

                                else if (union == "else")
                                {
                                    dataGridView1.Rows.Add(new string[] { union, "else", "id:12" });
                                }

                                else if (union == "return")
                                {
                                    dataGridView1.Rows.Add(new string[] { union, "return", "id:11" });
                                }

                                else if (union == "while")
                                {
                                    dataGridView1.Rows.Add(new string[] { union, "while", "id:10" });
                                }

                                else
                                {
                                    dataGridView1.Rows.Add(new string[] { union, "reservada", "id:" });
                                }
                            }

                            else if (Types.Contains(union))
                            {
                                dataGridView1.Rows.Add(new string[] { union, "tipo", "id:0" });
                            }
                            else
                            {
                                dataGridView1.Rows.Add(new string[] { union, "identificador", "id:1" });
                            }

                            union = null;
                            myState = States.Start;
                            counter--;
                        }

                    break;

                    case States.Point:

                        if (Char.IsNumber(myChar))
                        {
                            union += myChar;
                            myState = States.Float;
                        }

                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "error", "id:-1" });
                            union = null;
                            myState = States.Start;
                        }

                    break;

                    case States.Float:

                        if (Char.IsNumber(myChar))
                        {
                            union += myChar;
                        }

                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "float", "id:13" });
                            union = null;
                            myState = States.Start;
                            counter--;
                        }

                        break;

                    case States.GreaterThan:

                        if(myChar == '=')
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "mayor igual", "id:17" });                           
                        }

                        else if(Char.IsLetterOrDigit(myChar) || Char.IsWhiteSpace(myChar))
                        {
                            dataGridView1.Rows.Add(new string[] { union, "mayor que", "id:17" });                           
                            counter--;
                        }
                        else
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "error", "id:-1" });
                        }

                        union = null;
                        myState = States.Start;

                        break;

                    case States.Less:

                        if (myChar == '=')
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "menor igual", "id:17" });
                        }

                        else if (Char.IsLetterOrDigit(myChar) || Char.IsWhiteSpace(myChar))
                        {
                            dataGridView1.Rows.Add(new string[] { union, "menor que", "id:17" });
                            counter--;
                        }
                        else
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "error", "id:-1" });
                        }

                        union = null;
                        myState = States.Start;

                        break;

                    case States.And:

                        if (myChar == '&')
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "and", "id:19" });
                        }
                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "error", "id:-1" });
                            counter--;
                        }
                        union = null;
                        myState = States.Start;

                        break;

                    case States.Or:

                        if (myChar == '|')
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "or", "id:20" });
                        }
                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "error", "id:1" });
                            counter--;
                        }
                        union = null;
                        myState = States.Start;

                        break;

                    case States.Equal:

                        if(myChar == '=')
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "comparacion", "id:18" });
                        }

                        else
                        {
                            counter--;
                            dataGridView1.Rows.Add(new string[] { union, "asignacion", "id:8" });
                        }

                        union = null;
                        myState = States.Start;
                        break;

                    case States.Different:

                        if(myChar == '=')
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "diferente de", "id:18" });
                        }

                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "negacion", "id:18" });
                            counter--;
                        }

                        union = null;
                        myState = States.Start;
                        break;
                   

                }
                counter++;

            }
            if(union != null)
            {
                checkLastIteration(union);
            }
            
            
        }

        private void checkLastIteration(string residue)
        {
            bool num, word, point;
            num = word = point = false;

            foreach(char myChar in residue)
            {
                if (Char.IsNumber(myChar)) { num = true; }

                else if (Char.IsLetter(myChar)) { word = true; }

                if (myChar == '.' ){ point = true; }
            }

            if (word)
            {
                if (reservedWords.Contains(residue)){
                    dataGridView1.Rows.Add(new string[] { residue, "reservada", "id:" });
                }

                else if (Types.Contains(residue))
                {
                    dataGridView1.Rows.Add(new string[] { residue, "tipo", "id:" });
                }
                else
                {
                    dataGridView1.Rows.Add(new string[] { residue, "identificador", "id:1" });
                }
            }
            else if (!word)
            {
                if (point)
                {
                    dataGridView1.Rows.Add(new string[] { residue, "float", "id:" });
                }
                else
                {
                    dataGridView1.Rows.Add(new string[] { residue, "int", "id:" });
                }
            }
        }
    }
}
