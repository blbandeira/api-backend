using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace api_backend.Models
{
    public partial class Candidato
    {
        public Candidato() {
          //  this.Data_Cadastro = DateTime.Now;
        }

        public Candidato (int id, string nome, string email ,string File_Foto) {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Data_Cadastro = DateTime.Now;
            this.File_Foto = File_Foto;
            
        }

        
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? Data_Cadastro { get; set; }
        public string File_Foto { get; set; }

       
        public  ICollection<Vaga_Candidato> Vaga_Candidato { get; set; }
    }
}
