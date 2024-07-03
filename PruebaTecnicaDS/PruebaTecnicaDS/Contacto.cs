using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaTecnicaDS
{
    public class Contacto{
        private string ID_Contacto;
        private string Nombre;
        private string Telefono;
        private string Email;

        public Contacto(string ID_contacto, string Nombre, string Telefono, string Email){

            this.ID_Contacto = ID_contacto;
            this.Nombre = Nombre;   
            this.Telefono = Telefono; 
            this.Email = Email;
            }


        public override string ToString(){
            return $"ID: {ID_Contacto}, Nombre: {Nombre}, Teléfono: {Telefono}, Email: {Email}";
        }

        public string archivoguardar(){
            return $"{ID_Contacto};{Nombre};{Telefono};{Email}";
        }

        // Métodos Getter y Setter
        public string GetID_Contacto(){
            return ID_Contacto;
        }

        public void SetID_Contacto(string value){
            ID_Contacto = value;
        }

        public string GetNombre(){
            return Nombre;
        }

        public void SetNombre(string value){
            Nombre = value;
        }

        public string GetTelefono(){
            return Telefono;
        }

        public void SetTelefono(string value){
            Telefono = value;
        }

        public string GetEmail(){
            return Email;
        }

        public void SetEmail(string value){
            Email = value;
        }
    }
}
