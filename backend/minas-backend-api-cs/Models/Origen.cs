/*
 * @fileoverview    {Origen}
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
 * TODO: Definición de {@code Origen}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Origen {

        [Key]
        public String? StrIdOrigen { get; set; }
        public String? StrNombre { get; set; }
        public String? StrCodigoRfid { get; set; }
        public String? StrDireccion { get; set; }
        public String? StrObservaciones { get; set; }

    }

}