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
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Description of {@code Muestra}.
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