//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evento
{
    using System;
    using System.Collections.Generic;
    
    public partial class GrauAcademico
    {
        public GrauAcademico()
        {
            this.Participantes = new HashSet<Participante>();
        }
    
        public int id { get; set; }
        public string descricao { get; set; }
    
        public virtual ICollection<Participante> Participantes { get; set; }
    }
}
