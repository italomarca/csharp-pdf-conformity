using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mlegate
{
    public partial class FrmUsuarios : Form
    {
        DB DB = new DB();
        public String registroSelecionado = "";

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void carregarUsuarios()
        {
            gridUsuarios.Rows.Clear();

            ADODB.Recordset usuario = DB.fnExecuteSQL("select * from [dbo].[a1_usuarios]");

            while (!usuario.EOF)
            {
                gridUsuarios.Rows.Add(
                    usuario.Fields["a1_codigo"].Value,
                    usuario.Fields["a1_nome"].Value,
                    usuario.Fields["a1_senha"].Value
                );

                usuario.MoveNext();
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            carregarUsuarios();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DB.fnExecuteSQL("update a1_usuarios set a1_nome = '"+ txtUsuario.Text +"' , a1_senha = '"+ txtSenha.Text +"' where a1_codigo = '"+ txtCodigo.Text +"'");
            carregarUsuarios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.fnExecuteSQL("insert into a1_usuarios values ('"+ txtUsuario.Text +"', '"+ txtSenha.Text +"')");
            carregarUsuarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DB.fnExecuteSQL("delete from a1_usuarios where a1_codigo = '" + txtCodigo.Text + "'");
            carregarUsuarios();
        }

        private void gridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridUsuarios.Rows[e.RowIndex];
                //selecionaRegistro(DB.fnExecuteSQL("select * from a2_conjuntos where a2_codigo = '" + row.Cells[0].Value + "'"));
                //DataGridViewRow row = (DataGridViewRow)gridUsuarios.Rows[e.RowIndex];
                

                txtCodigo.Text = (String)row.Cells[0].Value.ToString();
                txtUsuario.Text = (String)row.Cells[1].Value;    
                txtSenha.Text = (String)row.Cells[2].Value;
            }
        }
    }
}
