﻿using AppFatureClient.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AppFatureClient
{
    public partial class FormPedidoVisao : AppLib.Windows.FormVisao
    {
        private static FormPedidoVisao _instance = null;

        string EnderecoEmail;
        int PortaEmail;
        string UsuarioEmail;
        string SenhaEmail;
        bool SSL;
        string EnviarComo;
        string EnviarComoDisplay;
        string EnviarPara;
        string Enderecos;
        string Assunto;

        public static FormPedidoVisao GetInstance()
        {
            if (_instance == null)
                _instance = new FormPedidoVisao();
            return _instance;
        }

        private bool AnexoItemMovimento;
        private bool AnexoMail;


        public FormPedidoVisao()
        {
            InitializeComponent();
            MetodosSQL.CS = AppLib.Context.poolConnection.Get().ConnectionString;

        }

        private void FormPedidoVisao_Load(object sender, EventArgs e)
        {
            AnexoItemMovimento = false;

            grid1.GetAnexos().Add("Item do Movimento", null, ItemMovimento);
            grid1.GetAnexos().Add("Histórico de Liberação", null, HistoricoLiberacao);
            //grid1.GetAnexos().Add("E-mails enviados", null, MailMovimento);
            grid1.GetAnexos().Add("Fechar Anexo", null, FecharAnexos);

            grid1.GetProcessos().Add("-", null, null);

            //grid1.GetProcessos().Add("Imprimir Pedido Líquido", null, ImprimirPedidoLiquido);
            //grid1.GetProcessos().Add("Imprimir Pedido Desconto", null, ImprimirPedidoDesconto);
            //grid1.GetProcessos().Add("Imprimir Pedido Antigo", null, ImprimirPedidoAntigo);
            grid1.GetProcessos().Add("Imprimir Pedido", null, ImprimirMovimento);
            grid1.GetProcessos().Add("Enviar Email", null, EnviaEmail);
            //grid1.GetProcessos().Add("Enviar Email", null, EnviaEmail);

            //grid1.GetProcessos().Add("Imprimir Pedido Acessórios", null, ImprimirPedidoAcessorios);
            //grid1.GetProcessos().Add("Imprimir Compromisso de Venda e Compra a Prazo", null, ImprimirCompromissoCompraVendaPrazo);
            //grid1.GetProcessos().Add("Imprimir Contrato de Venda com Alienação", null, ImprimirContratoVendaAlienacao);
            //grid1.GetProcessos().Add("Imprimir Contrato de Compra e Venda", null, ImprimirContratoCompraVenda);

            grid1.GetProcessos().Add("-", null, null);

            //grid1.GetProcessos().Add("Faturar Movimento", null, FaturarMovimento);
            grid1.GetProcessos().Add("Cancelar Movimento", null, CancelarMovimento);
            grid1.GetProcessos().Add("Rastrear Movimento", null, Rastreabilidade);

            grid1.GetProcessos().Add("-", null, null);

            grid1.GetProcessos().Add("Liberar Movimento", null, LiberarMovimento);
            grid1.GetProcessos().Add("Bloquear Movimento", null, BloquearMovimento);

            OrdenaGridView();
        }

        public void EnviaEmail(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8072", AppLib.Context.Perfil))
            {
                DataRow dr = grid1.GetDataRow();
                MetodosEmail.EnviarEmailOrcamentoPedido(dr, grid1.Conexao);
            }
        }

        public void LiberarMovimento(object sender, EventArgs e)
        {
            try
            {
                if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8070", AppLib.Context.Perfil))
                {
                    DataRowCollection drc = grid1.GetDataRows();
                    List<string> exec = new List<string>();


                    bool pcpBloqueado = false;

                    foreach (DataRow mov in drc)
                    {
                        if (mov["STATUS_PCP"].ToString() == "LIBERADO")
                        {
                            throw new Exception("Para fazer a liberação os status devem estar bloqueados.");
                        }
                    }

                    AppLib.Windows.FormMessagePrompt prompt = new AppLib.Windows.FormMessagePrompt();
                    prompt.richTextBox1.Text = "Motivo da liberação";
                    prompt.ShowDialog();



                    if (!string.IsNullOrWhiteSpace(prompt.textBox1.Text))
                    {
                        foreach (DataRow mov in drc)
                        {
                            exec.Add(string.Format("EXEC MOV_LIBERA_PEDIDO 1, {0}", mov["IDMOV"].ToString()));

                            exec.Add($@"insert into ZHISTORICO values (/*CODCOLIGADA*/ '{AppLib.Context.Empresa}', 
                                                               /*CODFILIAL*/ {AppLib.Context.Filial}, 
                                                               /*IDMOV*/ {mov["IDMOV"]}, 
                                                               /*CODTMV*/ '{mov["CODTMV"]}', 
                                                               /*MOTIVO*/ '{prompt.textBox1.Text}', 
                                                               /*DATALIBERACAO*/ GETDATE(), 
                                                               /*USUARIOLIBERACAO*/ '{AppLib.Context.Usuario}')");
                        }



                        MetodosSQL.ExecMultiple(exec);

                        //grid1.Atualizar();

                        MessageBox.Show("Concluido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BloquearMovimento(object sender, EventArgs e)
        {
            try
            {
                if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8071", AppLib.Context.Perfil))
                {
                    DataRowCollection drc = grid1.GetDataRows();
                    List<string> exec = new List<string>();

                    foreach (DataRow mov in drc)
                    {
                        string sql = $@"select count(1) as 'TOTAL'
                        from KITMMOVITEMORDEM
                        where CODCOLIGADA = {AppLib.Context.Empresa}
                        and IDMOV = {mov["IDMOV"]}";

                        if ((int)MetodosSQL.GetObject(sql, "TOTAL") > 0)
                        {
                            if (mov["STATUS_PCP"].ToString() == "BLOQUEADO")
                            {
                                throw new Exception("Para fazer o bloqueio os status devem estar liberados.");
                            }
                        }
                        else
                        {
                            throw new Exception($"Não existem ordens para o pedido {mov["NUMEROMOV"]}.");
                        }
                    }

                    foreach (DataRow mov in drc)
                    {
                        exec.Add(string.Format("MOV_BLOQUEIA_PEDIDO 1, {0}", mov["IDMOV"].ToString()));
                    }

                    MetodosSQL.ExecMultiple(exec);

                    //grid1.Atualizar();

                    MessageBox.Show("Concluido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FecharAnexos(object sender, EventArgs e)
        {
            try
            {
                AnexoItemMovimento = false;

                xtpItensMovimento.PageVisible = false;

                splitContainer1.Panel2Collapsed = true;
            }
            catch { }
        }

        public void MailMovimento(object sender, EventArgs e)
        {
            FecharAnexos(null, null);
            DataRow dr = null;

            try
            {
                dr = grid1.GetDataRow();
            }
            catch { }

            if (dr == null)
                return;

            AnexoMail = true;
            string ConsultaFiltro = string.Empty;

            try
            {
                splitContainer1.Panel2Collapsed = false;

                ConsultaFiltro = String.Format(@"select CODUSUARIO, SENDERADDR, TOADDR, SUBJECT, SENDTIME, BODY from ZMAILSEND 
                                                 where CODCOLIGADA = 1 and CODFILIAL = 1 and IDMOV = '{0}'", dr["IDMOV"].ToString());

                ConsultaFiltro = AppLib.Context.poolConnection.Get(grid1.Conexao).ParseCommand(ConsultaFiltro, new Object[] { dr["CODCOLIGADA"], dr["IDMOV"] });

                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridView1.GridControl.DataSource = AppLib.Context.poolConnection.Get(grid1.Conexao).ExecQuery(ConsultaFiltro, new Object[] { });

                // formata as colunas
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    String TempColuna = gridView1.Columns[i].FieldName;
                    String TempTipo = gridView1.Columns[i].ColumnType.ToString();
                    String TempFormat = gridView1.Columns[i].DisplayFormat.ToString();

                    if (gridView1.Columns[i].ColumnType == typeof(DateTime))
                    {
                        gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss.fff";
                    }
                }

                // Tratamentos para a grid
                // Grid somente leitura
                gridView1.OptionsBehavior.Editable = false;

                // Grid com seleção de multiplos registros
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

                // Grid com scroll horizontal
                gridView1.OptionsView.ColumnAutoWidth = false;

                // Grid com auto ajuste do melhor tamanho das colunas
                gridView1.BestFitMaxRowCount = 800;
                gridView1.BestFitColumns();

                // Grid mostrar coluna de filtro
                gridView1.OptionsView.ShowAutoFilterRow = true;


                // Grid sempre mostrar filtro no rodapé
                // gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

                // Grid zebrada
                // gridView1.OptionsView.EnableAppearanceEvenRow = true;
                // gridView1.Appearance.EvenRow.BackColor = Color.Thistle;   
            }
            catch (Exception ex)
            {
                new AppLib.Windows.FormExceptionSQL().Mostrar("Erro ao executar consulta.", ConsultaFiltro, ex);
            }
        }

        public void ItemMovimento(object sender, EventArgs e)
        {
            if (grid1.gridView1.SelectedRowsCount > 0)
            {
                DataRow dr = null;
                try
                {
                    dr = grid1.GetDataRow();
                }
                catch { }

                if (dr == null)
                    return;

                AnexoItemMovimento = true;
                string ConsultaFiltro = string.Empty;

                try
                {
                    splitContainer1.Panel2Collapsed = false;
                    ConsultaFiltro = @"
SELECT
TITMMOV.NSEQITMMOV,
TITMMOV.IDPRD,
TPRD.CODIGOPRD,
ISNULL(TPRD.DESCRICAO, TPRD.NOMEFANTASIA) PRODUTO,
TITMMOV.CODUND,
CAST(TITMMOV.QUANTIDADEORIGINAL AS NUMERIC(15,2)) QUANTIDADE,
CAST(TITMMOV.PRECOUNITARIO AS NUMERIC (15,2)) PRECOUNITARIO,
TPRD.NUMEROCCF

FROM TITMMOV
LEFT JOIN TITMMOVCOMPL ON TITMMOV.CODCOLIGADA = TITMMOVCOMPL.CODCOLIGADA
  AND TITMMOV.IDMOV = TITMMOVCOMPL.IDMOV
  AND TITMMOV.NSEQITMMOV = TITMMOVCOMPL.NSEQITMMOV
LEFT JOIN TITMMOVHISTORICO ON TITMMOV.CODCOLIGADA = TITMMOVHISTORICO.CODCOLIGADA
  AND TITMMOV.IDMOV = TITMMOVHISTORICO.IDMOV
  AND TITMMOV.NSEQITMMOV = TITMMOVHISTORICO.NSEQITMMOV,
  TPRD

WHERE TITMMOV.CODCOLIGADA = TPRD.CODCOLIGADA
  AND TITMMOV.IDPRD = TPRD.IDPRD
  AND TITMMOV.CODCOLIGADA = ?
  AND TITMMOV.IDMOV = ?";

                    ConsultaFiltro = AppLib.Context.poolConnection.Get(grid1.Conexao).ParseCommand(ConsultaFiltro, new Object[] { dr["CODCOLIGADA"], dr["IDMOV"] });

                    gridControl1.DataSource = null;
                    gridView1.Columns.Clear();
                    gridView1.GridControl.DataSource = AppLib.Context.poolConnection.Get(grid1.Conexao).ExecQuery(ConsultaFiltro, new Object[] { });

                    // formata as colunas
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        String TempColuna = gridView1.Columns[i].FieldName;
                        String TempTipo = gridView1.Columns[i].ColumnType.ToString();
                        String TempFormat = gridView1.Columns[i].DisplayFormat.ToString();

                        if (gridView1.Columns[i].ColumnType == typeof(DateTime))
                        {
                            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss.fff";
                        }
                    }

                    // Tratamentos para a grid
                    // Grid somente leitura
                    gridView1.OptionsBehavior.Editable = false;

                    // Grid com seleção de multiplos registros
                    gridView1.OptionsSelection.MultiSelect = true;
                    gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

                    // Grid com scroll horizontal
                    gridView1.OptionsView.ColumnAutoWidth = false;

                    // Grid com auto ajuste do melhor tamanho das colunas
                    gridView1.BestFitMaxRowCount = 800;
                    gridView1.BestFitColumns();

                    // Grid mostrar coluna de filtro
                    gridView1.OptionsView.ShowAutoFilterRow = true;

                    xtpItensMovimento.PageVisible = true;
                }
                catch (Exception ex)
                {
                    new AppLib.Windows.FormExceptionSQL().Mostrar("Erro ao executar consulta.", ConsultaFiltro, ex);
                }
            }
        }

        public void HistoricoLiberacao(object sender, EventArgs e)
        {
            FecharAnexos(null, null);
            DataRow dr = null;
            try
            {
                dr = grid1.GetDataRow();
            }
            catch { }

            if (dr == null)
                return;

            AnexoItemMovimento = true;
            string ConsultaFiltro = string.Empty;

            try
            {
                splitContainer1.Panel2Collapsed = false;
                ConsultaFiltro = $@"select * from ZHISTORICO where CODCOLIGADA = {dr["CODCOLIGADA"]} and IDMOV = {dr["IDMOV"]}";

                ConsultaFiltro = AppLib.Context.poolConnection.Get(grid1.Conexao).ParseCommand(ConsultaFiltro, new Object[] { });
                gridView1.GridControl.DataSource = AppLib.Context.poolConnection.Get(grid1.Conexao).ExecQuery(ConsultaFiltro, new Object[] { });

                // formata as colunas
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    String TempColuna = gridView1.Columns[i].FieldName;
                    String TempTipo = gridView1.Columns[i].ColumnType.ToString();
                    String TempFormat = gridView1.Columns[i].DisplayFormat.ToString();

                    if (gridView1.Columns[i].ColumnType == typeof(DateTime))
                    {
                        gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss.fff";
                    }
                }

                // Tratamentos para a grid
                // Grid somente leitura
                gridView1.OptionsBehavior.Editable = false;

                // Grid com seleção de multiplos registros
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

                // Grid com scroll horizontal
                gridView1.OptionsView.ColumnAutoWidth = false;

                // Grid com auto ajuste do melhor tamanho das colunas
                gridView1.BestFitMaxRowCount = 800;
                gridView1.BestFitColumns();

                // Grid mostrar coluna de filtro
                gridView1.OptionsView.ShowAutoFilterRow = true;

                // Grid sempre mostrar filtro no rodapé
                // gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

                // Grid zebrada
                // gridView1.OptionsView.EnableAppearanceEvenRow = true;
                // gridView1.Appearance.EvenRow.BackColor = Color.Thistle;   
            }
            catch (Exception ex)
            {
                new AppLib.Windows.FormExceptionSQL().Mostrar("Erro ao executar consulta.", ConsultaFiltro, ex);
            }
        }

        private void grid1_SetParametros(object sender, EventArgs e)
        {
            grid1.Parametros = new Object[] { AppLib.Context.Empresa };
        }

        private void grid1_Editar(object sender, EventArgs e)
        {
            FormOrcamentoCadastro frm = new FormOrcamentoCadastro();
            frm.CODSERIE = "PVP";
            frm.row = grid1.GetDataRow();
            frm.Editar(grid1.bs);
            //new FormPedidoCadastro().Editar(grid1.bs);

            if (frm.isCancelado == false)
            {
                if (MessageBox.Show("Deseja visualizar o Pedido?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ImprimirMovimento(sender, e);
                }
            }
        }

        private void grid1_Excluir(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o movimento ?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                splashScreenManager1.ShowWaitForm();

                DataRowCollection Movimentos = grid1.GetDataRows();
                if (Movimentos != null)
                {
                    for (int i = 0; i < Movimentos.Count; i++)
                    {
                        AppInterop.MovExclusaoPar exclusao = new AppInterop.MovExclusaoPar();

                        exclusao.CodColigada = AppLib.Context.Empresa;
                        exclusao.CodSistemaLogado = "T";
                        exclusao.CodUsuarioLogado = AppLib.Context.Usuario;
                        exclusao.IdMov = Convert.ToInt32(Movimentos[i]["IDMOV"]);

                        AppInterop.Message msgexclusao;
                        if (FatureContexto.Remoto)
                        {
                            msgexclusao = new Util().ConvertToMessage(FatureContexto.ServiceSoapClient.ExcluiMovimento(AppLib.Context.Usuario, AppLib.Context.Senha, new Util().ConvertToWSMovExclusaoPar(exclusao)));
                        }
                        else
                        {
                            msgexclusao = FatureContexto.ServiceClient.ExcluiMovimento(AppLib.Context.Usuario, AppLib.Context.Senha, exclusao);
                        }

                        this.Cursor = Cursors.Default;

                        if (int.Parse(msgexclusao.Retorno.ToString()) > 0)
                        {
                            string sMensagem = string.Empty;
                            bool bExclusao = false;
                            while (!bExclusao)
                            {
                                string sSql = @"SELECT STATUS FROM ZTMOVCANEXC WHERE CODCOLIGADA = ? AND IDMOV = ?";
                                string sStatus = AppLib.Context.poolConnection.Get("Start").ExecGetField(string.Empty, sSql, new Object[] { Movimentos[i]["CODCOLIGADA"], Movimentos[i]["IDMOV"] }).ToString();

                                if (sStatus != "A")
                                {
                                    if (sStatus == "R")
                                    {
                                        //System.Threading.Thread.Sleep(5000); //5s                                    
                                    }

                                    if (sStatus == "S")
                                    {
                                        ExcluirComposicaoItem(msgexclusao.Retorno.ToString());

                                        splashScreenManager1.CloseWaitForm();

                                        bExclusao = true;
                                        msgexclusao.Mensagem = "Exclusão realizada com sucesso";
                                    }

                                    if (sStatus == "E")
                                    {
                                        bExclusao = true;

                                        sSql = "SELECT MENSAGEM FROM ZTMOVCANEXC WHERE OPERACAO = 'E' AND CODCOLIGADA = " + Movimentos[i]["CODCOLIGADA"] + " AND IDMOV = " + Movimentos[i]["IDMOV"];
                                        msgexclusao.Mensagem = AppLib.Context.poolConnection.Get("Start").ExecGetField(null, sSql, new object[] { }).ToString();

                                        splashScreenManager1.CloseWaitForm();

                                        throw new Exception(msgexclusao.Mensagem);
                                    }
                                }
                                else
                                {
                                    //System.Threading.Thread.Sleep(5000); //5s
                                }
                            }

                            MessageBox.Show(msgexclusao.Mensagem);
                        }
                        else
                        {
                            splashScreenManager1.CloseWaitForm();

                            throw new Exception(msgexclusao.Mensagem);
                        }
                    }      
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImprimirContratoCompraVenda(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8027", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    RelNovoContrato relatorio = new RelNovoContrato();
                    relatorio.SelectRow = grid1.GetDataRow();
                    relatorio.Conexao = grid1.Conexao;
                    DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(relatorio);
                    tool.ShowRibbonPreviewDialog();
                }
            }
        }

        public void ImprimirContratoVendaAlienacao(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8020", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    RelContratoVendaAlienacao relatorio = new RelContratoVendaAlienacao();
                    relatorio.SelectRow = grid1.GetDataRow();
                    relatorio.Conexao = grid1.Conexao;
                    DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(relatorio);
                    tool.ShowRibbonPreviewDialog();
                }
            }
        }

        public void ImprimirCompromissoCompraVendaPrazo(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8026", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    RelCompromissoCompraVendaPrazo relatorio = new RelCompromissoCompraVendaPrazo();
                    relatorio.SelectRow = grid1.GetDataRow();
                    relatorio.Conexao = grid1.Conexao;
                    DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(relatorio);
                    tool.ShowRibbonPreviewDialog();
                }
            }
        }

        public void ImprimirPedidoAcessorios(object sender, EventArgs e)
        {
            System.Data.DataRowCollection drc = grid1.GetDataRows();

            if (drc != null)
            {
                if (grid1.GetDataRows().Count > 1)
                {
                    MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RelPedidoAcessorios relatorio = new RelPedidoAcessorios();
                relatorio.SelectRow = grid1.GetDataRow();
                relatorio.Conexao = grid1.Conexao;
                DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(relatorio);
                tool.ShowRibbonPreviewDialog();
            }
        }

        public void ImprimirMovimento(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8019", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    RelPedidoDispan relatorio = new RelPedidoDispan();
                    relatorio.SelectRow = grid1.GetDataRow();
                    relatorio.Conexao = grid1.Conexao;

                    FormPrintPreview f = new FormPrintPreview();
                    f.SelectRow = grid1.GetDataRow();
                    f.Conexao = grid1.Conexao;
                    f.relatorio = relatorio;
                    f.ShowDialog();
                }
            }
        }

        private bool SendMessage(string Mensagem, string Anexo)
        {
            try
            {
                AppLib.Util.Email email = new AppLib.Util.Email();
                email.Host = EnderecoEmail;
                email.Porta = PortaEmail;
                email.Usuario = UsuarioEmail;
                email.Senha = SenhaEmail;
                email.UsaSSL = SSL;
                email.De = EnviarComo;
                email.DeDisplay = EnviarComoDisplay;
                email.Para = Enderecos;
                email.Assunto = Assunto;
                email.Mensagem = Mensagem;
                email.Html = true;
                email.Anexo = Anexo;

                bool enviou = email.Enviar();

                if (enviou)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Erro ao Enviar E-mail");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        public void ImprimirPedidoLiquido(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8041", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    RelPedidoLiquido relatorio = new RelPedidoLiquido();
                    relatorio.SelectRow = grid1.GetDataRow();
                    relatorio.Conexao = grid1.Conexao;

                    FormPrintPreview f = new FormPrintPreview();
                    f.SelectRow = grid1.GetDataRow();
                    f.Conexao = grid1.Conexao;
                    f.relatorio = relatorio;
                    f.ShowDialog();
                }
            }
        }

        public void ImprimirPedidoDesconto(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8042", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool verificaParcela = Convert.ToBoolean(AppLib.Context.poolConnection.Get().ExecGetField(0, "SELECT COUNT(IDMOV) FROM ZPARCELAS WHERE IDMOV = ? AND CODCOLIGADA = ?", new object[] { grid1.GetDataRow()["IDMOV"], AppLib.Context.Empresa }));
                    if (verificaParcela == false)
                    {
                        MessageBox.Show("Pedido: " + grid1.GetDataRow()["NUMEROMOV"].ToString() + " necessita gerar parcelas.", "Informação do Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    RelPedidoDesconto relatorio = new RelPedidoDesconto();
                    relatorio.SelectRow = grid1.GetDataRow();
                    relatorio.Conexao = grid1.Conexao;

                    FormPrintPreview f = new FormPrintPreview();
                    f.SelectRow = grid1.GetDataRow();
                    f.Conexao = grid1.Conexao;
                    f.relatorio = relatorio;
                    f.ShowDialog();
                }
            }
        }

        public void ImprimirPedidoAntigo(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8040", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataRow dr = grid1.GetDataRow();

                    if (dr["STATUS"].ToString() == "FATURADO")
                    {
                        RelPedidoAntigo relatorio = new RelPedidoAntigo();
                        relatorio.SelectRow = grid1.GetDataRow();
                        relatorio.Conexao = grid1.Conexao;

                        FormPrintPreview f = new FormPrintPreview();
                        f.SelectRow = grid1.GetDataRow();
                        f.Conexao = grid1.Conexao;
                        f.relatorio = relatorio;
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Apenas pedidos faturados podem sem impressos nesse modelo.", "Informação do Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void FaturarMovimento(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8021", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    string numeroMov = string.Empty;

                    for (int i = 0; i < grid1.GetDataRows().Count; i++)
                    {
                        if (i == 0)
                        {
                            numeroMov = drc[i]["NUMEROMOV"].ToString();
                        }
                        else
                        {
                            numeroMov = numeroMov + ", " + drc[i]["NUMEROMOV"].ToString();
                        }
                    }

                    FormFaturar f = new FormFaturar();
                    f.CodTmvOrigem = "2.1.10";
                    f.Movimentos = grid1.GetDataRows();
                    f.ShowDialog();
                    grid1.toolStripButtonATUALIZAR_Click(this, null);
                }
            }
        }

        public void CancelarMovimento(object sender, EventArgs e)
        {
            if (new AppLib.Security.Access().Processo(grid1.Conexao, "APP8022", AppLib.Context.Perfil))
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    FormCancelarMovimento f = new FormCancelarMovimento();
                    f.Movimentos = grid1.GetDataRows();
                    f.ShowDialog();
                    grid1.toolStripButtonATUALIZAR_Click(this, null);
                }
            }
        }

        public void Rastreabilidade(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataRowCollection drc = grid1.GetDataRows();

                if (drc != null)
                {
                    if (grid1.GetDataRows().Count > 1)
                    {
                        MessageBox.Show("Selecione apenas um movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    FormRastreabilidade f = new FormRastreabilidade();
                    f.Movimento = grid1.GetDataRow();
                    f.ShowDialog();
                }
            }
            catch
            { }
        }

        private void grid1_EventoClick(object sender, EventArgs e)
        {
            if (AnexoItemMovimento)
            {
                ItemMovimento(this, null);
            }

            if (AnexoMail)
            {
                MailMovimento(this, null);
            }

        }

        private void FormPedidoVisao_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void grid1_Load(object sender, EventArgs e)
        {

        }

        private void grid1_AposAtualizar(object sender, EventArgs e)
        {
            grid1.gridView1.Columns["NUMEROMOV"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            grid1.gridView1.RowStyle += gridView1_RowStyle;
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle >= 0)
            {
                if (splitContainer1.Panel2Collapsed == false)
                {
                    return;
                }

                string CodSerie = View.GetRowCellDisplayText(e.RowHandle, View.Columns["SERIE"]);

                if (CodSerie == "PVP" || CodSerie == "COT")
                {
                    string Aprovacao = View.GetRowCellDisplayText(e.RowHandle, View.Columns["APROVACAO"]);

                    if (Aprovacao == "VERIFICAR")
                    {
                        e.Appearance.BackColor = Color.PaleVioletRed;
                    }
                }
            }
        }

        private bool ExcluirComposicaoItem(string idMov)
        {
            bool excluiu = false;

            int result = AppLib.Context.poolConnection.Get("Start").ExecTransaction("DELETE FROM ZORCAMENTOITEMCOMPOSTO WHERE IDMOV = '" + idMov + "'");

            if (result > 0)
            {
                return true;
            }

            return excluiu;
        }

        private void OrdenaGridView()
        {
            grid1.gridView1.ClearSorting();
            grid1.gridView1.Columns["IDMOV"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }
    }
}
