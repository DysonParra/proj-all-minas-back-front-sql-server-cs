/*
 * @overview        {Proveedor}
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
     * TODO: Description of {@code Proveedor}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Proveedor {

        [Key]
        public String? StrCif { get; set; }
        public String? StrNombre { get; set; }
        public String? StrDireccion { get; set; }
        public String? StrPais { get; set; }
        public String? StrPoblacion { get; set; }
        public String? StrCodigoProveedor { get; set; }
        public String? StrCorreoElectronico { get; set; }
        public String? StrPatio { get; set; }
        public Int32? IntTopeMensual { get; set; }
        public Int32? IntAcumulado { get; set; }
        public String? StrObservaciones { get; set; }
        public Int32? IntTopeOpcional { get; set; }
        public Int32? IntTopeAdicional { get; set; }
        public Int32? IntTopeSpot { get; set; }
        public Int32? IntTopeOtros { get; set; }

    }

}