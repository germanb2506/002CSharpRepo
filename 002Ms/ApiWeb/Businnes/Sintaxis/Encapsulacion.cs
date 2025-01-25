using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Businnes.Sintaxis
{
    internal class Encapsulacion
    {
        
        // Encapsulacion
        // Es el ocultamiento de los detalles de implementación de un objeto.

        //Public 
        // Se puede acceder desde cualquier parte del código.


        //Private
        // Solo se puede acceder desde la misma clase y es el valor por defecto si no ponemos nada al inicializar el codigo,
        // es recomendable a la hora de inicializar una variable que no queremos que sea modificada desde fuera de la clase usar el private

        //Se recomienda a la hoda de inicializar una variable que no queremos que sea modificada desde fuera de la clase usar el private y
        //modificarla mediante un metodo set y obtenerla mediante un metodo get.
        private int MiVariable;

        //Este metodo se llama constructor y sirve para definir el estado inicial de un objeto y se ejecuta cuando se crea una instancia de la clase.
        public Encapsulacion()
        {

        }
        public int GetMiVariable()
        {
            return this.MiVariable;
        }
        public void SetEncapsulacion(int nuevoValor)
        {
            //Aca adentro le podemo poner condiciones para que no se pueda modificar el valor de la variable o como se puede modificar
            this.MiVariable = nuevoValor;
        }


    }
}
