using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpa_Aec.Domain.Entities
{
    public class Busca
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Area { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
