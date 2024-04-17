using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System;
using System.Collections.Generic;

namespace caresoft_integration.Models;

public partial class Aseguradora
{
    public uint IdAseguradora { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Autorizacion> Autorizacions { get; set; } = new List<Autorizacion>();

    public static Aseguradora FromCoreApi(caresoft_integration.CoreAPI.Aseguradora aseguradora)
    {
        return new Aseguradora
        {
            IdAseguradora = (uint)aseguradora.IdAseguradora,
            Nombre = aseguradora.Nombre,
            Direccion = aseguradora.Direccion,
            Telefono = aseguradora.Telefono,
            Correo = aseguradora.Correo,
            Autorizacions = aseguradora.Autorizacions.Select(e => Autorizacion.FromCoreApi(e)).ToList()
        };
    }
    public static caresoft_integration.CoreAPI.Aseguradora ToCoreApi(Aseguradora aseguradora)
    {
        return new()
        {
            IdAseguradora = (int)aseguradora.IdAseguradora,
            Nombre = aseguradora.Nombre,
            Direccion = aseguradora.Direccion,
            Telefono = aseguradora.Telefono,
            Correo = aseguradora.Correo,
            Autorizacions = aseguradora.Autorizacions.Select(e => Autorizacion.ToCoreApi(e)).ToList()
        };
    }
}
