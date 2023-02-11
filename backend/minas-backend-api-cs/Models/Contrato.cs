/*
 * @fileoverview    {Contrato} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Contrato}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Contrato {

        [Key]
        public Int32? IntIdContrato { get; set; }
        public String? StrIdParque { get; set; }
        public String? StrCentroProduccion { get; set; }
        public String? StrCarburante { get; set; }
        public String? StrTipoAgrupacion { get; set; }
        public Boolean? BitPartidaMaestra { get; set; }
        public int? IntTipoExistencia { get; set; }
        public String? StrDescripcion { get; set; }

    }

}