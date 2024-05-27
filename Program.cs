using EspacioCalculadora;
using admin;

Calculadora miCalculadora = new Calculadora();

Console.WriteLine("\n----------Ejercicio 1----------\n");
int op;
int control;
do
{
    Console.WriteLine($"Valor actual del operando = {miCalculadora.Resultado}\n");
    Console.WriteLine("Seleccione la operacion que desea realizar\n");
    Console.WriteLine("[1]. Suma\n");
    Console.WriteLine("[2]. Resta\n");
    Console.WriteLine("[3]. Multplicación\n");
    Console.WriteLine("[4]. Division\n");
    Console.WriteLine("[5]. Limpiar\n");
    string operacion = Console.ReadLine();
    double num = 0;
    if (int.TryParse(operacion, out op) && 1<=op && op<=5)
    {
        if (op != 5)
        {
            string nro;
            do
            {
                Console.WriteLine("Ingrese un numero: \n");
                nro = Console.ReadLine();
            } while (!double.TryParse(nro, out num));            
        }
        switch (op)
        {
            case 1:
                miCalculadora.Sumar(num);
                Console.WriteLine($"\nEl resultado de la suma es {miCalculadora.Resultado}");
                break;
            case 2:
                miCalculadora.Restar(num);
                Console.WriteLine($"\nEl resultado de la resta es {miCalculadora.Resultado}");
                break;
            case 3:
                miCalculadora.Multiplicar(num);
                Console.WriteLine($"\nEl resultado de la multiplicacion es {miCalculadora.Resultado}");
                break;
            case 4:
                miCalculadora.Dividir(num);
                if (num != 0)
                {
                    Console.WriteLine($"\nEl resultado de la division es {miCalculadora.Resultado}");
                }
                break;
            case 5:
                miCalculadora.Limpiar();
                break;

        }
    } 
    Console.WriteLine("\nDesea seguir operando?\n");
    Console.WriteLine("[1]. Si\n");
    Console.WriteLine("[0]. No\n");
    string controla = Console.ReadLine();
    if (!int.TryParse(controla, out control))
    {
        control = 1;
    }
} while (control != 0);
Console.WriteLine("\nSe ha seleccionado [0]. Saliendo del programa.\n");



Console.WriteLine("\n------Ejercicio 2------\n");

Empleado[] Empleados = new Empleado[3];

char estado;
string ingresado;
DateTime fechaNacim;
DateTime fechaIng;
double sueldoBasic;
int cargoDelEmpleado;

for (int i = 0; i < 3; i++)
{
    Empleados[i] = new Empleado();
    Console.WriteLine($"\n------Empleado {i+1}------\n");
    Console.WriteLine("Ingrese el nombre del empleado\n");
    Empleados[i].Nombre = Console.ReadLine();

    Console.WriteLine("Ingrese el apellido del empleado\n");
    Empleados[i].Apellido = Console.ReadLine();

    Console.WriteLine("Ingrese la fecha de nacimiento del empleado.\n");
    do
    {
        Console.WriteLine("\nPor favor, utilice el formato AAAA-MM-DD.");
        ingresado = Console.ReadLine();
    } while (!DateTime.TryParse(ingresado, out fechaNacim));
    Empleados[i].FechaNac = fechaNacim;

    do
    {
        Console.WriteLine("Seleccione el estado civil empleado\n");
        Console.WriteLine("[c]. Casado\n");
        Console.WriteLine("[s]. Soltero\n");
        ingresado = Console.ReadLine();
        
    } while (!char.TryParse(ingresado, out estado) || (estado != 'c' && estado != 's' && estado != 'C' && estado != 'S'));
    Empleados[i].EstadoCivil = estado;

    Console.WriteLine("Ingrese la fecha de ingreso en la empresa del empleado.\n");
    do
    {
        Console.WriteLine("\nPor favor, utilice el formato AAAA-MM-DD.");
        ingresado = Console.ReadLine();
    } while (!DateTime.TryParse(ingresado, out fechaIng));
    Empleados[i].FechaIngreso = fechaIng;
    
    do
    {
        Console.WriteLine("Ingrese el sueldo basico del empleado\n");
        ingresado = Console.ReadLine();
    } while (!double.TryParse(ingresado, out sueldoBasic) || sueldoBasic < 0);
    Empleados[i].SueldoBasico = sueldoBasic;

    do
    {
        Console.WriteLine("Seleccione el cargo del empleado.\n");
        Console.WriteLine("[1]. Auxiliar\n");
        Console.WriteLine("[2]. Administrativo\n");
        Console.WriteLine("[3]. Ingeniero\n");
        Console.WriteLine("[4]. Especialista\n");
        Console.WriteLine("[5]. Investigador\n");
        ingresado = Console.ReadLine();
    } while (!int.TryParse(ingresado, out cargoDelEmpleado) || cargoDelEmpleado >= 6 || cargoDelEmpleado <= 0);
    switch (cargoDelEmpleado)
    {
        case 1:
        Empleados[i].Cargo = Cargos.Auxiliar;
             break;
        case 2:
        Empleados[i].Cargo = Cargos.Administrativo;
             break;
        case 3:
        Empleados[i].Cargo = Cargos.Ingeniero;
             break;
        case 4:
        Empleados[i].Cargo = Cargos.Especialista;
             break;
        case 5:
        Empleados[i].Cargo = Cargos.Investigador;
             break;
    }
}


double totalSalarios = 0;
for (int i = 0; i < 3; i++)
{
    totalSalarios = totalSalarios + Empleados[i].salario();
}
Console.WriteLine($"En concepto de salarios, se paga un total de ${totalSalarios}\n");

int menos = 65;
for (int i = 0; i < 3; i++)
{
    if (Empleados[i].aniosFaltantesJubilarse() <= menos)
    {
        menos = Empleados[i].aniosFaltantesJubilarse();
    }
}

Console.WriteLine($"Datos de el/los empleado/s mas proximo/s a jubilarse\n");
for (int i = 0; i < 3; i++)
{
    int edadd = Empleados[i].edad();
    int aniosAntiguedad = Empleados[i].antiguedad();
    double salarioo = Empleados[i].salario();
    int aniosFaltan = Empleados[i].aniosFaltantesJubilarse();
    string fechaIngr = Empleados[i].FechaIngreso.ToShortDateString();
    string fNac = Empleados[i].FechaNac.ToShortDateString();
    if (Empleados[i].aniosFaltantesJubilarse() == menos)
    {
        Console.WriteLine($"\n------Empleado {i+1}------\n");
        Console.WriteLine($"Apellido: {Empleados[i].Apellido}\n");
        Console.WriteLine($"Nombre: {Empleados[i].Nombre}\n");
        Console.WriteLine($"Fecha de nacimiento: {fNac}\n");
        Console.WriteLine($"Edad: {edadd} anios\n");
        Console.Write("Estado civil: ");
        if (Empleados[i].EstadoCivil == 'c')
        {
            Console.Write("casado\n\n");
        } else
        {
            Console.Write("soltero\n\n");
        }
        Console.WriteLine($"Fecha de ingreso a la empresa: {fechaIngr}\n");
        Console.WriteLine($"Antiguedad: {aniosAntiguedad} anios\n");
        Console.WriteLine($"Cargo: {Empleados[i].Cargo}\n");
        Console.WriteLine($"Sueldo basico: ${Empleados[i].SueldoBasico}\n");
        Console.WriteLine($"Salario: ${salarioo}\n");
        Console.WriteLine($"Cantidad de anios faltantes para poder jubilarse: {aniosFaltan}\n");
    }

}


