using System;

namespace Rpa_Aec.Domain.Model
{
    public class BuscaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Area { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
