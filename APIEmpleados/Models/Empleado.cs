using System.ComponentModel.DataAnnotations;

namespace APIEmpleados.Models
{
    public class Empleado
    {
        #region "Datos"
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El campo Id debe ser de 8 digitos")]
        [RegularExpression("^12")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Sueldo es obligatorio")]
        [Range(126, Double.MaxValue, ErrorMessage = "El campo Sueldo debe ser mayor a 125")]
        public double Sueldo { get; set; }

        [Required(ErrorMessage = "El campo FechaIngreso es obligatorio")]
        public DateTime FechaIngreso { get; set; }
        #endregion

        #region "Metodos"
        public static void CrearJSON(Empleado value)
        {
            string fileName = @".\Models\Empleado-" + value.Id + ".json";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(value);
            System.IO.File.WriteAllText(fileName, jsonString);
        }

        public static Empleado ObtenerJSON(string id)
        {
            string fileName = @".\Models\Empleado-" + id + ".json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            Empleado encontrado = System.Text.Json.JsonSerializer.Deserialize<Empleado>(jsonString);
            if (encontrado == null)
            {
                return null;
            }
            return encontrado;
        }
        #endregion
    }
}
