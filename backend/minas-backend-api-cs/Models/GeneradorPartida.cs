/*
 * @fileoverview    {GeneradorPartida} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code GeneradorPartida}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class GeneradorPartida {

        [Key]
        public Int32? IntConsecutivo { get; set; }
        public Int32? IntCodigoPartida { get; set; }
        public Int32? IntCodigoVehiculo { get; set; }
        public Int32? IntPeso { get; set; }
        public DateTime? DtFecha { get; set; }
        public String? StrEstado { get; set; }
        public Int32? IntPesoEstimado { get; set; }
        public String? StrTipo { get; set; }
        public String? StrCifProveedor { get; set; }
        public String? StrRfid { get; set; }

    }

}