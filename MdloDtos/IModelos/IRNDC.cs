﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IRNDC
    {
        public Task<MdloDtos.RNDC.ConsultaManifiestoRespuesta> validarManifiesto(string idManifiesto, string nitEmpresaTransporte);
    }
}