namespace APIVideogames.Resources.Strings
{
    public class ApiStrings
    {
        // Validations
        public const string RequiredField = "El campo {0} es obligatorio";
        public const string StringLenght = "El campo {0} debe tener como máximo {1} caracteres";
        public const string RangeValidation = "El campo {0} debe estar entre {1} y {2}";
        public const string FirstCharValidation = "La primera letra debe ser mayúscula";

        // Routes
        public const string CreatedPlatform = "GetPlatform";
        public const string CreatedVideogame = "GetVideogame";

        // Logs
        public const string PostVideogameError = "Error al realizar la petición Post de la clase Videogame: ";
        public const string PostPlatformError = "Error al realizar la petición Post de la clase Platform: ";
        public const string PutVideogameError = "Error al realizar la petición Put de la clase Videogame: ";
        public const string PutPlatformError = "Error al realizar la petición Put de la clase Platform: ";
        public const string DeleteVideogameError = "Error al realizar la petición Delete de la clase Videogame: ";
        public const string DeletePlatformError = "Error al realizar la petición Delete de la clase Platform: ";
    }
}
