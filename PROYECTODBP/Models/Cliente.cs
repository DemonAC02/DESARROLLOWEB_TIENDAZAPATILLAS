using PROYECTODBP.Servicio;
using System;
using System.Collections.Generic;

namespace PROYECTODBP.Models;

public partial class Cliente
{
    ZapatillasC conexion = new ZapatillasC();   
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
    public int getIdCliente()
    {

        int idCli = (from tbCli in conexion.Clientes
                     where tbCli.Correo == Correo
                     && tbCli.Clave == Clave
                     select tbCli.IdCliente).FirstOrDefault();
        return idCli;
    }
}
