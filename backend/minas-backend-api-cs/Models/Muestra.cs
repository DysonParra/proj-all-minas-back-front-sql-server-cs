/*
 * @fileoverview    {Muestra}
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
 * TODO: Definición de {@code Muestra}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Muestra {

        [Key]
        public Int32? IntIdMuestra { get; set; }
        public String? StrPartida { get; set; }
        public String? StrCamion { get; set; }
        public DateTime? DtFechaHora { get; set; }
        public String? StrObservaciones { get; set; }
        public String? StrRfid { get; set; }

    }

}