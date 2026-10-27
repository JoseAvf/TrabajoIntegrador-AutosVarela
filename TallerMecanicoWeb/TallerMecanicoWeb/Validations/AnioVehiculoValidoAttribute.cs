using System.ComponentModel.DataAnnotations;

namespace TallerMecanicoWeb.Validations
{
    public class AnioVehiculoValidoAttribute : ValidationAttribute     //Creamos una clase que hereda de ValidationAttribute, una clase de .NET que permite definir validaciones personalizadas.
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            int anio = (int)value;
            int anioActual = DateTime.Now.Year;

            if (anio < 1900 || anio > anioActual)
            {
                return new ValidationResult(
                    $"El año debe estar entre 1900 y {anioActual}"
                );
            }

            return ValidationResult.Success;
        }
    }
}

