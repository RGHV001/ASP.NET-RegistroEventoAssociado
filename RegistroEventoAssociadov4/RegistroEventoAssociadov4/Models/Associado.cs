using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class Associado
    {
        [Key]
        public int Id { get; set; } // Chave primária para identificar o associado.

        [Required(ErrorMessage = "O nome do titular é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string NomeTitular { get; set; } = string.Empty; // Nome completo do associado.

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(150, ErrorMessage = "O endereço não pode exceder 150 caracteres.")]
        public string Endereco { get; set; } = string.Empty; // Endereço residencial do associado.

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O bairro não pode exceder 100 caracteres.")]
        public string Bairro { get; set; } = string.Empty; // Bairro onde o associado reside.

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(10, ErrorMessage = "O CEP não pode exceder 10 caracteres.")]
        public string Cep { get; set; } = string.Empty; // CEP do endereço do associado.

        [StringLength(100, ErrorMessage = "O complemento não pode exceder 100 caracteres.")]
        public string Complemento { get; set; } = string.Empty; // Complemento do endereço (opcional).

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100, ErrorMessage = "A cidade não pode exceder 100 caracteres.")]
        public string Cidade { get; set; } = string.Empty; // Cidade onde o associado reside.

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "O estado deve ser representado por 2 caracteres.")]
        public string UF { get; set; } = string.Empty; // Estado onde o associado reside (sigla de 2 letras).

        [StringLength(15, ErrorMessage = "O telefone não pode exceder 15 caracteres.")]
        public string Telefone { get; set; } = string.Empty; // Telefone fixo do associado (opcional).

        [Required(ErrorMessage = "O número de celular é obrigatório.")]
        [StringLength(15, ErrorMessage = "O celular não pode exceder 15 caracteres.")]
        public string Celular { get; set; } = string.Empty; // Número de celular do associado.

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode exceder 100 caracteres.")]
        public string Email { get; set; } = string.Empty; // E-mail de contato do associado.

        [StringLength(100, ErrorMessage = "O link do Facebook não pode exceder 100 caracteres.")]
        public string Facebook { get; set; } = string.Empty; // Link para o perfil do Facebook (opcional).

        [StringLength(100, ErrorMessage = "O link do Instagram não pode exceder 100 caracteres.")]
        public string Instagram { get; set; } = string.Empty; // Link para o perfil do Instagram (opcional).

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string CPF { get; set; } = string.Empty; // CPF do associado.

        [StringLength(20, ErrorMessage = "O RG deve ter no máximo 20 caracteres.")]
        public string RegistroGeral { get; set; } = string.Empty; // Registro Geral (RG) do associado (opcional).

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; } // Data de nascimento do associado.

        [Required(ErrorMessage = "O tipo de associação é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo de associação não pode exceder 50 caracteres.")]
        public string TipoDeAssociacao { get; set; } = string.Empty; // Tipo de associação (ex.: titular, honorário, etc.).
    }
}
