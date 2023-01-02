using CadastroUsuario.Models;
using CadastroUsuario.Services;
using System;
using System.Windows.Forms;

namespace CadastroUsuario
{
    public partial class FrmCadUsuario : Form
    {
        UsuarioModel usuarioModel = new UsuarioModel();
        UsuarioService usuarioService = new UsuarioService();

        public FrmCadUsuario()
        {
            InitializeComponent();            
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", "Mensagem do Sistema", MessageBoxButtons.YesNo, 
                                                                       MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.LimpaCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtendereco.Text) 
                && !String.IsNullOrEmpty(txtCelular.Text) && !String.IsNullOrEmpty(mtxtDtNasc.Text))
            {
                usuarioModel.Nome = txtNome.Text;
                usuarioModel.Endereco = txtendereco.Text;
                usuarioModel.Email = txtEmail.Text;
                usuarioModel.TeleFoneFixo = txtTelFixo.Text;
                usuarioModel.Celular = txtCelular.Text;
                usuarioModel.DataNascimento = Convert.ToDateTime(mtxtDtNasc.Text).ToString("yyyy-MM-dd HH:mm:ss");

                var usuarioReturn = usuarioService.CadastraUsuario(usuarioModel);

                MessageBox.Show("Cadastrado com sucesso", "Mensagem do Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else            
                MessageBox.Show("Não há dados suficiente para cadastro", "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdUsuario.Text) || !String.IsNullOrEmpty(txtEmail.Text))
            {
                var result = usuarioService.PesquisaUsuario(int.Parse(txtIdUsuario.Text));                
                if (result != null) 
                {
                    txtIdUsuario.Text = result.idusuario.ToString();
                    txtNome.Text = result.nome;
                    txtEmail.Text = result.email;
                    txtendereco.Text = result.endereco;
                    txtTelFixo.Text = result.telefonefixo.ToString();
                    txtCelular.Text = result.celular.ToString();
                    mtxtDtNasc.Text = result.datanascimento.ToString();                 
                }
                else
                    MessageBox.Show($"Id Usuario {txtIdUsuario.Text} não encontrado", "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            else            
                MessageBox.Show("Não há dados para pesquisa", "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdUsuario.Text))                
            {   
                if (MessageBox.Show($"Deseja excluir o usuário {txtIdUsuario.Text}?", "Mensagem do Sistema", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var result = usuarioService.DeleteUsuario(int.Parse(txtIdUsuario.Text));
                    if (result == true)
                    {
                        MessageBox.Show($" Id Usuário {txtIdUsuario.Text} excluído com Sucesso", "Atenção!",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.LimpaCampos();

                    }
                    else
                        MessageBox.Show($" Id Usuário {txtIdUsuario.Text} inexistente", "Atenção!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Não há dados para Exclusão", "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtendereco.Text)
                && !String.IsNullOrEmpty(txtCelular.Text) && !String.IsNullOrEmpty(mtxtDtNasc.Text))
            {
                usuarioModel.IdUsuario = int.Parse(txtIdUsuario.Text);
                usuarioModel.Nome = txtNome.Text;
                usuarioModel.Endereco = txtendereco.Text;
                usuarioModel.Email = txtEmail.Text;
                usuarioModel.TeleFoneFixo = txtTelFixo.Text;
                usuarioModel.Celular = txtCelular.Text;
                usuarioModel.DataNascimento = Convert.ToDateTime(mtxtDtNasc.Text).ToString("yyyy-MM-dd HH:mm:ss");

                var result = usuarioService.UpdateUsuario(usuarioModel);

                MessageBox.Show("Cadastro alterado com sucesso!", "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não há dados para alteração do cadastro", "Atenção!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public void LimpaCampos()
        {
            txtIdUsuario.Clear();
            txtNome.Clear();
            txtendereco.Clear();
            txtEmail.Clear();            
            txtTelFixo.Clear();
            txtCelular.Clear();
            mtxtDtNasc.Clear();
        }
    }
}
