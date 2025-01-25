# Tipos de datos

## Tipos de Valor
Los tipos de valor almacenan directamente sus datos y tienen un tamaño fijo. Cuando se asigna una variable de tipo valor a otra, se realiza una copia de los datos.

### Tipos numéricos enteros:
* **byte**: 8 bits, rango de 0 a 255.
* **sbyte**: 8 bits con signo, rango de -128 a 127.
* **short**: 16 bits, rango de -32,768 a 32,767.
* **ushort**: 16 bits sin signo, rango de 0 a 65,535.
* **int**: 32 bits, rango de -2,147,483,648 a 2,147,483,647.
* **uint**: 32 bits sin signo, rango de 0 a 4,294,967,295.
* **long**: 64 bits, rango de -9,223,372,036,854,775,808 a 9,223,372,036,854,775,807.
* **ulong**: 64 bits sin signo, rango de 0 a 18,446,744,073,709,551,615.

### Tipos numéricos decimales:
* **float**: 32 bits, precisión simple.
* **double**: 64 bits, precisión doble.
* **decimal**: 128 bits, usado para cálculos con gran precisión, especialmente en finanzas.

### Tipo lógico:
* **bool**: Representa un valor de verdadero (`true`) o falso (`false`).

### Tipo de carácter:
* **char**: 16 bits, representa un solo carácter Unicode.

## Tipos de Referencia
Los tipos de referencia almacenan la referencia a los datos en memoria, no los datos en sí. Cuando una variable de tipo referencia se asigna a otra, ambas apuntan al mismo objeto en memoria.

### Cadenas:
* **string**: Representa una secuencia de caracteres Unicode.

### Tipos de referencia predefinidos:
* **object**: El tipo base de todos los tipos en C#. Puede almacenar cualquier tipo de dato.
* **dynamic**: Permite el uso de un tipo dinámico, resuelto en tiempo de ejecución.

### Tipos nulos:
* **Nullable<T>**: Permite que un tipo de valor sea nulo. Se usa como `int?`, `double?`, etc.

## Tipos definidos por el usuario
C# también permite definir tipos de datos personalizados mediante clases, estructuras, interfaces, delegados y enumeraciones.

* **Clases** (`class`): Tipos de referencia que pueden contener métodos, propiedades y otros miembros.
* **Estructuras** (`struct`): Tipos de valor que permiten definir tipos complejos.
* **Enumeraciones** (`enum`): Representan un conjunto de constantes con nombre.
* **Delegados** (`delegate`): Tipos que representan métodos y permiten la programación orientada a eventos.