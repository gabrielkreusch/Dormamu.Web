using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Models
{
    public class Produto
    {
        public long ID { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        public string DescricaoBreve { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string DescricaoCompleta { get; set; }

        public int Estoque { get; set; }
        public double Valor { get; set; }
        //public List<FotoProduto> FotosProduto { get; set; }
    }
}
