namespace Common
{
    /// <summary>
    /// Clase genérica para manejar respuestas estándar en la aplicación.
    /// </summary>
    /// <typeparam name="T">Contiene los datos de la aplicación</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Código de respuesta HTTP.
        /// </summary>
        public ResponseCode ResponseCode { get; set; }

        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool Success { get; set; }
       // public bool  IsExitoso { get; set; } , este lo podemos emplear para remmplazar el success anterior 

        /// <summary>
        /// Mensaje asociado a la respuesta.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Datos devueltos en caso de éxito.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Lista opcional de errores en caso de fallo.
        /// </summary>
        public List<string>? Errors { get; set; }

        /// <summary>
        /// Identificador de trazabilidad único para depuración.
        /// </summary>
        public string? TraceId { get; set; }

        /// <summary>
        /// Crea una respuesta de éxito de forma simplificada.
        /// </summary>
        public static Result<T> SuccessResponse(T data, string message = "Operación exitosa", string? traceId = null) =>
            new Result<T>
            {
                ResponseCode = ResponseCode.OK,
                Success = true,
                Message = message,
                Data = data,
                TraceId = traceId
            };

        /// <summary>
        /// Crea una respuesta de error de forma simplificada.
        /// </summary>
        public static Result<T> ErrorResponse(ResponseCode code, string message, List<string>? errors = null, string? traceId = null) =>
            new Result<T>
            {
                ResponseCode = code,
                Success = false,
                Message = message,
                Errors = errors,
                TraceId = traceId
            };
    }

    /// <summary>
    /// Enum para códigos de respuesta HTTP.
    /// </summary>
    public enum ResponseCode
    {
        // Success
        OK = 200,
        Created = 201,
        NoContent = 204,
        // Client Error
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        // Server Error
        InternalServerError = 500,
        BadGateway = 502,
        ServiceUnavailable = 503
    }
}
