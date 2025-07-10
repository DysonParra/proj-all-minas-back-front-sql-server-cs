/*
 * @overview        {Categoria}
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
     * TODO: Description of {@code Categoria}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Categoria {

        [Key]
        public Int32? IntIdCategoria { get; set; }
        public String? StrTipoVehiculo { get; set; }
        public Single? FltPesoMaximo { get; set; }
        public Single? FltTolerancia { get; set; }
        public String? StrDescripcion { get; set; }
        public Single? FltEjeSencillo { get; set; }
        public Single? FltEjeTandem { get; set; }
        public Single? FltEjeTridem { get; set; }
        public Int32? IntTotalEjes { get; set; }

    }

}