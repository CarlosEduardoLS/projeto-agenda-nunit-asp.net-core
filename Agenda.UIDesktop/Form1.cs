using Npgsql;
using System;
using System.Windows.Forms;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            txtContatoSalvo.Text = nome;

            string strCon = @"Host=localhost;Port=5400;Database=projeto-tdd;Username=pguser;Password=pgpassword;";
            string id = Guid.NewGuid().ToString();

            var con = new NpgsqlConnection(strCon);
            con.Open();

            string sql = string.Format("INSERT INTO contato (id, nome) VALUES ('{0}', '{1}');", id, nome);
            
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            sql = string.Format("SELECT nome FROM contato c WHERE c.id = '{0}'", id);
            cmd = new NpgsqlCommand(sql, con);
            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            con.Close();
        }
    }
}
