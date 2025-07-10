/*
 * @overview        {RegistroEntradaSalida}
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
     * TODO: Description of {@code RegistroEntradaSalida}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RegistroEntradaSalida {

        [Key]
        public Int32? IntIdEntrada { get; set; }
        public String? StrTransporte { get; set; }
        public String? StrTicket { get; set; }
        public String? StrMatricula { get; set; }
        public String? StrVagon { get; set; }
        public DateTime? DtFechaEntrada { get; set; }
        public DateTime? DtFechaSalida { get; set; }
        public String? StrCombustible { get; set; }
        public String? StrTipoMovimiento { get; set; }
        public String? StrNombre { get; set; }
        public String? StrParvaAnterior { get; set; }
        public DateTime? DtFechaFinParva { get; set; }
        public String? StrPatio { get; set; }
        public DateTime? DtFechaInicioParva { get; set; }
        public String? StrMuestras { get; set; }
        public String? StrNroBolsa { get; set; }
        public String? StrCodigoPartida { get; set; }
        public String? StrConsecutivoVehiculo { get; set; }
        public Int32? IntPesoEntrada { get; set; }
        public Int32? IntPesoSalida { get; set; }
        public Int32? IntPesoNeto { get; set; }
        public String? StrUnidad { get; set; }
        public String? StrDescripcion { get; set; }
        public String? TxtRutaFotos { get; set; }
        public String? StrRfid { get; set; }
        public Boolean? BitProcesoManual { get; set; }
        public String? StrUsuario { get; set; }
        public Boolean? BitVehiculoDevuelto { get; set; }
        public String? StrCif { get; set; }
        public String? StrIdDestino { get; set; }
        public String? StrIdOrigen { get; set; }
        public String? StrEstado { get; set; }
        public Int32? IntIdPorDia { get; set; }
        public Int32? IntIdParque { get; set; }

    }

}