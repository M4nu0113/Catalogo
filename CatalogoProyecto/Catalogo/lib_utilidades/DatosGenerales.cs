namespace lib_utilidades
{
    public class DatosGenerales
    {
        // @"C:\Conexion\secrets.json"; Conexion Manu
        //  @"D:\code\Conexion\secrets.json"; Conexion Ema
        public static string ruta_json = @"C:\Conexion\secrets.json";
        public static bool usa_azure = false;
        public static string clave = "EVWo3ieJj4ng44ll0hHeNn7ai4MWo0d5l40gO8ngZUoR47n520";
        public static string usuario_datos = EncriptarConversor.Encriptar("Dark.Tester");
    }
}   