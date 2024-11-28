using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos
{
    public class RetornoSubdeposito
    {
        public RetornoSubdeposito() { }

        [Key]
        public int Retorno { get; set; }

    }
}
