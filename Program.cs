class Program
{
    static int index = 2;   
    static string[] cedula = new string[index];
    static string[] nombre = new string[index];
    static float[] promedio = new float[index];
    static string[] condicion = new string[index];
    static string buscar = "";
    static bool encontrada = false;
    static int modificar = 0;
    static string newNom = "";
    static string newCed = "";
    static float newProm = 0;
    static string continuar = "";
    static string nombres = "";
    static float mayor = 0;
    static float menor = 0;
    static float[] alto = new float[index];
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nMenú Principal:");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Incluir Estudiantes");
            Console.WriteLine("3. Consultar Estudiantes");
            Console.WriteLine("4. Modificar Estudiantes");
            Console.WriteLine("5. Eliminar Estudiantes");
            Console.WriteLine("6. Submenú Reportes");
            Console.WriteLine("7. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InicializarVectores();
                    break;
                case "2":
                    IncluirEstudiante();
                    break;
                case "3":
                    ConsultarEstudiantes();
                    break;
                case "4":
                    ModificarEstudiantes();
                    break;
                case "5":
                    EliminarEstudiantes();
                    break;
                case "6":
                    SubmenuReportes();
                    break;
                case "7":
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void InicializarVectores()
    {
        for (int i = 0; i < nombre.Length; i++)
        {
            
            nombre[i] = "";
            cedula[i] = "";
            promedio[i] = 0;
            condicion[i] = "";
            alto[i] = 0;
        }
        index = 2;

        Console.WriteLine( "Vetores Inicializados con exito" );
    }   

    static void IncluirEstudiante()
    {
        bool validar = false;
        try
        {
            for (int i = 0; i < cedula.Length; i++)
            {
                do
                {
                    Console.WriteLine("Digite la Cedula del Estudiante " + (i + 1));
                    string inputCedula = Console.ReadLine();

                    // Verificar si la entrada consiste solo en números
                    if (int.TryParse(inputCedula, out _))
                    {
                        cedula[i] = inputCedula;
                        validar = true;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingrese solo números para la cédula.");
                    }
                } while (!validar);

                Console.WriteLine("Digite el Nombre del Estudiante " + (i + 1));
                nombres = Console.ReadLine();
                nombre[i] = nombres.ToLower();

                do
                {
                    Console.WriteLine("Digite promedio del estudiante " + (i + 1));
                    float Promedio;
                    if (!float.TryParse(Console.ReadLine(), out Promedio))
                    {
                        Console.WriteLine("Por favor, ingrese un número válido para el promedio.");
                        break; ;
                    }

                    // Verificar si el promedio es negativo
                    if (Promedio < 0)
                    {
                        Console.WriteLine("No se pueden ingresar promedios negativos. Intente de nuevo.");
                    }
                    // Verificar si el promedio excede 100
                    else if (Promedio > 100)
                    {
                        Console.WriteLine("El promedio no puede superar 100. Intente de nuevo.");
                    }
                    else
                    {
                        promedio[i] = Promedio;
                        validar = true;
                    }
                } while (!validar);

                if (promedio[i] >= 70)
                {
                    condicion[i] = "aprobado";
                }
                else if (promedio[i] < 70 && promedio[i] >= 60)
                {
                    condicion[i] = "aplazado";
                }
                else if (promedio[i] < 60)
                {
                    condicion[i] = "reprobado";
                }
            }
        }
        catch (Exception error1)
        {
            Console.WriteLine("Error: " + error1.Message);
        }
    }

    static void ConsultarEstudiantes()
    {
        bool validar = false;
        try
        {
            while (true)
            {
                Console.WriteLine("Digite el número de cédula del estudiante que desea consultar");
                string buscar = Console.ReadLine();
                bool encontrada = false;

                for (int i = 0; i < cedula.Length; i++)
                {
                    if (cedula[i] == buscar)
                    {
                        Console.WriteLine("=============================================================================================");
                        Console.WriteLine($"Cédula: {cedula[i]} Nombre: {nombre[i]} Promedio: {promedio[i]} Condición: {condicion[i]}  ");
                        Console.WriteLine("=============================================================================================");

                        encontrada = true;
                        break; // Salir del bucle una vez que se encuentra la cédula
                    }
                }

                if (!encontrada)
                {
                    Console.WriteLine("No se encontró ningún estudiante con esa cédula.");
                }

                Console.WriteLine("Presione 8 para regresar al Menú Principal.");
                string opcion = Console.ReadLine();

                if (opcion == "8")
                {
                    return; // Regresar al menú principal
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                }
            }
        }
        catch (Exception error2)
        {
            Console.WriteLine("Error de formato, intente de nuevo");
            validar = true;
        }
    }

    static void ModificarEstudiantes()
    {
        bool validar = false;
        do
        {
            try
            {
                Console.WriteLine("Digite el número de cédula del estudiante que desea modificar");
                buscar = Console.ReadLine();

                for (int i = 0; i < cedula.Length; i++)
                {
                    if (cedula[i] == buscar)
                    {
                        do
                        {
                            Console.WriteLine("Modificar 1-nombre");
                            Console.WriteLine("Modificar 2-cedula");
                            Console.WriteLine("Modificar 3-Promedio");
                            modificar = int.Parse(Console.ReadLine());

                            switch (modificar)
                            {
                                case 1:
                                    Console.WriteLine("Digite el nuevo Nombre");
                                    newNom = Console.ReadLine();
                                    nombre[i] = newNom;
                                    break;

                                case 2:
                                    do
                                    {
                                        Console.WriteLine("Digite la nueva Cedula");
                                        newCed = Console.ReadLine();
                                        // Verificar si la cédula contiene solo números
                                        if (int.TryParse(newCed, out _))
                                        {
                                            cedula[i] = newCed;
                                            validar = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Por favor, ingrese solo números para la cédula.");
                                        }
                                    } while (!validar);
                                    break;

                                case 3:
                                    do
                                    {
                                        Console.WriteLine("Digite el nuevo Promedio");
                                        if (!float.TryParse(Console.ReadLine(), out newProm))
                                        {
                                            Console.WriteLine("Por favor, ingrese un número válido para el promedio.");
                                            continue;
                                        }

                                        // Verificar si el promedio es negativo
                                        if (newProm < 0)
                                        {
                                            Console.WriteLine("No se pueden ingresar promedios negativos. Intente de nuevo.");
                                        }
                                        // Verificar si el promedio excede 100
                                        else if (newProm > 100)
                                        {
                                            Console.WriteLine("El promedio no puede superar 100. Intente de nuevo.");
                                        }
                                        else
                                        {
                                            promedio[i] = newProm;
                                            validar = true;
                                        }
                                    } while (!validar);

                                    if (newProm >= 70)
                                    {
                                        condicion[i] = "Aprobado";
                                    }
                                    else if (newProm < 70 && newProm >= 60)
                                    {
                                        condicion[i] = "Aplazado";
                                    }
                                    else if (newProm < 60)
                                    {
                                        condicion[i] = "Reprobado";
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Opcion incorrecta");
                                    break;
                            }
                            encontrada = false;
                            // Preguntar al usuario si desea seguir modificando o salir
                            Console.WriteLine("¿Desea realizar más modificaciones? (S/N)");
                            continuar = Console.ReadLine();
                            if (continuar.ToUpper() != "S")
                            {
                                encontrada=true;
                                break; // Salir del bucle si la respuesta no es "S"

                            }
                                                        

                        } while (true); // Bucle de modificación
                                        // Salir del bucle principal una vez que se modifica el estudiante
                    }
                }

                if (!encontrada)
                {
                    Console.WriteLine("No se encontró ningún estudiante con esa cédula.");
                }

                Console.WriteLine("Presione 8 para regresar al Menú Principal.");
                string opcion = Console.ReadLine();

                if (opcion == "8")
                {
                    return; // Regresar al menú principal
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                }

            }
            catch (Exception error1)
            {
                Console.WriteLine("Error de formato, intente de nuevo");
                validar = true;
            }

        } while (true);
    }


    static void EliminarEstudiantes()
    {
        bool validar = false;
        do
        {
            try
            {
                Console.WriteLine("Digite el número de cédula del estudiante que desea eliminar");
                buscar = Console.ReadLine();

                encontrada = false; // Restablecer encontrada a false antes de comenzar la búsqueda

                for (int i = 0; i < cedula.Length; i++)
                {
                    if (cedula[i] == buscar)
                    {
                        cedula[i] = "";
                        nombre[i] = "";
                        promedio[i] = 0;
                        condicion[i] = "";
                        encontrada = true;
                        Console.WriteLine("Estudiante eliminado exitosamente.");
                        break; // Salir del bucle una vez que se encuentra la cédula
                    }
                }

                if (!encontrada)
                {
                    Console.WriteLine("No se encontró ningún estudiante con esa cédula.");
                }

                Console.WriteLine("Presione 8 para regresar al Menú Principal.");
                string opcion = Console.ReadLine();

                if (opcion == "8")
                {
                    return; // Regresar al menú principal
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                }
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error de formato, intente de nuevo");
                validar = true;
            }

        } while (true);
    }

    static void SubmenuReportes()
    {
        while (true)
        {
            Console.WriteLine("\nSubmenú Reportes:");
            Console.WriteLine("1. Reporte Estudiantes por Condición");
            Console.WriteLine("2. Reporte Todos los datos");
            Console.WriteLine("3. Regresar al Menú Principal");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            encontrada = false;
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Generando reporte de estudiantes por condición...");

                    Console.WriteLine("Digite la Condicion de los estudiantes que desea buscar");
                    Console.WriteLine("1- Aprobado    2-Aplazado  3-Reprobado"); 

                    try
                    {
                        int repCondi = int.Parse(Console.ReadLine());

                        switch (repCondi)
                        {
                            case 1:
                                for (int i = 0; i < nombre.Length; i++)
                                {
                                    if (condicion[i] == "aprobado")
                                    {
                                        Console.WriteLine($"Cedula :{cedula[i]} Nombre :{nombre[i]} Promedio :{promedio[i]} Condicion :{condicion[i]}");
                                        encontrada = true;
                                    }
                                   
                                }

                                if (!encontrada)
                                {
                                    Console.WriteLine("No existen estudiantes Aplazados");
                                }


                                break;
                            case 2:
                                for (int i = 0; i < nombre.Length; i++)
                                {
                                    if (condicion[i] == "aplazado")
                                    {
                                        Console.WriteLine($"Cedula :{cedula[i]} Nombre :{nombre[i]} Promedio :{promedio[i]} Condicion :{condicion[i]}");
                                        encontrada = true;
                                    }
                                    


                                }
                                if (!encontrada)
                                {
                                    Console.WriteLine("No existen estudiantes Aplazados");
                                }

                                break;
                            case 3:
                                for (int i = 0; i < nombre.Length; i++)
                                {
                                    if (condicion[i] == "reprobado")
                                    {
                                        Console.WriteLine($"Cedula :{cedula[i]} Nombre :{nombre[i]} Promedio :{promedio[i]} Condicion :{condicion[i]}");
                                        encontrada = true;
                                    }
                                  
                                }

                                if (!encontrada)
                                {
                                    Console.WriteLine("No existen estudiantes Aplazados");
                                }

                                break;

                            default:
                                Console.WriteLine("Numero incorrecto");
                                break;

                        }

                                  
                            
                          
                        
                    }
                    catch (Exception)
                    {

                        Console.WriteLine( "error de formato");
                    }
                    

                    
                     
                    





                    break;
                case "2":
                    Console.WriteLine("Generando reporte con todos los datos de los estudiantes...");




                    for (int i = 0; i < cedula.Length; i++)
                    {
                        if (promedio[i] >= mayor)
                        {
                            mayor = promedio[i];
                            alto[i] = mayor;


                        }
                        else if (promedio[i] < mayor)
                        {
                            menor = promedio[i];
                        }

                    }
                    Console.WriteLine("*Los estudiantes con las notas mas altas son:**");
                    for (int j = 0; j < cedula.Length; j++)
                    {
                        if (promedio[j] == mayor)
                        {


                            Console.WriteLine("=============================================================================================");
                            Console.WriteLine($"Cédula: {cedula[j]} Nombre: {nombre[j]} Promedio: {promedio[j]} Condición: {condicion[j]}  ");
                            Console.WriteLine("=============================================================================================");


                        }
                    }
                    Console.WriteLine("**Los estudiantes con las notas mas Bajas son:**");
                    for (int j = 0; j < cedula.Length; j++)
                    {
                        if (promedio[j] == menor)
                        {


                            Console.WriteLine("=============================================================================================");
                            Console.WriteLine($"Cédula: {cedula[j]} Nombre: {nombre[j]} Promedio: {promedio[j]} Condición: {condicion[j]}  ");
                            Console.WriteLine("=============================================================================================");


                        }
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida." + promedio);
                    break;
            }
        }
    }


}