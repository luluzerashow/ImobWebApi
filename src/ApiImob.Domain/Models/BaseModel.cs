using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ApiImob.Domain.Models
{
    public class BaseModel
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Data Criação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; }

        [DisplayName("Data Atualização")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAtualizacao { get; set; }
    }
}
