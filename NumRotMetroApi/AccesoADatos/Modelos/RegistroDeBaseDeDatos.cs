namespace AccesoADatos.Modelos
{
    public class RegistroDeBaseDeDatos
    {
        /// <summary>
        /// Identificador de la empresa.
        /// </summary>
        public string? empresaIdentificador { get; set; }

        /// <summary>
        /// Identificador del documento procesado.
        /// </summary>
        public string? documentoNumero { get; set; }
        
        /// <summary>
        /// Nombre o razón social de la empresa.
        /// </summary>
        public string? empresaNombre { get; set; }
        
        /// <summary>
        /// Fecha y hora del último procesamiento.
        /// </summary>
        public DateTime ultimoAcceso { get; set; }
        
        /// <summary>
        /// Estado del documento ante la DIAN.
        /// </summary>
        public string? documentoEstadoDIAN { get; set; }
    }
}