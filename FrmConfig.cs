using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace mlegate
{
    public partial class FrmConfig : Form
    {
        public string diretorioPrincipal = Directory.GetCurrentDirectory();

        public String Servidor = "";
        public String Usuario = "";
        public String Banco = "";
        public String Senha = "";

        public String DANFEs = "";
        public String DACTEs = "";
        public String protocRec = "";
        public String extratoBanc = "";
        public String adiantBanc = "";
        public String depositos = "";

        public FrmConfig()
        {
            InitializeComponent();
            carregaConfig();
        }

        private void salvaConfig()
        {
            // cria arquivo
            new XDocument(
                new XElement("config",
                    new XElement("BancoDeDados",
                        new XElement("Servidor", txtServidor.Text),
                        new XElement("Banco", txtBanco.Text),
                        new XElement("Usuario", txtUsuario.Text),
                        new XElement("Senha", txtSenha.Text)
                    ),
                    new XElement("Arquivos",
                        new XElement("DANFEs", txtCaminhoDanfe.Text),
                        new XElement("DACTEs", txtCaminhoDacte.Text),
                        new XElement("ProtRec", txtCaminhoProtRec.Text),
                        new XElement("ExtratoBanc", txtCaminhoExtratoBanc.Text),
                        new XElement("AdiantBanc", txtCaminhoAdiantBanc.Text),
                        new XElement("Depositos", txtCaminhoDepositos.Text)
                    )
                )
            )
            .Save(diretorioPrincipal + "\\config.xml");
            //.Save("C:\\Users\\italo.reis\\Documents\\freela\\mlegate\\aplicacao\\config.xml");
        }

        public void carregaConfig(bool preencheForm = false)
        {
            if (!(File.Exists(diretorioPrincipal + "\\config.xml")))
            {
                salvaConfig();
            }

            XDocument xml = XDocument.Load(diretorioPrincipal + "\\config.xml");

            var q = from b in xml.Descendants("BancoDeDados")
                select new
                {
                    Servidor = (string)b.Element("Servidor"),
                    Banco = (string)b.Element("Banco"),
                    Usuario = (string)b.Element("Usuario"),
                    Senha = (string)b.Element("Senha")
                };
            var x = from b in xml.Descendants("Arquivos")
                select new
                {
                    DANFEs = (string)b.Element("DANFEs"),
                    DACTEs = (string)b.Element("DACTEs"),
                    protocRec = (string)b.Element("ProtRec"),
                    extratoBanc = (string)b.Element("ExtratoBanc"),
                    adiantBanc = (string)b.Element("AdiantBanc"),
                    depositos = (string)b.Element("Depositos")
                };

            foreach (var el in x)
            {
                DANFEs = el.DANFEs;
                DACTEs = el.DACTEs;
                protocRec = el.protocRec;
                extratoBanc = el.extratoBanc;
                adiantBanc = el.adiantBanc;
                depositos = el.depositos;
            }

            foreach (var el in q)
            {
                Servidor = el.Servidor;
                Banco = el.Banco;
                Usuario = el.Usuario;
                Senha = el.Senha;
            }

            if (preencheForm)
            {
                txtServidor.Text = Servidor;
                txtBanco.Text = Banco;
                txtUsuario.Text = Usuario;
                txtSenha.Text = Senha;

                txtCaminhoDanfe.Text = DANFEs;
                txtCaminhoDacte.Text = DACTEs;
                txtCaminhoProtRec.Text = protocRec;
                txtCaminhoExtratoBanc.Text = extratoBanc;
                txtCaminhoAdiantBanc.Text = adiantBanc;
                txtCaminhoDepositos.Text = depositos;
            }

        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            if (!(File.Exists(diretorioPrincipal + "\\config.xml")))
            {
                // cria arquivo
                new XDocument(
                    new XElement("config",
                        new XElement("BancoDeDados",
                            new XElement("Servidor", ""),
                            new XElement("Usuario", ""),
                            new XElement("Senha", "")
                        ),
                        new XElement("Arquivos",
                            new XElement("DANFEs", ""),
                            new XElement("DACTEs", ""),
                            new XElement("ProtRec", ""),
                            new XElement("ExtratoBanc", ""),
                            new XElement("AdiantBanc", ""),
                            new XElement("Depositos", "")
                        )
                    )
                )
                .Save(diretorioPrincipal + "\\config.xml");
                //.Save("C:\\Users\\italo.reis\\Documents\\freela\\mlegate\\aplicacao\\config.xml");
            } else
            {
                carregaConfig(true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            salvaConfig();
            MessageBox.Show("Salvo com sucesso!");
        }
    }
}
