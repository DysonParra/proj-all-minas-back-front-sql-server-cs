/*
 * @fileoverview    {Bascula}
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
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Description of {@code Bascula}.
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