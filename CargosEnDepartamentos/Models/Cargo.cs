using System;
using System.Collections.Generic;

namespace CargosEnDepartamentos.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string NombreCargo { get; set; } = null!;

    public bool Estado { get; set; }

    public int IdDepartamento { get; set; }

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
