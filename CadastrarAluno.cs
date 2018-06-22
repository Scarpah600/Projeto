using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace menu
{
    public partial class CadastrarAluno : Form
    {
        public CadastrarAluno()
        {
            InitializeComponent();
        }

        private void CadastrarAluno_Load(object sender, EventArgs e)
        {
            try

            {

                MySqlConnection objcon = new MySqlConnection("server=localhost;User Id=administrator;database=haja;password=administrator");
                objcon.Open();
                MySqlCommand objCmd1= new MySqlCommand("select idequipe,equipenome from equipe;", objcon);
                MySqlDataAdapter returnVal1 = new MySqlDataAdapter("select idequipe,equipenome from equipe;", objcon);
                DataTable dt = new DataTable();
                returnVal1.Fill(dt);
                objCmd1.Parameters.Clear();
                objCmd1.CommandType = CommandType.Text;
                MySqlDataReader dr;

                dr = objCmd1.ExecuteReader();

                while (dr.Read())

                {

                    comboBox1.DataSource = dt;

                    comboBox1.DisplayMember = "equipenome";

                    comboBox1.ValueMember = "idequipe";

                }


                objcon.Close();

            }

            catch

            {

                MessageBox.Show("Não foi possivel consultar as equipes ");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Conexao = new MySqlConnection("server=localhost;database=haja;User Id=administrator;password=administrator");
                Conexao.Open();
                MySqlCommand Insert_Equipe = new MySqlCommand("INSERT INTO aluno (idNome,idRa,idequipe)" + "VALUES('" + txt_Nome.Text + "','" + txt_Ra.Text + "','" + comboBox1.SelectedValue.ToString() + "')", Conexao);
                Insert_Equipe.ExecuteNonQuery();
                Conexao.Close();
                MessageBox.Show("Gerado Com Sucesso!");
            }

            catch 
            {
                MessageBox.Show("Erro de banco de dados ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
