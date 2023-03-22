/*
 * @fileoverview    {Categoria}
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
 * TODO: Definición de {@code Categoria}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

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