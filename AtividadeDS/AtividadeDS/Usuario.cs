using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AtividadeDS
{
    class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
        [MinLength(3, ErrorMessage = "O Nome deve conter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Cargo' é obrigatório!")]
        [MinLength(3, ErrorMessage = "O Cargo deve conter no mínimo 3 caracteres")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O campo 'Data' é obrigatório!")]
        public DateTime  DataNasc{get;set;}
    }
}
