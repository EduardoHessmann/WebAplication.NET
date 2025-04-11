using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Modelos
{
    public class Cliente
    {
        /// <summary>
        /// Representa o identificador da entidade.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string? NomeMae { get; set; }

        public bool MenorDeIdade { get; set; }

        public List<Endereco> enderecos { get; set; } = [];

    }
}
