namespace Businnes.Sintaxis
{
    internal class Condicionales
    {
        public void MiMetodoEjemplo()
        {
            bool condicion = true;
            //IF
            if (condicion) { } else if (condicion) { } else { }

            int valueSwicth = 2;
            switch (valueSwicth)
            {   /*Este condicional solo puede evaluar int, string y char por lo que es
                mas limitado que if el cual si evalua float y double, asi mismo no admite
                operadores de comparacion  como && o ||  ya que solo permite constantes*/
                case 1:
                    //Codigo ejecutar primer caso
                    break;
                case 2:
                    //Codigo Ejejcutar segundo caso
                    break;
                default:
                    //Codigo ejecutar en caso de que ninguna se cumplio
                    break;
            }
        }
    }
}
