using System;
using System.ComponentModel.DataAnnotations;

namespace AR.Domain
{
    public class Cliente
    {
        /// <summary>
        /// Identificador do cliente
        /// <example> 7 </example>
        /// </summary>
        [Key]
        public  int Id { get; set; }


        /// <summary>
        /// Nome do cliente
        /// <example> Matheus </example>
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50 , ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string nome { get; set; }


        /// <summary>
        /// Cpf do cliente | Não colocar pontuação
        /// <example> 00000000000 </example>
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(11)]
        public string cpf { get; set; }

        /// <summary>
        /// Data de nascimento do cliente
        /// <example> 2022-05-02 </example>
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime data_nascimento { get; set; }


        /// <summary>
        /// Email do cliente
        /// <example> exemplo@exemplo.com </example>
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string email { get; set; }

        /// <summary>
        /// Sexo do cliente | F - Feminino, M - Masculino, O - Outro
        /// <example> F </example>
        /// <example> M </example>
        /// <example> O </example>
        /// </summary>
        [MaxLength(1)]
        public string sexo { get; set; }

        /// <summary>
        /// Situação do cliente | S - Ativo, N - Desativado
        /// <example> S </example>
        /// <example> N </example>
        /// </summary>
        [MaxLength(1)]
        public string ativo { get; set; }

    }
}
