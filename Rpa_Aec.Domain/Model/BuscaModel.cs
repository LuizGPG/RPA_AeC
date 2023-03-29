using System;
using System.Linq;

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

        private const string PublicadoPor = "Publicado por ";
        private const string Em = " em";

        public static string ExtraiAutor(string detalhes)
        {
            var autor = detalhes.Replace(PublicadoPor, string.Empty);
            return autor.Substring(0, autor.IndexOf(Em));
        }

        public static DateTime ExtraiDataPublicacao(string detalhes)
        {
            var arrayDosDetalhes = detalhes.Split(" ");
            var dataString = arrayDosDetalhes.Last();

            var dataValida = DateTime.TryParse(dataString, out var dataFormatada);

            return dataValida ? dataFormatada : DateTime.MinValue;
        }
    }
}
