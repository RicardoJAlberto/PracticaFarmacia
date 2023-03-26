using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticasFarmacia
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<Medicamento>> catalogos = new Dictionary<string, List<Medicamento>>();


            catalogos.Add("Gripe", new List<Medicamento>{
                new Medicamento("Acetaminofen", "pastillas", 20, new DateTime(2024, 10, 15)),
                new Medicamento("Ibuprofeno", "pastillas", 30, new DateTime(2023, 12, 31)),
                new Medicamento("Ambroxol", "jarabe", 100, new DateTime(2022, 6, 30))
            });
            catalogos.Add("Dolor de cabeza", new List<Medicamento>{
                new Medicamento("Acetaminofén", "pastillas", 25, new DateTime(2025, 3, 1)),
                new Medicamento("Aspirina", "pastillas", 40, new DateTime(2022, 9, 15)),
                new Medicamento("Ibuprofeno", "pastillas", 10, new DateTime(2023, 4, 30))
            });
            catalogos.Add("Alergia", new List<Medicamento>{
                new Medicamento("Loratadina", "pastillas", 15, new DateTime(2024, 8, 31)),
                new Medicamento("Cetirizina", "pastillas", 20, new DateTime(2022, 11, 30)),
                new Medicamento("Allergy", "inyección", 5, new DateTime(2023, 6, 30))
            });
            catalogos.Add("Dolor de estomago", new List<Medicamento>{
                new Medicamento("Sucrasil", "jarabe", 30, new DateTime(2023, 5, 31)),
                new Medicamento("pepto bismol", "jarabe", 25, new DateTime(2025, 2, 28)),
                new Medicamento("Buscapina", "pastillas", 1, new DateTime(2024, 12, 31))
            });

            Console.WriteLine("Ingrese su nombre:");
            string nombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese su número de identificación:");
            string idCliente = Console.ReadLine();
            Console.WriteLine("Bienvenido a la farmacia NEO GENESIS. Seleccione una enfermedad para ver el catálogo de medicamentos:");
            Console.WriteLine("1. Gripe");
            Console.WriteLine("2. Dolor de cabeza");
            Console.WriteLine("3. Alergia");
            Console.WriteLine("4. Dolor de estomago");
            int seleccion = int.Parse(Console.ReadLine());


            List<Medicamento> catalogoSeleccionado = catalogos[EnfermedadPorNumero(seleccion)];


            Console.WriteLine("El catálogo de medicamentos para " + EnfermedadPorNumero(seleccion) + " es el siguiente:");
            for (int i = 0; i < catalogoSeleccionado.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + catalogoSeleccionado[i].Nombre + " - " + catalogoSeleccionado[i].Tipo + " - " + catalogoSeleccionado[i].Cantidad + " unidades - Vencimiento: " + catalogoSeleccionado[i].FechaVencimiento.ToShortDateString());
            }


            Console.WriteLine("Seleccione el número del medicamento que desea comprar:");
            int medicamentoSeleccionado = int.Parse(Console.ReadLine());


            Medicamento medicamento = catalogoSeleccionado[medicamentoSeleccionado - 1];
            Console.WriteLine("Ha seleccionado el medicamento " + medicamento.Nombre + " - " + medicamento.Tipo + " - " + medicamento.Cantidad + " unidades - Vencimiento: " + medicamento.FechaVencimiento.ToShortDateString());


            Console.WriteLine("Ingrese la cantidad que desea comprar:");
            int cantidad = int.Parse(Console.ReadLine());


            if (cantidad > medicamento.Cantidad)
            {
                Console.WriteLine("Lo siento, no hay suficiente inventario para esa cantidad.");
            }
            else
            {

                medicamento.Cantidad -= cantidad;


                double precioTotal = cantidad * medicamento.PrecioUnitario();


                Console.WriteLine("El precio total de su compra es $" + precioTotal + ". ¿Desea confirmar la compra? (s/n)");
                string confirmacion = Console.ReadLine();

                if (confirmacion.ToLower() == "s")
                {
                    Console.WriteLine("¡Gracias por su compra!");
                }
                else
                {

                    medicamento.Cantidad += cantidad;
                    Console.WriteLine("Compra cancelada.");
                }
            }

        }


        static string EnfermedadPorNumero(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "Gripe";
                case 2:
                    return "Dolor de cabeza";
                case 3:
                    return "Alergia";
                case 4:
                    return "Dolor de estomago";
                default:
                    return "";
            }
        }
    }
    
}


class Medicamento
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaVencimiento { get; set; }



  public Medicamento(string nombre, string tipo, int cantidad, DateTime fechaVencimiento)
    {
        Nombre = nombre;
        Tipo = tipo;
        Cantidad = cantidad;
        FechaVencimiento = fechaVencimiento;
    }


    public double PrecioUnitario()
    {
        switch (Tipo)
        {
            case "pastillas":
                return 3.0;
            case "inyecciones":
                return 7.0;
            case "jarabe":
                return 5.0;
            case "pomada":
                return 4.0;
            default:

                return 0.0;
        }
    }
}
