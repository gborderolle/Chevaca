//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chevaca.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ovejas
    {
        public int Oveja_ID { get; set; }
        public string Nombre { get; set; }
        public int Estancia_ID { get; set; }
        public Nullable<int> Lista_animales_razas_ID { get; set; }
        public Nullable<int> Lista_animales_categorias_ID { get; set; }
    }
}
