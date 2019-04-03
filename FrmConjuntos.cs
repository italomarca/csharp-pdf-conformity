using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using TallComponents.PDF;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace mlegate
{
    public partial class FrmConjuntos : Form
    {
        public String caminhoPrincipal = "C:\\Users\\italo.reis\\Documents\\freela\\mlegate\\aplicacao\\ARQUIVOS ENTRADA";
        public String registroSelecionado = "";
        public String usuarioLogado = "";

        public DB DB = new DB();

        public FrmConjuntos()
        {
            InitializeComponent();
            carregarArquivos();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

            //gridConjuntos.ColumnHeadersVisible = false;
            //pdfNFe.LoadFile("C:\\Users\\italo.reis\\Documents\\freela\\mlegate\\aplicacao\\ARQUIVOS ENTRADA\\teste.pdf");
        }

        public void importarArquivos()
        {
            FrmConfig FrmConfig = new FrmConfig();
            //MessageBox.Show(FrmConfig.DANFEs);
            DirectoryInfo d = new DirectoryInfo(FrmConfig.DANFEs);
            FileInfo[] Files = d.GetFiles("*.pdf");

            foreach (FileInfo file in Files)
            {
                ADODB.Recordset arquivo = DB.fnExecuteSQL("select a2_codigo " +
                                                            "from [dbo].[a2_conjuntos] " +
                                                            "where a2_nome = '" + file.Name + "'");

                if (arquivo.EOF)
                {
                    DB.fnExecuteSQL("insert into [dbo].[a2_conjuntos]" +
                                    "(" +
                                        "a2_nome " +
                                        ",a2_caminho_danfe" +
                                        ", a2_caminho_dacte" +
                                        ", a2_caminho_protocolo_recebimento" +
                                        ", a2_caminho_extrato_bancario" +
                                        ", a2_caminho_adiantamento_bancario" +
                                        ", a2_caminho_deposito" +
                                    ") " +
                                    "values (" +
                                        "'" + file.Name + "'" +
                                        ",'" + FrmConfig.DANFEs + "\\" + file.Name + "'" +
                                        ",'" + FrmConfig.DACTEs + "\\" + file.Name + "'" +
                                        ",'" + FrmConfig.protocRec + "\\" + file.Name + "'" +
                                        ",'" + FrmConfig.extratoBanc + "\\" + file.Name + "'" +
                                        ",'" + FrmConfig.adiantBanc + "\\" + file.Name + "'" +
                                        ",'" + FrmConfig.depositos + "\\" + file.Name + "'" +
                                    ")");
                }
                else
                {
                    // DB.fnExecuteSQL("update [dbo].[a2_conjuntos] " +
                    //                "set " +
                    //                    "a2_nome = '" + file.Name + "' " +
                    //                "where a2_codigo = '"+ arquivo.Fields["a2_codigo"].Value +"'");
                }

            }
        }

        public void carregarArquivos()
        {
            gridConjuntos.Rows.Clear();

            ADODB.Recordset conjuntos = DB.fnExecuteSQL("select * from [dbo].[a2_conjuntos]");

            //List<DataGridViewRow[]> rows = new List<DataGridViewRow[]>();

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            while (!conjuntos.EOF)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridConjuntos);
                row.Cells[0].Value = conjuntos.Fields["a2_codigo"].Value;
                row.Cells[1].Value = conjuntos.Fields["a2_nome"].Value;
                row.Cells[2].Value = conjuntos.Fields["a2_status_danfe"].Value;
                row.Cells[3].Value = conjuntos.Fields["a2_status_dacte"].Value;
                row.Cells[4].Value = conjuntos.Fields["a2_status_protocolo_recebimento"].Value;
                row.Cells[5].Value = conjuntos.Fields["a2_status_extrato_bancario"].Value;
                row.Cells[6].Value = conjuntos.Fields["a2_status_adiantamento_bancario"].Value;
                row.Cells[7].Value = conjuntos.Fields["a2_status_deposito"].Value;
                row.Cells[8].Value = conjuntos.Fields["a2_status_conjunto"].Value;

                rows.Add(row);

                /*
                (
                    conjuntos.Fields["a2_codigo"].Value,
                    conjuntos.Fields["a2_nome"].Value, 
                    conjuntos.Fields["a2_status_danfe"].Value,
                    conjuntos.Fields["a2_status_dacte"].Value,
                    conjuntos.Fields["a2_status_protocolo_recebimento"].Value,
                    conjuntos.Fields["a2_status_extrato_bancario"].Value,
                    conjuntos.Fields["a2_status_adiantamento_bancario"].Value,
                    conjuntos.Fields["a2_status_deposito"].Value,
                    conjuntos.Fields["a2_status_conjunto"].Value
                );
                */

                conjuntos.MoveNext();
            }

            gridConjuntos.Rows.AddRange(rows.ToArray());




            foreach (DataGridViewRow row in gridConjuntos.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 1) // Se não for a primeira coluna nem a segunda
                    {
                        if (!(cell.Value is null))
                        {
                            if (cell.Value.ToString() != "OK")
                            {
                                cell.Style.BackColor = Color.Red;
                                cell.Style.ForeColor = Color.White;
                            }
                            else
                            {
                                cell.Style.BackColor = Color.Green;
                                cell.Style.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            pdfNFe.Dispose();
        }

        private void sincronizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarArquivos();
            carregarArquivos();
        }

        private void gridConjuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectedTab = tabManutencao;
            tabControl2.SelectedTab = tabNFe;

            ///if (e.RowIndex >= 0)
            //{
            DataGridViewRow row = this.gridConjuntos.Rows[e.RowIndex];
            selecionaRegistro(DB.fnExecuteSQL("select * from a2_conjuntos where a2_codigo = '" + row.Cells[0].Value + "'"));
            //}

        }

        private void renderPDF(String caminho, AxAcroPDFLib.AxAcroPDF pdf)
        {
            if (File.Exists(caminho))
            {
                // Renderiza pdf
                pdf.LoadFile(caminho);
            }
            else
            {
                pdf.Hide();
            }

        }

        private Boolean selecionaRegistro(ADODB.Recordset registro, bool recarregaPDFs = true)
        {
            registroSelecionado = "";

            // Carrega PDFs
            //pdfNFe.Dispose();
            //pdfCTe.Dispose();
            //pdfProtRecNFe.Dispose();
            //pdfExtratoBanc.Dispose();
            //pdfAdiantBanc.Dispose();
            //pdfDepositoBanc.Dispose();

            if (registro.EOF)
            {
                return false;
            }

            if (recarregaPDFs)
            {
                if (registro.Fields["a2_caminho_danfe"].Value != "")
                {
                    renderPDF(registro.Fields["a2_caminho_danfe"].Value, pdfNFe);
                    //pdfNFe.LoadFile(registro.Fields["a2_caminho_danfe"].Value);
                }

                if (registro.Fields["a2_caminho_dacte"].Value != "")
                {
                    renderPDF(registro.Fields["a2_caminho_dacte"].Value, pdfCTe);
                    //pdfCTe.LoadFile(registro.Fields["a2_caminho_dacte"].Value);
                }

                if (registro.Fields["a2_caminho_protocolo_recebimento"].Value != "")
                {
                    renderPDF(registro.Fields["a2_caminho_protocolo_recebimento"].Value, pdfProtRecNFe);
                    //pdfProtRecNFe.LoadFile(registro.Fields["a2_caminho_protocolo_recebimento"].Value);
                }

                if (registro.Fields["a2_caminho_extrato_bancario"].Value != "")
                {
                    renderPDF(registro.Fields["a2_caminho_extrato_bancario"].Value, pdfExtratoBanc);
                    //pdfExtratoBanc.LoadFile(registro.Fields["a2_caminho_extrato_bancario"].Value);
                }

                if (registro.Fields["a2_caminho_adiantamento_bancario"].Value != "")
                {
                    renderPDF(registro.Fields["a2_caminho_adiantamento_bancario"].Value, pdfAdiantBanc);
                    //pdfAdiantBanc.LoadFile(registro.Fields["a2_caminho_adiantamento_bancario"].Value);
                }

                if (registro.Fields["a2_caminho_deposito"].Value != "")
                {
                    renderPDF(registro.Fields["a2_caminho_deposito"].Value, pdfDepositoBanc);
                    //pdfDepositoBanc.LoadFile(registro.Fields["a2_caminho_deposito"].Value);
                }
            }


            // Carrega status
            lblStatusNFe.Text = registro.Fields["a2_status_danfe"].Value;
            lblStatusCTe.Text = registro.Fields["a2_status_dacte"].Value;
            lblStatusProtRecNFe.Text = registro.Fields["a2_status_protocolo_recebimento"].Value;
            lblStatusExtratoBanc.Text = registro.Fields["a2_status_extrato_bancario"].Value;
            lblStatusAdiantBanc.Text = registro.Fields["a2_status_adiantamento_bancario"].Value;
            lblStatusDepositoBanc.Text = registro.Fields["a2_status_deposito"].Value;

            lblUsuarioDanfe.Text = registro.Fields["a2_usuario_danfe"].Value;
            lblUsuarioDacte.Text = registro.Fields["a2_usuario_dacte"].Value;
            lblUsuarioProtRec.Text = registro.Fields["a2_usuario_protocolo_recebimento"].Value;
            lblUsuarioExtratoBanc.Text = registro.Fields["a2_usuario_extrato_bancario"].Value;
            lblUsuarioAdiantBanc.Text = registro.Fields["a2_usuario_adiantamento_bancario"].Value;
            lblUsuarioDeposito.Text = registro.Fields["a2_usuario_deposito"].Value;

            registroSelecionado = registro.Fields["a2_codigo"].Value.ToString();

            lblNomeArquivo.Text = registro.Fields["a2_nome"].Value; ;
            lblNomeArquivo2.Text = lblNomeArquivo.Text;
            lblNomeArquivo3.Text = lblNomeArquivo.Text;
            lblNomeArquivo4.Text = lblNomeArquivo.Text;
            lblNomeArquivo5.Text = lblNomeArquivo.Text;
            lblNomeArquivo6.Text = lblNomeArquivo.Text;

            return true;
        }

        private void FrmConjuntos_Load(object sender, EventArgs e)
        {

        }

        private void setStatus(String status, String campoStatus, String campoUsuario)
        {
            if (registroSelecionado == "")
            {
                MessageBox.Show("Erro ao tentar encontrar registro selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (status != "OK" && status != "PENDENTE")
            {
                MessageBox.Show("Status inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DB.fnExecuteSQL("update a2_conjuntos " +
                                "set " + campoStatus + " = '" + status + "' " +
                                ", " + campoUsuario + " = '" + usuarioLogado + "' " +
                            "where a2_codigo = '" + registroSelecionado + "'");

            selecionaRegistro(DB.fnExecuteSQL("select * from a2_conjuntos where a2_codigo = '" + registroSelecionado + "'"), false);

            // Navega para proxima tab
            if (tabControl2.SelectedTab == tabDepositoBanc)
            {
                // Cria conjunto PDF
            }
            else
            {
                tabControl2.SelectTab(tabControl2.SelectedIndex + 1);
            }

        }

        void tabControl1_SelectedIndexChanged(System.Object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabSelecao)
            {
                carregarArquivos();
            }
        }

        private void btnOkNFe_Click(object sender, EventArgs e)
        {
            setStatus("OK", "a2_status_danfe", "a2_usuario_danfe");
        }

        private void btnOkCTe_Click(object sender, EventArgs e)
        {
            setStatus("OK", "a2_status_dacte", "a2_usuario_dacte");
        }

        private void btnOkProtRecNFe_Click(object sender, EventArgs e)
        {
            setStatus("OK", "a2_status_protocolo_recebimento", "a2_usuario_protocolo_recebimento");
        }

        private void btnOkExtratoBanc_Click(object sender, EventArgs e)
        {
            setStatus("OK", "a2_status_extrato_bancario", "a2_usuario_extrato_bancario");
        }

        private void btnOkAdiantBanc_Click(object sender, EventArgs e)
        {
            setStatus("OK", "a2_status_adiantamento_bancario", "a2_usuario_adiantamento_bancario");
        }

        private void btnOkDepositoBanc_Click(object sender, EventArgs e)
        {
            setStatus("OK", "a2_status_deposito", "a2_usuario_deposito");
        }

        private void btnCancelarNFe_Click(object sender, EventArgs e)
        {
            setStatus("PENDENTE", "a2_status_danfe", "a2_usuario_danfe");
        }

        private void btnCancelarCTe_Click(object sender, EventArgs e)
        {
            setStatus("PENDENTE", "a2_status_dacte", "a2_usuario_dacte");
        }

        private void btnCancelarProtRecNFe_Click(object sender, EventArgs e)
        {
            setStatus("PENDENTE", "a2_status_protocolo_recebimento", "a2_usuario_protocolo_recebimento");
        }

        private void btnCancelarExtratoBanc_Click(object sender, EventArgs e)
        {
            setStatus("PENDENTE", "a2_status_extrato_bancario", "a2_usuario_extrato_bancario");
        }

        private void btnCancelarAdiantBanc_Click(object sender, EventArgs e)
        {
            setStatus("PENDENTE", "a2_status_adiantamento_bancario", "a2_usuario_adiantamento_bancario");
        }

        private void btnCancelarDepositoBanc_Click(object sender, EventArgs e)
        {
            setStatus("PENDENTE", "a2_status_deposito", "a2_usuario_deposito");
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios FrmUsuarios = new FrmUsuarios();
            FrmUsuarios.Show();
        }

        private void tabDepositoBanc_Click(object sender, EventArgs e)
        {

        }

        private void gridConjuntos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        static string[] GetFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("../../../../PDFs");
            FileInfo[] fileInfos = dirInfo.GetFiles("*.pdf");
            ArrayList list = new ArrayList();
            foreach (FileInfo info in fileInfos)
            {
                // HACK: Just skip the protected samples file...
                if (info.Name.IndexOf("protected") == -1)
                    list.Add(info.FullName);
            }
            return (string[])list.ToArray(typeof(string));
        }

        public void gerarPdfConjuntos()
        {
            ADODB.Recordset conjuntos = DB.fnExecuteSQL("select a2_codigo from a2_conjuntos " +
                                                        "where " +
                                                            "a2_status_adiantamento_bancario = 'OK' " +
                                                            "and a2_status_dacte = 'OK' " +
                                                            "and a2_status_danfe = 'OK' " +
                                                            "and a2_status_deposito = 'OK' " +
                                                            "and a2_status_extrato_bancario = 'OK' " +
                                                            "and a2_status_protocolo_recebimento = 'OK'");

            while (!(conjuntos.EOF))
            {
                ADODB.Recordset conjunto = DB.fnExecuteSQL("select * from a2_conjuntos where a2_codigo = '" + conjuntos.Fields["a2_codigo"].Value + "'");
                
                // Open the output document
                PdfDocument outputDocument = new PdfDocument();

                while (!(conjunto.EOF))
                {
                    if (File.Exists(conjunto.Fields["a2_caminho_danfe"].Value))
                    {
                        PdfDocument inputDocument = PdfReader.Open(conjunto.Fields["a2_caminho_danfe"].Value, PdfDocumentOpenMode.Import);

                        // Iterate pages
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            // Get the page from the external document...
                            PdfPage page = inputDocument.Pages[idx];
                            // ...and add it to the output document.
                            outputDocument.AddPage(page);
                        }
                    }

                    if (File.Exists(conjunto.Fields["a2_caminho_dacte"].Value))
                    {
                        PdfDocument inputDocument = PdfReader.Open(conjunto.Fields["a2_caminho_dacte"].Value, PdfDocumentOpenMode.Import);

                        // Iterate pages
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            // Get the page from the external document...
                            PdfPage page = inputDocument.Pages[idx];
                            // ...and add it to the output document.
                            outputDocument.AddPage(page);
                        }
                    }

                    if (File.Exists(conjunto.Fields["a2_caminho_protocolo_recebimento"].Value))
                    {
                        PdfDocument inputDocument = PdfReader.Open(conjunto.Fields["a2_caminho_protocolo_recebimento"].Value, PdfDocumentOpenMode.Import);

                        // Iterate pages
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            // Get the page from the external document...
                            PdfPage page = inputDocument.Pages[idx];
                            // ...and add it to the output document.
                            outputDocument.AddPage(page);
                        }
                    }

                    if (File.Exists(conjunto.Fields["a2_caminho_extrato_bancario"].Value))
                    {
                        PdfDocument inputDocument = PdfReader.Open(conjunto.Fields["a2_caminho_extrato_bancario"].Value, PdfDocumentOpenMode.Import);

                        // Iterate pages
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            // Get the page from the external document...
                            PdfPage page = inputDocument.Pages[idx];
                            // ...and add it to the output document.
                            outputDocument.AddPage(page);
                        }
                    }

                    if (File.Exists(conjunto.Fields["a2_caminho_adiantamento_bancario"].Value))
                    {
                        PdfDocument inputDocument = PdfReader.Open(conjunto.Fields["a2_caminho_adiantamento_bancario"].Value, PdfDocumentOpenMode.Import);

                        // Iterate pages
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            // Get the page from the external document...
                            PdfPage page = inputDocument.Pages[idx];
                            // ...and add it to the output document.
                            outputDocument.AddPage(page);
                        }
                    }

                    if (File.Exists(conjunto.Fields["a2_caminho_deposito"].Value))
                    {
                        PdfDocument inputDocument = PdfReader.Open(conjunto.Fields["a2_caminho_deposito"].Value, PdfDocumentOpenMode.Import);

                        // Iterate pages
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            // Get the page from the external document...
                            PdfPage page = inputDocument.Pages[idx];
                            // ...and add it to the output document.
                            outputDocument.AddPage(page);
                        }
                    }

                    if (!Directory.Exists(@"arquivos_saida"))
                    {
                        Directory.CreateDirectory(@"arquivos_saida");
                    }

                   

                    // Save the document...
                    string filename = @"arquivos_saida\" + conjunto.Fields["a2_nome"].Value;
                    outputDocument.Save(filename);
                    // ...and start a viewer.
                    //Process.Start(filename);

                    conjunto.MoveNext();
                }

                conjuntos.MoveNext();
            }
                    
        }

        /*
        private void gerarPdfConjuntos()
        {
            ADODB.Recordset conjuntos = DB.fnExecuteSQL("select a2_codigo from a2_conjuntos " +
                                                        "where " +
                                                            "a2_status_adiantamento_bancario = 'OK' " +
                                                            "and a2_status_dacte = 'OK' " +
                                                            "and a2_status_danfe = 'OK' " +
                                                            "and a2_status_deposito = 'OK' " +
                                                            "and a2_status_extrato_bancario = 'OK' " +
                                                            "and a2_status_protocolo_recebimento = 'OK'");

            while (!(conjuntos.EOF))
            {
                ADODB.Recordset conjunto = DB.fnExecuteSQL("select * from a2_conjuntos where a2_codigo = '"+ conjuntos.Fields["a2_codigo"].Value +"'");
                
                while (!(conjunto.EOF))
                {
                    // Create a document for the merged result.
                    Document mergedDocument = new Document();

                    // Keep a list of input streams to close when done.
                    List<FileStream> streams = new List<FileStream>();

                    // Open input stream and add to list of streams.
                    if (File.Exists(conjunto.Fields["a2_caminho_danfe"].Value))
                    {
                        FileStream DANFE = new FileStream(conjunto.Fields["a2_caminho_danfe"].Value, FileMode.Open, FileAccess.Read);
                        streams.Add(DANFE);
                        Document docDANFE = new Document(DANFE);
                        mergedDocument.Pages.AddRange(docDANFE.Pages.CloneToArray());
                    }
                    
                    if (File.Exists(conjunto.Fields["a2_caminho_dacte"].Value))
                    {
                        FileStream DACTE = new FileStream(conjunto.Fields["a2_caminho_dacte"].Value, FileMode.Open, FileAccess.Read);
                        streams.Add(DACTE);
                        Document docDACTE = new Document(DACTE);
                        mergedDocument.Pages.AddRange(docDACTE.Pages.CloneToArray());
                    }
                    
                    if (File.Exists(conjunto.Fields["a2_caminho_protocolo_recebimento"].Value))
                    {
                        FileStream PROTREC = new FileStream(conjunto.Fields["a2_caminho_protocolo_recebimento"].Value, FileMode.Open, FileAccess.Read);
                        streams.Add(PROTREC);
                        Document docPROTREC = new Document(PROTREC);
                        mergedDocument.Pages.AddRange(docPROTREC.Pages.CloneToArray());
                    }
                    
                    if (File.Exists(conjunto.Fields["a2_caminho_extrato_bancario"].Value))
                    {
                        FileStream EXTBANC = new FileStream(conjunto.Fields["a2_caminho_extrato_bancario"].Value, FileMode.Open, FileAccess.Read);
                        streams.Add(EXTBANC);
                        Document docEXTBANC = new Document(EXTBANC);
                        mergedDocument.Pages.AddRange(docEXTBANC.Pages.CloneToArray());
                    }
                    
                    if (File.Exists(conjunto.Fields["a2_caminho_adiantamento_bancario"].Value))
                    {
                        FileStream ADIANTBANC = new FileStream(conjunto.Fields["a2_caminho_adiantamento_bancario"].Value, FileMode.Open, FileAccess.Read);
                        streams.Add(ADIANTBANC);
                        Document docADIANTBANC = new Document(ADIANTBANC);
                        mergedDocument.Pages.AddRange(docADIANTBANC.Pages.CloneToArray());
                    }

                    if (File.Exists(conjunto.Fields["a2_caminho_deposito"].Value))
                    {
                        FileStream DEPOSITO = new FileStream(conjunto.Fields["a2_caminho_deposito"].Value, FileMode.Open, FileAccess.Read);
                        streams.Add(DEPOSITO);
                        Document docDEPOSITO = new Document(DEPOSITO);
                        mergedDocument.Pages.AddRange(docDEPOSITO.Pages.CloneToArray());
                    }

                    if (!Directory.Exists(@"arquivos_saida"))
                    {
                        Directory.CreateDirectory(@"arquivos_saida");
                    }

                    String caminho = @"arquivos_saida\" + conjunto.Fields["a2_nome"].Value;

                    // Save merged document.
                    using (FileStream output = new FileStream(caminho.Replace("\\\\", "\\"), FileMode.Create, FileAccess.Write))
                    {
                        mergedDocument.Write(output);
                    }

                    // Close all input streams.
                    streams.ForEach(stream => stream.Close());

                    conjunto.MoveNext();
                }
                

                conjuntos.MoveNext();
            }
            
        }*/

        private void gerarConjuntosPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gerarPdfConjuntos();
        }
    }
}
