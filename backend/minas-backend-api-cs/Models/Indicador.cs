/*
 * @fileoverview    {Indicador}
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

/**
 * TODO: Definición de {@code Indicador}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Indicador {

        [Key]
        public String? StrCodigo { get; set; }
        public String? StrNombre { get; set; }
        public String? StrTamanoTrama { get; set; }
        public String? StrPosicionInicial { get; set; }
        public String? StrTotalDatosPeso { get; set; }
        public String? StrCaracterFinTrama { get; set; }
        public String? StrCaracterInicioTrama { get; set; }

    }

}