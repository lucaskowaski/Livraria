using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Livraria.Application.ViewModels
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Título é obrigatório")]
        [MinLength(3, ErrorMessage = "O Título de ter no minimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O Título de ter no máximo 100 caracteres")]
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Autor é obrigatório")]
        [MinLength(3, ErrorMessage = "O Autor de ter no minimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O Autor de ter no máximo 100 caracteres")]
        [DisplayName("Autor")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O Idioma é obrigatório")]
        [MinLength(3, ErrorMessage = "O Idioma de ter no minimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O Idioma de ter no máximo 100 caracteres")]
        [DisplayName("Idioma")]
        public string Idioma { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "O Ano de Publicação requer um ano válido")]
        [DisplayName("Ano de Publicação")]
        public int AnoPublicacao { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "O Numero de Páginas requer um numero válido")]
        [DisplayName("Numero de Páginas")]
        public int NumeroPaginas { get; set; }
    }
}
