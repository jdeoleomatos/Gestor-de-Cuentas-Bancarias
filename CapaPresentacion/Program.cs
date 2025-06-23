using System.Transactions;
using CapaNegocios;

namespace CapaPresentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            do
            {
                Titulo();
                Console.WriteLine("[1] Registrarte [2] Login [3] Salir");
                int opcion = int.Parse(Console.ReadLine());
                GestionBancaria servicio = new GestionBancaria();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingresa tu nombre completo: ");
                        string nombre_completo = Console.ReadLine();
                        Console.Write("Ingresa tu correo electrónico: ");
                        string correo_electronico = Console.ReadLine();
                        Console.Write("Ingresa tu carrera: ");
                        string carrera = Console.ReadLine();
                        Console.Write("Ingresa tu contraseña: ");
                        string contrasena = Console.ReadLine();
                        Console.WriteLine("Deposita un saldo inicial:");
                        decimal saldo = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(servicio.RegistrarPersona(nombre_completo, correo_electronico, carrera, contrasena, saldo));
                        menu = true;
                        break;

                    case 2:
                        Console.WriteLine("Inicio de sesión:");
                        Console.Write("Correo Electrónico: ");
                        string Correo_electronico = Console.ReadLine();
                        Console.Write("Contraseña: ");
                        string Contrasena = Console.ReadLine();
                        Console.WriteLine(servicio.IniciarSesion(Correo_electronico, Contrasena));

                        Console.Clear();
                        GestionTitulo();
                        Console.WriteLine("¿Qué quieres hacer?");
                        Console.WriteLine("[1] Depositar [2] Retirar [3] Consultar saldo [4] Salir");
                        int op1 = int.Parse(Console.ReadLine());

                        switch (op1)
                        {
                            case 1:
                                Console.WriteLine("Ingrese el monto a depositar:");
                                decimal montoDeposito = decimal.Parse(Console.ReadLine());
                                Console.WriteLine(servicio.DepositarSaldoEnDB(montoDeposito, Correo_electronico));
                                menu = true;
                                break;

                            case 2:
                                Console.WriteLine("Ingrese el monto a retirar:");
                                decimal montoRetiro = decimal.Parse(Console.ReadLine());
                                Console.WriteLine(servicio.RetirarSaldoEnDB(montoRetiro, Correo_electronico));
                                menu = true;
                                break;

                            case 3:
                                decimal saldoActual = servicio.ObtenerSaldoDesdeDB(Correo_electronico);
                                Console.WriteLine($"Tu saldo actual es: {saldoActual}");
                                menu = true;
                                break;

                            case 4:
                                menu = false;
                                break;
                        }
                        break;

                    case 3:
                        menu = false;
                        break;
                }
            } while (menu);
        }

        static void Titulo()
        {
            Console.WriteLine(@"
 /$$$$$$$                                                  /$$$$$  /$$$$$$  /$$$$$$$ 
| $$__  $$                                                |__  $$ /$$__  $$| $$__  $$
| $$  \ $$ /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$             | $$| $$  \ $$| $$  \ $$
| $$$$$$$ |____  $$| $$__  $$ /$$_____/ /$$__  $$            | $$| $$  | $$| $$$$$$$ 
| $$__  $$ /$$$$$$$| $$  \ $$| $$      | $$  \ $$       /$$  | $$| $$  | $$| $$__  $$
| $$  \ $$/$$__  $$| $$  | $$| $$      | $$  | $$      | $$  | $$| $$  | $$| $$  \ $$
| $$$$$$$/  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$/      |  $$$$$$/|  $$$$$$/| $$$$$$$/
|_______/ \_______/|__/  |__/ \_______/ \______/        \______/  \______/ |_______/ 
                                                                                     
                                                                                     
                                                                                     
");
        }

        static void GestionTitulo()
        {
            Console.WriteLine(@"
  /$$$$$$                       /$$     /$$                            /$$$$$$                                  /$$             
 /$$__  $$                     | $$    |__/                           /$$__  $$                                | $$             
| $$  \__/  /$$$$$$   /$$$$$$$/$$$$$$   /$$  /$$$$$$  /$$$$$$$       | $$  \__/ /$$   /$$  /$$$$$$  /$$$$$$$  /$$$$$$   /$$$$$$ 
| $$ /$$$$ /$$__  $$ /$$_____/_  $$_/  | $$ /$$__  $$| $$__  $$      | $$      | $$  | $$ /$$__  $$| $$__  $$|_  $$_/  |____  $$
| $$|_  $$| $$$$$$$$|  $$$$$$  | $$    | $$| $$  \ $$| $$  \ $$      | $$      | $$  | $$| $$$$$$$$| $$  \ $$  | $$     /$$$$$$$
| $$  \ $$| $$_____/ \____  $$ | $$ /$$| $$| $$  | $$| $$  | $$      | $$    $$| $$  | $$| $$_____/| $$  | $$  | $$ /$$/$$__  $$
|  $$$$$$/|  $$$$$$$ /$$$$$$$/ |  $$$$/| $$|  $$$$$$/| $$  | $$      |  $$$$$$/|  $$$$$$/|  $$$$$$$| $$  | $$  |  $$$$/  $$$$$$$
 \______/  \_______/|_______/   \___/  |__/ \______/ |__/  |__/       \______/  \______/  \_______/|__/  |__/   \___/  \_______/
                                                                                                                               
                                                                                                                               
                                                                                                                               
");
        }
    }
}
