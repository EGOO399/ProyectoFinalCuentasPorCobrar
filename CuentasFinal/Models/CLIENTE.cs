//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuentasFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            this.CREDITOes = new HashSet<CREDITO>();
            this.FACTURAs = new HashSet<FACTURA>();
        }
    
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Telefono { get; set; }
        public Nullable<int> Nit { get; set; }
        public Nullable<int> IdTipoCliente { get; set; }
    
        public virtual TIPOCLIENTE TIPOCLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CREDITO> CREDITOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURAs { get; set; }
    }
}
