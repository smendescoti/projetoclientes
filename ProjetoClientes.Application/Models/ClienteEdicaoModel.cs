using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Application.Models
{
    /// <summary>
    /// Modelo de dados para a ação de edição de cliente.
    /// </summary>
    public class ClienteEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]
        public Guid IdCliente { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string Email { get; set; }

        [MinLength(11, ErrorMessage = "Por favor, informe {1} caracteres.")]
        [MaxLength(11, ErrorMessage = "Por favor, informe {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string Cpf { get; set; }

        [MinLength(9, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(15, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o telefone do cliente.")]
        public string Telefone { get; set; }
    }
}
