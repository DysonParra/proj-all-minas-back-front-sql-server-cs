/*
 * @fileoverview    {Sancion}
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
 * TODO: Definición de {@code Sancion}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Sancion {

        [Key]
        public Int32? IntNumero { get; set; }
        public String? StrItem { get; set; }
        public Boolean? BitSancionConductor { get; set; }
        public Boolean? BitSancionVehiculo { get; set; }
        public String? StrTiempo { get; set; }

    }

}