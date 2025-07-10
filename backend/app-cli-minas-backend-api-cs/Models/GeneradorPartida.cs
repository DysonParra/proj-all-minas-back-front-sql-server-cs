/*
 * @overview        {GeneradorPartida}
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
     * TODO: Description of {@code GeneradorPartida}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
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