using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace netby.persistencia.Modelos;

[Table("Vehiculo")]
[Index("Placa", Name = "UQ__Vehiculo__0C057425340FB49C", IsUnique = true)]
public partial class Vehiculo
{
    [Key]
    [Column("secuencial")]
    public int Secuencial { get; set; }

    [Column("placa")]
    [StringLength(10)]
    [Unicode(false)]
    public string Placa { get; set; } = null!;

    [Column("detalle")]
    [StringLength(50)]
    [Unicode(false)]
    public string Detalle { get; set; } = null!;

    [Column("fechaRegistro")]
    public DateTime FechaRegistro { get; set; }

    [Column("fechaActualiza")]
    public DateTime? FechaActualiza { get; set; }

    [Column("activo")]
    public bool Activo { get; set; }

    [Column("usuarioRegistra")]
    [StringLength(10)]
    [Unicode(false)]
    public string UsuarioRegistra { get; set; } = null!;

    [Column("usuarioActualiza")]
    [StringLength(10)]
    [Unicode(false)]
    public string? UsuarioActualiza { get; set; }

    [InverseProperty("SecuencialVehiculoNavigation")]
    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();
}
