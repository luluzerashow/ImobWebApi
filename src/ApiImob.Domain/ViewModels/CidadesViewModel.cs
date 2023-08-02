using ApiImob.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.Domain.ViewModels
{
    public class CidadesViewModel : BaseModel
    {
        [DisplayName("Nome")]

        [Required(ErrorMessage = "O nome da cidade é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
    }
}
