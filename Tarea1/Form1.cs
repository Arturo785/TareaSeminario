using System;
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
            Or
        }

        private List<String> reservedWords = new List<String>(new string[] { "if", " while ", " for", " switch ", " return ", " else " });
        private List<String> Types = new List<String>(new string[] { " int" ," void " , " char " , " double " , " float " , " bool " });

        private void btnLoadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpener = new OpenFileDialog();
            myOpener.Filter = "Text|*.txt|*.*";
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
            States myState = States.Start;
            string union = null;
            int counter = 0;


            while(counter < data.Length){
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
                            dataGridView1.Rows.Add(new string[] { union, "Entero", "id: " });
                            union = null;
                            counter--;
                            myState = States.Start;
                        }

                    break;

                    case States.Word:

                    break;

                    case States.Point:

                        if (Char.IsNumber(myChar))
                        {
                            union += myChar;
                            myState = States.Float;
                        }

                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "error", "id:1" });
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
                            dataGridView1.Rows.Add(new string[] { union, "float", "id:" });
                            union = null;
                            myState = States.Start;
                            counter--;
                        }

                        break;

                    case States.GreaterThan:

                        if(myChar == '=')
                        {
                            union += myChar;
                            dataGridView1.Rows.Add(new string[] { union, "mayor igual", "id:" });                           
                        }

                        else if(Char.IsDigit(myChar) || Char.IsLetter(myChar))
                        {
                            dataGridView1.Rows.Add(new string[] { union, "mayor que", "id:" });                           
                            counter--;
                        }
                        else
                        {
                            dataGridView1.Rows.Add(new string[] { union, "error", "id:1" });
                        }

                        union = null;
                        myState = States.Start;

                        break;

                    case States.Less:

                    break;

                    case States.And:

                    break;

                    case States.Or:

                    break;

                }

            }
            
            
            
            
        }
    }
}
