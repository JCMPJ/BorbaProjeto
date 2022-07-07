﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Xceed.Words.NET;
using Word = Microsoft.Office.Interop.Word;

namespace BorbaProjeto
{
    public partial class EditForm : Form
    {
        readonly List<string> listAcReclamante = new List<string>();
        readonly List<string> listAcReclamada = new List<string>();
        readonly string homepag = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents";
        readonly string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        Laudo laudo = new Laudo();
        private int id;

        string sequential_number;
        string numProcesso;
        string dataCriacao;
        string path;
        string str_id;

        string acompanhantesReclamada = null;
        string acompanhantesReclamante = null;

        public EditForm(int arg)
        {
            InitializeComponent();
            id = arg;
        }

        private void Inicio(object sender, EventArgs e)
        {
            DataTable dt = DB.SelectFromId(id);

            if (dt.Rows.Count > 0)
            {

                str_id = dt.Rows[0].ItemArray[0].ToString();
                Console.WriteLine("Id:..." + str_id);
                numProcesso = dt.Rows[0].Field<string>("numProcesso");
                tbProcesso.Text = numProcesso;
                tbReclamante.Text = dt.Rows[0].Field<string>("nomeReclamante");
                tbReclamada.Text = dt.Rows[0].Field<string>("nomeReclamada");
                tbDataVistoria.Text = dt.Rows[0].Field<string>("dataVistoria");
                tbHoraInicio.Text = dt.Rows[0].Field<string>("horaVistoria");
                tbLocalVistoria.Text = dt.Rows[0].Field<string>("localVistoriado");
                tbEndLocal.Text = dt.Rows[0].Field<string>("enderecoVistoriado");
                tbDataIniPeriodo.Text = dt.Rows[0].Field<string>("dataInicioPeriodoReclamado");
                tbDataFimPeriodo.Text = dt.Rows[0].Field<string>("dataFimPeriodoReclamado");
                tbFuncaoExercida.Text = dt.Rows[0].Field<string>("funcaoExercida");
                tbCidadeEmissao.Text = dt.Rows[0].Field<string>("cidadeEmissao");
                tbDataEmissao.Text = dt.Rows[0].Field<string>("dataEmissao");
                dataCriacao = dt.Rows[0].Field<string>("dataCriacao");
                acompanhantesReclamante = dt.Rows[0].Field<string>("acompanhantesReclamante");
                acompanhantesReclamada = dt.Rows[0].Field<string>("acompanhantesReclamada");

                PreencherListaReclamantes();
                PreencherListaReclamadas();

                tbProcesso.Focus();
            }
        }

        private void BtnMontar_Click(object sender, EventArgs e)
        {
            string tx;
            string path = Directory.GetCurrentDirectory();
            /*
            string nprocesso;
            string nomeReclamante;
            string nomeReclamada;
            string data;
            string hora;
            string datahora;
            */
            try
            {
                using (DocX documento = DocX.Load(path + "\\modelo-v01.docx"))
                {
                    tx = tbProcesso.Text;
                    laudo.numProcesso = tx.Replace(',', '.');
                    documento.ReplaceText("#numProcesso", tx.Replace(',', '.'));

                    tx = tbReclamante.Text;
                    laudo.nomeReclamante = tx.ToUpper();
                    documento.ReplaceText("#nomeReclamante", tx.ToUpper());

                    tx = tbReclamada.Text;
                    laudo.nomeReclamada = tx.ToUpper();
                    documento.ReplaceText("#nomeReclamada", tx.ToUpper());
                    documento.ReplaceText("#dataVistoria", tbDataVistoria.Text);
                    laudo.dataVistoria = tbDataVistoria.Text;
                    documento.ReplaceText("#horaVistoria", tbHoraInicio.Text);
                    laudo.horaVistoria = tbHoraInicio.Text;
                    documento.ReplaceText("#localVistoriado", tbLocalVistoria.Text);
                    laudo.localVistoriado = tbLocalVistoria.Text;
                    documento.ReplaceText("#enderecoVistoriado", tbEndLocal.Text);
                    laudo.enderecoVistoriado = tbEndLocal.Text;
                    // #inicioPeriodoReclamado #fimPeriodoReclamado
                    documento.ReplaceText("#inicioPeriodoReclamado", tbDataIniPeriodo.Text);
                    laudo.dataInicioPeriodoReclamado = tbDataIniPeriodo.Text;
                    documento.ReplaceText("#fimPeriodoReclamado", tbDataFimPeriodo.Text);
                    laudo.dataFimPeriodoReclamado = tbDataFimPeriodo.Text;
                    tx = tbFuncaoExercida.Text;
                    laudo.funcaoExercida = tx.ToUpper();
                    documento.ReplaceText("#FUNCAO", tx.ToUpper());

                    // Montar local e data da emissão do laudo
                    string[] meses = {"" , "janeiro", "fevereiro", "março", "abril", "maio", "junho",
                                  "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"};

                    string dma = tbDataEmissao.Text;
                    if (!string.IsNullOrEmpty(dma) && !string.IsNullOrEmpty(tbCidadeEmissao.Text))
                    {
                        string dia, mes, ano, strmes, data;
                        string[] arrDMA = dma.Split('/');
                        dia = arrDMA[0];
                        mes = arrDMA[1];
                        strmes = meses[Int32.Parse(mes)];
                        ano = arrDMA[2];
                        data = $"{tbCidadeEmissao.Text}, {dia} de {strmes} de {ano}";

                        laudo.cidadeEmissao = tbCidadeEmissao.Text;
                        laudo.dataEmissao = dma;

                        documento.ReplaceText("#localDataEmissao", data);
                    }

                    documento.SaveAs(path + "\\novo-documento.docx");
                    documento.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return;
            }

            this.AbrirDoc("novo-documento.docx");

            //Close this form.
            //this.Close();
        }

        /*
         * Função Criada para complemantar DocX (mais métodos do que somente
         * ReplaceText). Especificamente selecionar e alterar paragrafos,
         * salvar o documento e abrir-lo no Word.
         */
        private void AbrirDoc(string nomeDoc)
        {
            object oMissing = System.Reflection.Missing.Value;

            // string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string path = Directory.GetCurrentDirectory();
            string c = path + "\\novo-documento.docx";
            object oTemplate = c;

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();

            oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);

            string nomes = "";
            foreach (Word.Paragraph paragrafo in oDoc.Paragraphs)
            {
                string txtParagrafo = paragrafo.Range.Text;
                if (txtParagrafo.IndexOf("#PeloReclamante") >= 0)
                {
                    nomes = "";
                    foreach (string n in listAcReclamante)
                    {
                        nomes += "\t" + n + "\r\n";
                    }
                    paragrafo.Range.Select();
                    paragrafo.Reset();
                    paragrafo.set_Style("Normal");
                    paragrafo.Range.Font.Size = 12;
                    paragrafo.Range.Font.Name = "Arial";
                    paragrafo.Range.Font.Bold = 0;
                    paragrafo.Range.Text = nomes;

                    laudo.acompanhantesReclamante = nomes;

                }
                else if (txtParagrafo.IndexOf("#PelaReclamada") >= 0)
                {
                    nomes = "";
                    foreach (string n in listAcReclamada)
                    {
                        nomes += "\t" + n + "\r\n";
                    }
                    paragrafo.Range.Select();
                    paragrafo.Reset();
                    paragrafo.set_Style("Normal");
                    paragrafo.Range.Font.Size = 12;
                    paragrafo.Range.Font.Name = "Arial";
                    paragrafo.Range.Font.Bold = 0;
                    paragrafo.Range.Text = nomes;

                    laudo.acompanhantesReclamada = nomes;
                }
            }
            /* Formato ("d") 25/3/2022 */
            DateTime thisDay = DateTime.Today;

            Regex rgx = new Regex("/");
            string data = rgx.Replace(thisDay.ToString("d"), "");

            laudo.dataCriacao = thisDay.ToString("d");

            // Abre o documento no Word
            //oWord.Visible = true;

            // Salva o novo laudo no banco de dados
            DB.CreateNew(laudo);

            /*
             * Montar o mone do arquivo último id gravado no banco mais um + número do processo +
             * data atual na forma ddmmaaa
             */
            int aux = DB.MaxId();
            string sequential_number = Convert.ToString(aux);

            if (aux < 10)
            {
                sequential_number = "00" + sequential_number;
            }
            else if (aux < 100)
            {
                sequential_number = "0" + sequential_number;
            }

            /* Monta nome do documento número sequencial + número do processo + data no formato ddmmaaaa */
            string nome_doc = sequential_number + "-" + tbProcesso.Text.Replace(',', '.') + "-" + data + ".docx";

            /* Monta nome da pasta onde o documento será salvo
             * Caminho da aplicação + \laudos\ + número do precesso
             * (homepag + "\\Documents\\laudos\\)
             */
            string str_path = homepag + "\\laudos\\" + tbProcesso.Text.Replace(',', '.') + "\\";

            /* Caso a pasta não exista cria */
            string path_str = ManageFiles.CreateDirectories(str_path);

            /* Salva o documento com o nome montado na pasta \laudos\número do processo */
            try
            {
                // Abre a janela Salvar Arquivo do Windows
                // oDoc.Save();
                oDoc.SaveAs(path_str + nome_doc);
                oWord.Visible = true;
                oDoc = null;
            }
            catch (Exception e)
            {
                DialogResult dialogResult = MessageBox.Show(e.Message, "Error!", 0, MessageBoxIcon.Exclamation);
                oDoc = null;
            }
        }

        private void PreencherListaReclamantes()
        {
            acompanhantesReclamante = acompanhantesReclamante.Trim();
            string[] nomes = acompanhantesReclamante.Split('\r');

            PreencherLista(nomes, lboxReclamante, listAcReclamante);
        }

        private void PreencherListaReclamadas()
        {

            acompanhantesReclamada = acompanhantesReclamada.Trim();

            string[] nomes = acompanhantesReclamada.Split('\r');

            PreencherLista(nomes, lboxReclamada, listAcReclamada);
        }

        private void PreencherLista(string[] nomes, ListBox lb, List<string> lista)
        {
            string n;
            foreach (string nome in nomes)
            {
                n = nome.Trim();
                lista.Add(n);

                lb.DataSource = null;
                lb.DataSource = lista;
            }
        }

        internal void EditarAcompanhante(string nome, string nomeAnterior, ListBox lb, List<string> lista)
        {
            Console.WriteLine("FORA DO IF Nome:..." + nome + "Nome anterior:..." + nomeAnterior);
            if (!nome.Equals(nomeAnterior))
            {
                Console.WriteLine("DENTRO DO IF Nome:..." + nome + "Nome anterior:..." + nomeAnterior);
                lista[lb.SelectedIndex] = nome;
                lb.DataSource = null;
                lb.DataSource = lista;
            }
        }

        private void CMSI_EditarRemoverReclamante(object sender, ToolStripItemClickedEventArgs e)
        {
            string btnNome = e.ClickedItem.Name.ToString();
            // (smExcluir, smEditar): Reclamante; editarReclamada, excuirReclamada
            ListBox lb;
            List<string> li;
            lb = lboxReclamante;
            li = listAcReclamante;
            EditarExcluir(btnNome, lb, li);
        }

        private void CMSI_EditarRemoverReclamada(object sender, ToolStripItemClickedEventArgs e)
        {
            string btnNome = e.ClickedItem.Name.ToString();
            // (smExcluir, smEditar): Reclamante; editarReclamada, excuirReclamada
            ListBox lb;
            List<string> li;
            lb = lboxReclamada;
            li = listAcReclamada;
            EditarExcluir(btnNome, lb, li);
        }
        private void EditarExcluir(string acao, ListBox lb, List<string> lista)
        {
            // Editar
            if (acao == "smEditar" || acao == "editarReclamada")
            {

            }
            // Excluir
            if (acao == "smExcluir" || acao == "excluirReclamada")
            {
                string caption = "Tem certeza que quer remover?";
                string message = lb.Text;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    lista.RemoveAt(lb.SelectedIndex);
                    lb.DataSource = null;
                    lb.DataSource = lista;
                }
            }
        }

        private bool InserirNaLista(TextBox tb, ListBox lb, List<string> lista)
        {
            if (!string.IsNullOrEmpty(tb.Text))
            {
                lista.Add(tb.Text);
                tb.Text = null;
                tb.Focus();

                lb.DataSource = null;
                lb.DataSource = lista;

                return true;
            }
            else
            {
                return false;
            }

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == 13)
            {
                TextBox tb = (TextBox)sender;
                string str = tb.Name;
                if (str == "tbTesReclamante")
                {
                    this.InserirNaLista(tbTesReclamante, lboxReclamante, listAcReclamante);
                }
                else if (str == "tbTesReclamada")
                {
                    this.InserirNaLista(tbTesReclamada, lboxReclamada, listAcReclamada);
                }
            }
            
        }

        private void BTN_InsLwReclamante_Click(object sender, EventArgs e)
        {
            this.InserirNaLista(tbTesReclamante, lboxReclamante, listAcReclamante);
        }

        private void BTN_InsLwReclamada_Click(object sender, EventArgs e)
        {
            this.InserirNaLista(tbTesReclamada, lboxReclamada, listAcReclamada);
        }

        private void btnAbrirWord_Click(object sender, EventArgs e)
        {
            object oMissing = System.Reflection.Missing.Value;
            string data = "";

            //string str_id = dt.Rows[0].ItemArray[0].ToString();
            //Int16 idBd = dt.Rows[0].Field<Int16>("id");
            //sequential_number = Convert.ToString(id);
            sequential_number = str_id.Trim();
            int idBd = int.Parse(str_id);

            if (idBd < 10)
            {
                sequential_number = "00" + sequential_number;
            }
            else if (idBd < 100)
            {
                sequential_number = "0" + sequential_number;
            }
            //numProcesso = dt.Rows[0].Field<string>("numProcesso");
            //dataCriacao = dt.Rows[0].Field<string>("dataCriacao");
            if (!string.IsNullOrEmpty(dataCriacao))
            {
                Regex rgx = new Regex("/");
                data = rgx.Replace(dataCriacao, "");
            }
            else
            {
                MessageBox.Show("Erros dataCriacao: " + dataCriacao);
                return;
            }


            //path = appPath + "\\laudos\\1234567-12.1234.1.15.5555\\" + "014-1234567-12.1234.1.15.5555-19062022.docx";
            path = homepag + "\\laudos\\" + numProcesso + "\\" + sequential_number + "-" + numProcesso + "-" + data + ".docx";
            Console.WriteLine("PATH:..." + path);

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            if (File.Exists(path))
            {
                oDoc = oWord.Documents.Open(path, ReadOnly: false);
                //oDoc.Activate();
                oWord.Visible = true;
            }
            else
            {
                MessageBox.Show("Erro o arquivo não foi encontrado!\n" + path);
            }

        }

        private void BTN_Voltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
