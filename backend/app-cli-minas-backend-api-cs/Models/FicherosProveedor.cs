/*
 * @fileoverview    {FicherosProveedor}
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
     * TODO: Description of {@code FicherosProveedor}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class FicherosProveedor {

        [Key]
        public String? StrCif { get; set; }
        public String? StrNombre { get; set; }
        public Int32? IntTopeMensual { get; set; }
        public DateTime? DtFechaHoraCarga { get; set; }
        public String? StrIdUsuario { get; set; }

    }

}