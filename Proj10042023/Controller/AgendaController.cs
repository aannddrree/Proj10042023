using Proj10042023.Model;
using Proj10042023.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj10042023.Controller
{
    class AgendaController
    {
        public bool Inserir(Agenda agenda)
        {
            return new AgendaService().Inserir(agenda);
        }

        public List<Agenda> TodosOsRegistros()
        {
            return new AgendaService().TodosOsRegistros();
        }
    }
}
