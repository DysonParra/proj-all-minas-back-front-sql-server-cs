/*
 * @fileoverview    {Configuracion}
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
 * TODO: Description of {@code Configuracion}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Configuracion {

        [Key]
        public Int32? IntId { get; set; }
        public String? StrTipo { get; set; }
        public String? StrIndicador { get; set; }
        public String? StrBaudios { get; set; }
        public String? StrBitsDatos { get; set; }
        public String? StrBitsParada { get; set; }
        public String? StrParidad { get; set; }
        public String? StrIp { get; set; }
        public String? StrPuerto { get; set; }
        public String? StrUsuario { get; set; }
        public String? StrContrasena { get; set; }
        public Boolean? BitEstado { get; set; }

    }

}