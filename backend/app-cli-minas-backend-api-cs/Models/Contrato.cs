/*
 * @fileoverview    {Contrato}
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

namespace Project.Models {

    /**
     * TODO: Description of {@code Contrato}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
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