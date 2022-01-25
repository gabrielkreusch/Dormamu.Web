using System;
using System.Collections.Generic;

namespace Dormamu.Web.Models
{
    public class Cliente
    {
        public long ID { get; set; }
        public Pessoa Pessoa { get; set; }
        public long PessoaID { get; set; }
        
        //public string Observacao { get; set; }
        //public List<Endereco> Enderecos { get; set; }
        //public long EnderecosEntregaID { get; set; }
        //public DateTime PrimeiraCompraEm { get; set; }
        //public DateTime UltimaCompraEm { get; set; }
    }
}