/*
 * @fileoverview    {MinasContext}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Minas.Data {

    /**
     * TODO: Description of {@code MinasContext}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MinasContext : DbContext {
        public MinasContext (DbContextOptions<MinasContext> options)
            : base(options) {
        }

        public DbSet<Project.Models.Bascula> Bascula { get; set; } = default!;

        public DbSet<Project.Models.Categoria> Categoria { get; set; }

        public DbSet<Project.Models.CierrePartida> CierrePartida { get; set; }

        public DbSet<Project.Models.CodigoOrigen> CodigoOrigen { get; set; }

        public DbSet<Project.Models.Conductor> Conductor { get; set; }

        public DbSet<Project.Models.Configuracion> Configuracion { get; set; }

        public DbSet<Project.Models.ConsecutivoDiario> ConsecutivoDiario { get; set; }

        public DbSet<Project.Models.Contrato> Contrato { get; set; }

        public DbSet<Project.Models.ControlAcceso> ControlAcceso { get; set; }

        public DbSet<Project.Models.Destino> Destino { get; set; }

        public DbSet<Project.Models.FicherosProveedor> FicherosProveedor { get; set; }

        public DbSet<Project.Models.GeneradorPartida> GeneradorPartida { get; set; }

        public DbSet<Project.Models.Indicador> Indicador { get; set; }

        public DbSet<Project.Models.Mina> Mina { get; set; }

        public DbSet<Project.Models.Muestra> Muestra { get; set; }

        public DbSet<Project.Models.Origen> Origen { get; set; }

        public DbSet<Project.Models.Parque> Parque { get; set; }

        public DbSet<Project.Models.Producto> Producto { get; set; }

        public DbSet<Project.Models.Proveedor> Proveedor { get; set; }

        public DbSet<Project.Models.RegistroEntradaSalida> RegistroEntradaSalida { get; set; }

        public DbSet<Project.Models.Sancion> Sancion { get; set; }

        public DbSet<Project.Models.Temporal> Temporal { get; set; }

        public DbSet<Project.Models.TituloMinero> TituloMinero { get; set; }

        public DbSet<Project.Models.Usuario> Usuario { get; set; }

        public DbSet<Project.Models.Vehiculo> Vehiculo { get; set; }

        public DbSet<Project.Models.VehiculoEnTransito> VehiculoEnTransito { get; set; }
    }
}
