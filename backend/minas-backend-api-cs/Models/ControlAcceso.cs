/*
 * @fileoverview    {ControlAcceso}
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
 * TODO: Definición de {@code ControlAcceso}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class ControlAcceso {

        [Key]
        public Int32? IntIdControl { get; set; }
        public String? StrIdDestino { get; set; }
        public String? StrPlaca { get; set; }
        public String? StrConductor { get; set; }
        public DateTime? DtFechaIngreso { get; set; }
        public DateTime? DtFechaSalida { get; set; }
        public Int32? IntTopeMensual { get; set; }
        public Int32? IntAcumulado { get; set; }
        public DateTime? DtFechaValidez { get; set; }
        public String? StrTipoTarjeta { get; set; }
        public Int32? IntIdContrato { get; set; }
        public String? StrIdMina { get; set; }
        public String? StrCifProveedor { get; set; }
        public String? StrRfid { get; set; }

    }

}