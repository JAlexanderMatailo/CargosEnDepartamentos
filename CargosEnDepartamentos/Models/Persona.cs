using System;
using System.Collections.Generic;

namespace CargosEnDepartamentos.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string NombrePersona { get; set; } = null!;

    public string ApellidoPersona { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public bool? Estado { get; set; }

    public int IdCargo { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;
}
