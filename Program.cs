using EspacioCalculadora;

Calculadora miCalculadora = new Calculadora();

Console.WriteLine("\n------Ejercicio 2------\n");
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

