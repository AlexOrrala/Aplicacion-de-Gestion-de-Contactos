using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDS
{
    public class GestorDeContactos{
        private List<Contacto> ListaContactos;
        public GestorDeContactos() { 
            ListaContactos = new List<Contacto>();
        }

        public void AgregarListaContacto(Contacto C1){
            if (BuscarContacto(C1.GetID_Contacto()) == null) { 
                ListaContactos.Add(C1);
                Console.WriteLine("Contacto Agregado con éxito");
            }
        }

        public Contacto BuscarContacto(string Id_Contacto){
            Contacto ContactoBuscado = ListaContactos.Find(c => (c.GetID_Contacto()).Equals(Id_Contacto));
            if (ContactoBuscado != null){
                Console.WriteLine("El Contacto se encuentra en la lista");
                return ContactoBuscado;
            }
            else{
                Console.WriteLine("El Contacto no se encuentra en la lista");
                return null;
            }
        }

        public void EliminarContacto(string Id_Contacto){
            Contacto ContactoaEliminar = BuscarContacto(Id_Contacto);
            if (ContactoaEliminar != null){
                Console.WriteLine("Contacto Eliminado");
                ListaContactos.Remove(ContactoaEliminar);
            }

        }

        public void MostrarContactos(){
            if (ListaContactos.Count!=0){
            foreach (Contacto C in ListaContactos){
                    Console.WriteLine(C.ToString());
                }
            }else{
                Console.WriteLine("Lista de contactos Vacía");
                }

        }

        public void GuardarContactos(String Direccion){
            if (ListaContactos.Count!=0){
                if(!File.Exists(Direccion)){
                    Console.WriteLine($"El archivo {Direccion} no existe, se ha Creado.");
                }else{
                    Console.WriteLine($"El archivo {Direccion} ya existe, se han agregado los contactos.");
                }
                try{
                    using (StreamWriter writer = new StreamWriter(Direccion,append : true)){
                        string linea;
                        foreach (Contacto C in ListaContactos){
                            writer.WriteLine(C.archivoguardar());
                             }
                    }
                }catch (Exception e){
                    Console.WriteLine($"Ocurrió un error al leer el archivo: {e.Message}");
                }
                    Console.WriteLine("\nLectura completada.");
            }else{
                Console.WriteLine("Lista Vacia");
                 }
        }
        public void CargarContactos(String Direccion){
            if (!File.Exists(Direccion)){
                Console.WriteLine($"El archivo {Direccion} no existe");
            }
            else{
                try{
                    using (StreamReader sr = new StreamReader(Direccion)){
                        string linea;
                        while ((linea = sr.ReadLine()) != null){
                            string[] usuariolinea;
                            usuariolinea = linea.Split(';');
                            if (usuariolinea.Length == 4){
                                Contacto nuevo = new Contacto(usuariolinea[0], usuariolinea[1], usuariolinea[2], usuariolinea[3]);
                                Console.WriteLine (nuevo.ToString());
                                AgregarListaContacto(nuevo);
                            }else{
                                Console.WriteLine($"La linea no se encuentra con el formato correcto: {usuariolinea}");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ocurrió un error al leer el archivo: {e.Message}");
                }

                Console.WriteLine("\nLectura completada.");
            }
        }

    }
}
