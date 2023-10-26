/*
 * @fileoverview    {Producto}
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
 * TODO: Definición de {@code Producto}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Producto {

        [Key]
        public Int32? IntIdProducto { get; set; }
        public String? StrProducto { get; set; }

    }

}