﻿using Proj10042023.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj10042023.Service
{
    class AgendaService
    {
        //Implementar a conexao
        string strCon = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\bancoAula\dbAgendaTurma.mdf;";
        SqlConnection conn;

        public AgendaService()
        {
            //Abertua da conexao
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        public bool Inserir(Agenda agenda)
        {
            //Implementar
            string strInsert = "insert into Agenda (Nome, Telefone) values (@Nome, @Telefone)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", agenda.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@Telefone", agenda.Telefone));

            commandInsert.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public bool Atualizar(Agenda agenda)
        {
            //Implementar
            string strInsert = "update Agenda set Nome = @Nome, Telefone = @Telefone where id = @Id";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Id", agenda.Id));
            commandInsert.Parameters.Add(new SqlParameter("@Nome", agenda.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@Telefone", agenda.Telefone));

            commandInsert.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public bool Deletar(int id)
        {
            string strInsert = "delete from Agenda where id = @Id";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Id", id));

            commandInsert.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public List<Agenda> TodosOsRegistros()
        {
            List<Agenda> agendas = new List<Agenda>();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, ");
            sb.Append("       Nome, ");
            sb.Append("       Telefone ");
            sb.Append("  FROM Agenda");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Agenda agenda = new Agenda();

                agenda.Id = Convert.ToInt32(dr["Id"]);
                agenda.Nome = dr["Nome"].ToString();
                agenda.Telefone = dr["Telefone"].ToString();
                agendas.Add(agenda);
            }
            return agendas;
        }

        public Agenda ConsultarPorId(int id)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, ");
            sb.Append("       Nome, ");
            sb.Append("       Telefone ");
            sb.Append("  FROM Agenda");
            sb.Append("  WHERE id = @Id");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            commandSelect.Parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader dr = commandSelect.ExecuteReader();

            Agenda agenda = new Agenda();

            if (dr.Read())
            {
                agenda.Id = Convert.ToInt32(dr["Id"]);
                agenda.Nome = dr["Nome"].ToString();
                agenda.Telefone = dr["Telefone"].ToString();
            }
            return agenda;
        }
    }
}
