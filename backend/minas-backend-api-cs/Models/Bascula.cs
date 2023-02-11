/*
 * @fileoverview    {Bascula} se encarga de realizar tareas específicas.
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Bascula}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Bascula {

        [Key]
        public Int32? IntIdProveedor { get; set; }
        public String? StrRfid { get; set; }
        public int? IntCodigoPartida { get; set; }
        public int? IntNumeroMuestra { get; set; }
        public int? IntEstadoPartida { get; set; }
        public DateTime? DtFechaHoraEntrada { get; set; }
        public Single? FltPesoBruto { get; set; }
        public Single? FltPesoNeto { get; set; }
        public String? StrTipoVehiculo { get; set; }
        public String? StrMssCodigoPartida { get; set; }
        public DateTime? DtMssFechaHoraTomaMuestra { get; set; }

    }

}