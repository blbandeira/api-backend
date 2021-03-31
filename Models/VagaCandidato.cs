using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api_backend.Models
{
    public partial class Vaga_Candidato
    {   

        public Vaga_Candidato() {}

        public Vaga_Candidato (int id_vaga, int id_candidato) {
            this.Id_Vaga = id_vaga;
            this.Id_Candidato = Id_Candidato;
        }
        public int Id { get; set; }
        public int? Id_Vaga { get; set; }        
        

        public int? Id_Candidato { get; set; }

        public DateTime? Dt_Candidatura { get; set; }

        //[ForeignKey("Id_vaga")]
        public virtual Vaga Vaga {get; set;}

        //[ForeignKey("id_candidato")]
        
        public virtual Candidato Candidato {get; set;}

    }
}
