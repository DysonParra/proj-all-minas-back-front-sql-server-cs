/*
 * @fileoverview    {Mina}
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
     * TODO: Description of {@code Mina}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Mina {

        [Key]
        public String? StrIdMina { get; set; }
        public String? StrNombre { get; set; }
        public String? StrLocalidad { get; set; }
        public String? StrTelefono { get; set; }
        public String? StrObservaciones { get; set; }
        public String? StrProducto { get; set; }
        public String? StrTicket { get; set; }
        public String? StrIdTituloMinero { get; set; }

    }

}