/*
 * @fileoverview    {Parque}
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
     * TODO: Description of {@code Parque}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Parque {

        [Key]
        public Int32? IntIdParque { get; set; }
        public String? StrNombreParque { get; set; }
        public String? StrObservaciones { get; set; }
        public String? StrUbicacion { get; set; }

    }

}