/*
 * @fileoverview    {Temporal} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Temporal}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Temporal {

        [Key]
        public Int32? IntIdTemporal { get; set; }
        public String? StrPlaca { get; set; }
        public String? StrRfid { get; set; }
        public String? StrProveedor { get; set; }
        public String? StrTope { get; set; }
        public Int32? IntAcumulado { get; set; }
        public DateTime? DtFechaEntrada { get; set; }
        public DateTime? DtFechaSalida { get; set; }
        public String? StrEstado { get; set; }

    }

}