using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Xceed.Words.NET;
using Word = Microsoft.Office.Interop.Word;

namespace BorbaProjeto
{
    internal class ManageLaudos
    {
        readonly string homepag = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents";
        readonly string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        public void CreateNew(Laudo laudo, List<string> listAcReclamante, List<string> listAcReclamada)
        {
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
                    documento.ReplaceText("#numProcesso", laudo.numProcesso);
                    documento.ReplaceText("#nomeReclamante", laudo.nomeReclamante);
                    documento.ReplaceText("#nomeReclamada", laudo.nomeReclamada);
                    documento.ReplaceText("#dataVistoria", laudo.dataVistoria);
                    documento.ReplaceText("#horaVistoria", laudo.horaVistoria);
                    documento.ReplaceText("#localVistoriado", laudo.localVistoriado);
                    documento.ReplaceText("#enderecoVistoriado", laudo.enderecoVistoriado);
                    documento.ReplaceText("#inicioPeriodoReclamado", laudo.dataInicioPeriodoReclamado);
                    documento.ReplaceText("#fimPeriodoReclamado", laudo.dataFimPeriodoReclamado);
                    documento.ReplaceText("#FUNCAO", laudo.funcaoExercida);
                    // Montar local e data da emissão do laudo
                    string[] meses = {"" , "janeiro", "fevereiro", "março", "abril", "maio", "junho",
                                  "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"};
                    string dma = laudo.dataEmissao;
                    if (!string.IsNullOrEmpty(dma))
                    {
                        string dia, mes, ano, strmes, dataEmissao;
                        string[] arrDMA = dma.Split('/');
                        dia = arrDMA[0];
                        mes = arrDMA[1];
                        strmes = meses[Int32.Parse(mes)];
                        ano = arrDMA[2];
                        dataEmissao = $"{laudo.cidadeEmissao}, {dia} de {strmes} de {ano}";
                        documento.ReplaceText("#localDataEmissao", dataEmissao);
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

            /*
             * ANTIGA
             * Função Criada para complemantar DocX (mais métodos do que somente
             * ReplaceText). Especificamente selecionar e alterar paragrafos,
             * salvar o documento e abrir-lo no Word.
             */

            object oMissing = System.Reflection.Missing.Value;
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
            string nome_doc = sequential_number + "-" + laudo.numProcesso + "-" + data + ".docx";

            /* Monta nome da pasta onde o documento será salvo
             * Caminho da aplicação + \laudos\ + número do precesso
             * (homepag + "\\Documents\\laudos\\)
             */
            string str_path = homepag + "\\laudos\\" + laudo.numProcesso + "\\";

            /* Caso a pasta não exista cria */
            string path_str = ManageFiles.CreateDirectories(str_path);

            /* Salva o documento com o nome montado na pasta \laudos\número do processo */
            try
            {
                /* Abre o WORD MESMO ANTES DE SALVAR
                 * tentativa de corrigir o erro em outro PC
                 */
                oWord.Visible = true;

                // Abre a janela Salvar Arquivo do Windows
                // oDoc.Save();

                // Object strFileFormat = "wdFormatDocumentDefault";
                oDoc.SaveAs(path_str + nome_doc);

                oDoc = null;
                MessageBox.Show("Arquivo salvo\n" + path_str + nome_doc);
            }
            catch (Exception e)
            {
                DialogResult dialogResult = MessageBox.Show(e.Message, "Error!", 0, MessageBoxIcon.Exclamation);
                oDoc = null;
            }
        }

    }
}
