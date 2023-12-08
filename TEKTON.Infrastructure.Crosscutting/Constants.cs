namespace TEKTON.Infrastructure.Crosscutting
{
    public class Constants
    {
        public static class HttpStatusCodes
        {
            public const int Ok = 200;
            public const int Created = 201;
            public const int BadRequest = 400;
            public const int Unauthorized = 401;
            public const int NotFound = 404;
            public const int MethodNotAllowed = 405;
            public const int ContentTypeNotAllowed = 406;
            public const int ContentTypeWrong = 415;
            public const int InternalServerError = 500;
        }

        public static class RediExpire
        {
            public const int Minutos = 5;
        }
        public static class EstadoRegistro
        {
            public const int Active = 1;
            public const int Inactive = 0;
        }

        public static class EstadoName
        {
            public const string Active = "Active";
            public const string Inactive = "Inactive";
        }

        public static class FormatoFecha
        {
            public const string DiaMesAnio = "dd/MM/yyyy";
            public const string DiaMesAnioHora = "dd/MM/yyyy H:mm:ss";

        }

        public static class Usuario
        {
            public const string Default = "Administrador";
            public const string Invitado = "WLevita";
        }
    }
}