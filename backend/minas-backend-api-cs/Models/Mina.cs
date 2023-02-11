/*
 * @fileoverview    {Mina} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Mina}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

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