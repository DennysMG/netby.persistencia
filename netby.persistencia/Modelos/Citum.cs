using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace netby.persistencia.Modelos;

public partial class Citum
{
    [Key]
    [Column("secuencial")]
    public int Secuencial { get; set; }

    [Column("fechaCita")]
    public DateTime FechaCita { get; set; }

    [Column("descripcion")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("secuencialVehiculo")]
    public int SecuencialVehiculo { get; set; }

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

    [ForeignKey("SecuencialVehiculo")]
    [InverseProperty("Cita")]
    public virtual Vehiculo SecuencialVehiculoNavigation { get; set; } = null!;
}
