//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transporte
    {
        public int IdTransporte { get; set; }
        public string NumeroPlaca { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public System.DateTime AnioFabricacion { get; set; }
        public int IdEstatusTransporte { get; set; }
        public Nullable<int> IdRepartidor { get; set; }
    
        public virtual EstatusTransporte EstatusTransporte { get; set; }
        public virtual Repartidor Repartidor { get; set; }
    }
}
