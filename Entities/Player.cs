using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("players")]
public class Player : DbEntity
{
    [Column("name")]
    [StringLength(64)]
    [Required]
    public String? Name { get; set; }

    [Column("email")]
    [StringLength(64)]
    [Required]
    public String? Email { get; set; }

    [Column("birthdate")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime BirthDate { get; set; }

    [Column("sex")]
    [StringLength(64)]
    [Required]
    public String? Sex { get; set; }

    [Column("country")]
    [StringLength(64)]
    [Required]
    public String? Country { get; set; }

    [Column("herotype")]
    [StringLength(64)]
    [Required]
    public String? HeroType { get; set; }

    [Column("experience")]
    [Required]
    public int? Experience { get; set; }

}
