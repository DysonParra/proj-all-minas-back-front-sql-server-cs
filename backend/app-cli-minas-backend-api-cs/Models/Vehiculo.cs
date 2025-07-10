/*
 * @overview        {Vehiculo}
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
     * TODO: Description of {@code Vehiculo}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Vehiculo {

        [Key]
        public String? StrRfid { get; set; }
        public String? StrPlaca { get; set; }
        public String? StrTransporte { get; set; }
        public DateTime? DtRevisionTecnomecanica { get; set; }
        public String? StrSeguro { get; set; }
        public int? IntTara { get; set; }
        public int? IntCapacidad { get; set; }
        public String? StrCategoria { get; set; }
        public String? StrIdMina { get; set; }
        public String? StrPatio { get; set; }
        public String? StrTope { get; set; }
        public String? StrIdConductor { get; set; }
        public String? StrCif { get; set; }

    }

}