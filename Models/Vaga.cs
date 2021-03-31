using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api_backend.Models
{
    public partial class Vaga
    {
        public Vaga()
        {
         //   this.Ativa = true;
        }

        
        public int Id { get; set; }
        public string Nome_Vaga { get; set; }
        public string Cargo { get; set; }
        public string Desc_Vaga { get; set; }
        public bool? Ativa { get; set; }

       
        public virtual ICollection<Vaga_Candidato> Vaga_Candidato { get; set; }
    }
}
