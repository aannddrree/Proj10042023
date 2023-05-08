using Proj10042023.Controller;
using Proj10042023.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj10042023
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda()
            {
                Id = int.Parse(this.lblIdValor.Text),
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text
            };

            if (ValidarDados(agenda))
            {
                if (agenda.Id == 0)
                {
                    Inserir(agenda);
                }
                else
                {
                    Atualizar(agenda);
                }
            }
            else
            {
                MessageBox.Show("Os campos Nome e Telefone são obrigatórios");
            }
        }

        private bool ValidarDados(Agenda agenda)
        {
            if (string.IsNullOrEmpty(agenda.Nome) || string.IsNullOrEmpty(agenda.Telefone)) 
                return false;
            return true;
        }

        private void Inserir(Agenda agenda)
        {
            if (new AgendaController().Inserir(agenda))
            {
                MessageBox.Show("Registro inserido!");
                CarregarGrid();
                ClearForm();
            }
            else
                MessageBox.Show("Erro ao inserir registro!");
        }

        private void Atualizar(Agenda agenda)
        {
            if (new AgendaController().Atualizar(agenda))
            {
                MessageBox.Show("Registro atualizado!");
                CarregarGrid();
                ClearForm();
            }
            else
                MessageBox.Show("Erro ao atualizar registro!");
        }

        private void Deletar(int id)
        {
            if (new AgendaController().Deletar(id))
            {
                MessageBox.Show("Registro Deletado!");
                CarregarGrid();
                ClearForm();
            }
            else
                MessageBox.Show("Erro ao deletar registro!");
        }

        private void ClearForm()
        {
            this.txtNome.Clear();
            this.lblIdValor.Text = "0";
            this.txtTelefone.Clear();
            txtNome.Focus();
        }

        private void CarregarGrid()
        {
            dgvAgenda.DataSource = new AgendaController().TodosOsRegistros();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = (dgvAgenda.CurrentCell.RowIndex);
            lblIdValor.Text = dgvAgenda.Rows[rowIndex].Cells[0].Value.ToString();
            txtNome.Text = dgvAgenda.Rows[rowIndex].Cells[1].Value.ToString();
            txtTelefone.Text = dgvAgenda.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdValor.Text);

            if (id == 0) 
                MessageBox.Show("Por favor, seleciona primeiro um registro!");
            else
                this.Deletar(id);
        }
    }
}
