/*
 * @fileoverview    {Conductor}
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
 * TODO: Description of {@code Conductor}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Conductor {

        [Key]
        public String? StrIdentificacion { get; set; }
        public String? StrNombreConductor { get; set; }
        public DateTime? DtFechaNacimiento { get; set; }
        public String? StrLicenciaConduccion { get; set; }
        public DateTime? DtFechaVencimiento { get; set; }
        public String? StrObservaciones { get; set; }
        public String? StrTipoSancion { get; set; }
        public DateTime? DtFechaInicioSancion { get; set; }
        public DateTime? DtFechaFinalSancion { get; set; }
        public String? StrDiasSancion { get; set; }

    }

}