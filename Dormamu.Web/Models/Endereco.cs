namespace Dormamu.Web.Models
{
    public class Endereco
    {
        public long ID { get; set; }
        public long ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string Pais { get; set; }
        public string UF { get; set; }
        public int Numero { get; set; }
        public Logradouro Logradouro { get; set; }
        public TipoEndereco Tipo { get; set; }
    }
}