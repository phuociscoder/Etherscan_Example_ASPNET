using System.ComponentModel.DataAnnotations;

namespace Etherscan.Model.Dto
{
    public class TokenDto
    {

        [Required]
        public int Id { get; set; }
        [Required, MaxLength(5)]
        public string Symbol { get; set; }
        [Required]
        [MaxLength(55)]
        public string Name { get; set; }
        [Required]
        public int Total_Supply { get; set; }
        [Required]
        public string Contract_Address { get; set; }
        [Required]
        public int Total_Holders { get; set; }
    }
}
