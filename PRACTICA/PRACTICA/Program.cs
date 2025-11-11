using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICA
{

    class PRODUCTO
    {
        public string Nombre;
        public decimal CANTVEND;
        public decimal Pu;
        public decimal Subtotal
        {
            get
            {
                return CANTVEND * Pu;
            }


        }
    }

        internal class Program
        {

            static PRODUCTO[] productos = new PRODUCTO[5];
            static void Main(string[] args)
            {

                int contador = 0;
                int opcion;
                do
                {
                    Console.WriteLine("* MENU DE OPCIONES *");
                    Console.WriteLine("\n1. Registrar producto" +
                                      "\n2. Lista de productos" +
                                      "\n3. Buscar producto" +
                                      "\n4. Modificar precio" +
                                      "\n5. Salir del Programa");
                    Console.WriteLine("Seleccione una opcion: ");
                    if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.WriteLine(" Ingrese un número válido.");
                        Console.WriteLine();
                        continue;
                    }
                    switch (opcion)
                    {
                        case 1:
                            if (contador < 5)
                            {
                                productos[contador] = new PRODUCTO();
                                Console.WriteLine("PRODUCTO " + (contador + 1));
                                Console.Write("INGRESA EL NOMBRE DEL PRODUCTO: ");
                                productos[contador].Nombre = Console.ReadLine();
                                Console.Write("INGRESA LA CANTIDAD VENDIDA (Kg): ");
                                while (!decimal.TryParse(Console.ReadLine(), out productos[contador].CANTVEND))
                                {
                                    Console.Write("Error, ingrese un número entero válido: ");
                                }
                                Console.Write("INGRESA EL PRECIO UNITARIO (S/): ");
                                while (!decimal.TryParse(Console.ReadLine(), out productos[contador].Pu))
                                {
                                    Console.Write("Error, ingrese un precio válido: ");
                                }
                                contador++;

                            }
                            else
                            {
                                Console.WriteLine("LIMITE DE REGISTRO ALCANZADO.");
                            }
                                break;
                        case 2:
                            decimal totalPagar = 0;
                            if (contador > 0)
                            {
                                Console.WriteLine("====Lista de Productos====");
                                for (int i = 0; i < contador; i++)
                                {
                                    Console.WriteLine("*/*PRODUCTO: " + (i + 1));
                                    Console.WriteLine("Nombre: " + productos[i].Nombre);
                                    Console.WriteLine("Cantidad: " + productos[i].CANTVEND);
                                    Console.WriteLine("Precio unitario: " + productos[i].Pu);
                                    Console.WriteLine("Subtotal: " + productos[i].Subtotal);
                                   totalPagar += productos[i].Subtotal; 
                                }
                                Console.WriteLine("TOTAL A PAGAR POR TODOS LOS PRODUCTOS: " + totalPagar);
                            }
                            else
                            {
                                Console.WriteLine("No hay productos registrados.");
                            }
                            break;
                        case 3:
                            string ProdBUS;
                            bool found=false;
                            Console.WriteLine("Ingrese el nombre del producto:");
                            ProdBUS = Console.ReadLine().ToUpper();
                            for (int i = 0; i < contador; i++)
                            {
                                if (ProdBUS == productos[i].Nombre.ToUpper())
                                {
                                    Console.WriteLine("Producto encontrado");
                                    Console.Write("Nombre: " + productos[i].Nombre);
                                    Console.Write("Cantidad: " + productos[i].CANTVEND);
                                    Console.Write("Precio unitario: " + productos[i].Pu);
                                    Console.Write("Subtotal: " + productos[i].Subtotal);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                                Console.WriteLine("Producto no encontrado.");
                            break;
                        case 4:
                            string nombreMod;
                            decimal NEWPrec;
                            bool encontrado = false;
                            Console.Write("Ingrese el nombre del producto para modificar su precio: ");
                            nombreMod = Console.ReadLine().ToUpper();
                            for (int i = 0; i < contador; i++)
                            {
                                if (nombreMod == productos[i].Nombre.ToUpper())
                                {
                                    Console.WriteLine("Producto encontrado");
                                    Console.WriteLine("Ingrese el nuevo precio: ");
                                    if (decimal.TryParse(Console.ReadLine(), out NEWPrec))
                                    {
                                        productos[i].Pu = NEWPrec;
                                        Console.WriteLine("Precio actualizado correctamente ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Precio inválido, no se realizó el cambio.");
                                    }
                                    encontrado = true;
                                    break;
                                }
                            }
                            if (!encontrado)
                            {
                                Console.WriteLine("Producto no encontrado.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa:");
                            break;
                    }
                } while (opcion != 5);
            }
        }
    
}
