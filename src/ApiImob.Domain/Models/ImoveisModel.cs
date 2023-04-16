using System.ComponentModel.DataAnnotations.Schema;

namespace ApiImob.Domain.Models
{
    [Table("004_Imoveis", Schema = "Imob")]
    public class ImoveisModel : BaseModel
    {
        public int TipoId { get; set; }

        public string Endereco { get; set; }

        public int BairroId { get; set; }

        public int CidadeId { get; set; }

        public string Cep { get; set; }

        public decimal Preco { get; set; }

        public decimal Area { get; set; }

        public Int16 Quartos { get; set; }

        public Int16 Banheiros { get; set; }

        public Int16 VagasGaragem { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public Boolean Disponivel { get; set; }
    }
}
