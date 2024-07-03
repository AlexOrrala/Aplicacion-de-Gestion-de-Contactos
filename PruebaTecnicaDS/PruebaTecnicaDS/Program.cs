
namespace PruebaTecnicaDS{
    class Program{
        private static GestorDeContactos ListaPrincipal = new GestorDeContactos();
        
        static void Main(string[] args){
            int opciones = 0;
            do
            {
                do
                {

                Console.WriteLine(" Menú de Contactos:\n 1. Agregar contacto\n 2. Buscar contacto\n 3. Listar contactos\n 4. Eliminar contacto\n 5. Guardar contactos\n 6. Cargar contactos\n 7. Salir\n");
                
                try
                {
                    opciones = Convert.ToInt32(Console.ReadLine());

                    if (opciones < 1 || opciones > 7)
                    {
                        Console.WriteLine("Por favor ingrese un número válido entre 1 y 7.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese solamente números. Intente nuevamente.");
                    opciones = 0;
                }

            } while (opciones > 7 || opciones < 1);
            switch(opciones){
                    case 1:
                        AgregarDatos();
                        break;
                    case 2:
                        BuscarContacto();
                        break;
                    case 3:
                        ListaPrincipal.MostrarContactos();
                        break;
                    case 4:
                        EliminarContacto();
                        break;
                    case 5:
                        GuardarDatos();
                        break;
                    case 6:
                        CargarDatos();
                        break;
                    case 7:
                        opciones = 7;
                        break;
                

                }
            } while (opciones != 7);

     }

        private static void EliminarContacto(){
            string ID_Contacto;
            ID_Contacto = NoVacios("Ingreso el ID del contacto:");
             ListaPrincipal.EliminarContacto(ID_Contacto);
        }

        private static void BuscarContacto(){
            string ID_Contacto;
            ID_Contacto= NoVacios("Ingreso el ID del contacto:");
            Contacto encontrado = ListaPrincipal.BuscarContacto(ID_Contacto);
            if ( encontrado != null) { 
            Console.WriteLine(encontrado.ToString());
            }
        }

        private static void AgregarDatos(){
            string ID_Contacto;
            string Nombre;
            string Telefono;
            string Email;

            ID_Contacto = NoVacios("Ingreso el ID del contacto:");
            Nombre = NoVacios("Ingreso el Nombre del contacto:");
            Telefono = NoVacios("Ingreso el Teléfono del contacto:");
            Email = NoVacios("Ingreso el email del contacto:");

            Contacto nuevo = new Contacto(ID_Contacto,Nombre,Telefono,Email);

            ListaPrincipal.AgregarListaContacto(nuevo);
        }

        private static void CargarDatos(){
            string ubicacion = "";
                ubicacion = NoVacios("\nIngrese la dirección del archivo:");
            ListaPrincipal.CargarContactos(ubicacion);

        }
        private static void GuardarDatos()
        {
            string ubicacion = "";
            ubicacion = NoVacios("\nIngrese la dirección del archivo:");
            ListaPrincipal.GuardarContactos(ubicacion);

        }

        private static string NoVacios(string texto){
            string valor;
            do{
                Console.WriteLine($"\n{texto}");
                valor = Console.ReadLine();
            } while (valor == "");
            return valor;
        }



    }
}