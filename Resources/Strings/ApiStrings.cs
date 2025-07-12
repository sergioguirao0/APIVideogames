using APIVideogames.Model.Entities;

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
        public const string CreatedDeveloper = "GetDeveloper";
        public const string CreatedGenre = "GetGenre";

        // Logs
        public const string PostVideogameError = "Error al realizar la petición Post de la clase Videogame: ";
        public const string PostPlatformError = "Error al realizar la petición Post de la clase Platform: ";
        public const string PostDeveloperError = "Error al realizar la petición Post de la clase Developer: ";
        public const string PostGenreError = "Error al realizar la petición Post de la clase Genre: ";
        public const string PutVideogameError = "Error al realizar la petición Put de la clase Videogame: ";
        public const string PutPlatformError = "Error al realizar la petición Put de la clase Platform: ";
        public const string PutDeveloperError = "Error al realizar la petición Put de la clase Developer: ";
        public const string PutGenreError = "Error al realizar la petición Put de la clase Genre: ";
        public const string DeleteVideogameError = "Error al realizar la petición Delete de la clase Videogame: ";
        public const string DeletePlatformError = "Error al realizar la petición Delete de la clase Platform: ";
        public const string DeleteDeveloperError = "Error al realizar la petición Delete de la clase Developer: ";
        public const string DeleteGenreError = "Error al realizar la petición Delete de la clase Genre: ";

        // Errors
        public const string PlatformExistError = "La plataforma indicada no se encuentra en la base de datos";
        public const string DeveloperExistError = "El desarrollador indicada no se encuentra en la base de datos";
        public const string GenreExistError = "El género indicado no se encuentra en la base de datos";
    }
}
