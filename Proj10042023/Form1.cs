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
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text
            };

            if (new AgendaController().Inserir(agenda))
            {
                MessageBox.Show("Registro inserido!");
                CarregarGrid();
            }
            else
                MessageBox.Show("Erro ao inserir registro!");
        }

        private void CarregarGrid()
        {
            dgvAgenda.DataSource = new AgendaController().TodosOsRegistros();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
