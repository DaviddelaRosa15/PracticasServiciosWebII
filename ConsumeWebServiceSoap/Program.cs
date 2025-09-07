using ServiceReference1;
// See https://aka.ms/new-console-template for more information

// Leer el primer numero
Console.Write("Ingrese el 1er numero: ");
int first = int.Parse(Console.ReadLine());

// Leer el segundo numero
Console.Write("Ingrese el 2do numero: ");
int second = int.Parse(Console.ReadLine());

// Imprimir una linea en blanco
Console.WriteLine("");

// Consumir el servicio web
await ConsumeWebServiceSumAsync(first, second);

static async Task ConsumeWebServiceSumAsync(int first, int second)
{
    var client = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
    int result = await client.AddAsync(first, second);
    Console.WriteLine($"La suma es: {result}");
}
