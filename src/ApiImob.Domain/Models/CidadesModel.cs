using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiImob.Domain.Models
{
    [Table("002_Cidades", Schema = "Imob")]
    public class CidadesModel : BaseModel
    {
        public string Nome { get; set; }
    }
}
