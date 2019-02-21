﻿namespace Nash.Domain.Responses
{
    using Nash.Domain.Models;
    using System.Collections.Generic;

    public class EstadisticasBcraResponse
    {
        public EstadisticasBcraResponse()
        {
            this.estadisticasBcras = new List<EstadisticasBcraModel>();
        }

        public IList<EstadisticasBcraModel> estadisticasBcras { get; set; }
    }
    
}
