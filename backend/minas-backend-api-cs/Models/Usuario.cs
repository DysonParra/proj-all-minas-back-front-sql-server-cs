/*
 * @fileoverview    {Usuario} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Usuario}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Usuario {

        [Key]
        public Int32? IntCedula { get; set; }
        public String? StrNombre { get; set; }
        public String? StrApellido { get; set; }
        public String? StrEmail { get; set; }
        public String? StrTelefono { get; set; }
        public String? CrRh { get; set; }
        public String? StrSeudonimo { get; set; }
        public String? StrTipo { get; set; }
        public String? StrCargo { get; set; }
        public String? TxtContrasena { get; set; }
        private byte[] btFoto;

    }

}