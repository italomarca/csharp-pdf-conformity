using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mlegate
{
    public partial class FrmLogin : Form
    {
        public String UsuarioLogado = "";
        public DB DB = new DB();
        //public FrmConfig config = new FrmConfig();

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //FrmConfig.carregaConfig();
            //MessageBox.Show(FrmConfig.Servidor);
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            ADODB.Recordset rdsLogin = DB.fnExecuteSQL("select " +
                                                        "* " +
                                                    "from " +
                                                        "a1_usuarios " +
                                                    "where " +
                                                        "a1_nome = '" + txtUsuario.Text + "' " +
                                                        "and a1_senha = '" + txtSenha.Text + "'");

            if (rdsLogin.EOF)
            {
                MessageBox.Show("Usuário ou Senha incorretos!");
                return;
            }

            UsuarioLogado = rdsLogin.Fields["a1_nome"].Value;

            this.Hide();

            FrmConjuntos conjuntos = new FrmConjuntos();
            conjuntos.usuarioLogado = UsuarioLogado;
            conjuntos.Show();

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            // Abre configurações
            FrmConfig FrmConfig = new FrmConfig();
            FrmConfig.Show();
        }
    }

    public class DB
    {
        public ADODB.Recordset fnExecuteSQL(String SQL)
        {
            FrmConfig FrmConfig = new FrmConfig();

            ADODB.Connection cn = new ADODB.Connection();
            ADODB.Recordset rs = new ADODB.Recordset();

            FrmConfig.carregaConfig();

            String Banco = FrmConfig.Banco;
            String Servidor = FrmConfig.Servidor;
            String Usuario = FrmConfig.Usuario;
            String Senha = FrmConfig.Senha;
            //String Encript = true;

            String cnStr = "Provider=SQLOLEDB;Initial Catalog=" + Banco
                + ";Data Source=" + Servidor
                + ";User ID=" + Usuario
                + ";Password=" + Senha;

            rs.Open(SQL, cnStr, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
            //rs.Close();

            return rs;
        }
    }
}
