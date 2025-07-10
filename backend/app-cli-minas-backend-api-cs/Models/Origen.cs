/*
 * @overview        {Origen}
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
     * TODO: Description of {@code Origen}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Origen {

        [Key]
        public String? StrIdOrigen { get; set; }
        public String? StrNombre { get; set; }
        public String? StrCodigoRfid { get; set; }
        public String? StrDireccion { get; set; }
        public String? StrObservaciones { get; set; }

    }

}