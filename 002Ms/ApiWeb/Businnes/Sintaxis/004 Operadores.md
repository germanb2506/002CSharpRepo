# Operadores en C#

Los **operadores** en C# son símbolos que indican una operación que debe realizarse sobre los valores. C# ofrece una gran variedad de operadores, que se pueden clasificar en varias categorías: aritméticos, lógicos, relacionales, bit a bit, de asignación, de incremento y decremento, de tipo, de condicional, entre otros.

## 1. **Operadores Aritméticos**
Los operadores aritméticos se usan para realizar operaciones matemáticas básicas.

- `+` : Suma
- `-` : Resta
- `*` : Multiplicación
- `/` : División
- `%` : Módulo (resto de una división)

**Ejemplo**:
```csharp
int sum = 5 + 3; // Suma
int diff = 5 - 3; // Resta
int product = 5 * 3; // Multiplicación
int quotient = 5 / 3; // División
int remainder = 5 % 3; // Módulo
```

## 2. **Operadores Relacionales**
Se utilizan para comparar dos valores y devolver un valor booleano (`true` o `false`).

- `==` : Igual a
- `!=` : Diferente de
- `>` : Mayor que
- `<` : Menor que
- `>=` : Mayor o igual que
- `<=` : Menor o igual que

**Ejemplo**:
```csharp
bool isEqual = 5 == 3;  // Falso
bool isGreaterThan = 5 > 3; // Verdadero
```

## 3. **Operadores Lógicos**
Se utilizan para combinar expresiones booleanas.

- `&&` : Y lógico (AND)
- `||` : O lógico (OR)
- `!` : Negación lógica (NOT)

**Ejemplo**:
```csharp
bool result = (5 > 3) && (8 < 10); // AND: Verdadero
bool orResult = (5 > 3) || (8 > 10); // OR: Verdadero
bool notResult = !(5 > 3); // NOT: Falso
```

## 4. **Operadores de Asignación**
Se utilizan para asignar valores a las variables.

- `=` : Asignación
- `+=` : Suma y asigna
- `-=` : Resta y asigna
- `*=` : Multiplica y asigna
- `/=` : Divide y asigna
- `%=` : Módulo y asigna

**Ejemplo**:
```csharp
int a = 5; // Asignación
a += 3; // a = a + 3
a -= 2; // a = a - 2
a *= 4; // a = a * 4
a /= 2; // a = a / 2
```

## 5. **Operadores de Incremento y Decremento**
- `++` : Incremento (aumenta el valor de la variable en 1)
- `--` : Decremento (disminuye el valor de la variable en 1)

**Ejemplo**:
```csharp
int x = 5;
x++; // Incremento: x = 6
x--; // Decremento: x = 5
```

## 6. **Operadores Condicionales**
- `? :` : Operador ternario. Evaluación condicional que elige entre dos valores según una expresión booleana.

**Sintaxis**:
```csharp
condición ? valorSiVerdadero : valorSiFalso;
```

**Ejemplo**:
```csharp
int age = 18;
string result = age >= 18 ? "Adulto" : "Menor";
```

## 7. **Operadores de Tipo**
Se utilizan para verificar tipos de datos o convertir entre ellos.

- `is` : Verifica si un objeto es de un tipo determinado.
- `as` : Realiza una conversión segura de tipo.
- `(tipo)` : Conversión explícita (casting).

**Ejemplo**:
```csharp
object obj = "Hello";
bool isString = obj is string; // Verdadero

string str = obj as string; // Conversion segura
int x = (int)obj; // Conversión explícita (puede lanzar excepción si el tipo no es correcto)
```

## 8. **Operadores Bit a Bit**
Operan sobre los valores binarios de los operandos.

- `&` : Y bit a bit
- `|` : O bit a bit
- `^` : O exclusivo bit a bit (XOR)
- `~` : Negación bit a bit (complemento)
- `<<` : Desplazamiento a la izquierda
- `>>` : Desplazamiento a la derecha

**Ejemplo**:
```csharp
int x = 5; // 0101 en binario
int y = 3; // 0011 en binario
int result = x & y; // 0001 en binario (Y bit a bit)
result = x | y; // 0111 en binario (O bit a bit)
```

---

# Interpolación de Cadenas en C#

La **interpolación de cadenas** en C# permite incrustar expresiones dentro de cadenas literales. Esto proporciona una forma más clara y concisa de concatenar cadenas.

## 1. **Sintaxis de Interpolación de Cadenas**
Para usar la interpolación de cadenas, se utiliza el signo `$` antes de la cadena y se coloca la expresión entre llaves `{}` dentro de la cadena.

**Sintaxis**:
```csharp
$"Texto aquí {expresión}"
```

**Ejemplo**:
```csharp
int age = 25;
string name = "John";
string greeting = $"Hola, {name}. Tienes {age} años.";
Console.WriteLine(greeting);  // Output: Hola, John. Tienes 25 años.
```

## 2. **Ventajas de la Interpolación**
- **Legibilidad**: Las cadenas interpoladas son mucho más fáciles de leer y entender que las cadenas concatenadas.
- **Menos errores**: No necesitas preocuparte por el orden o la cantidad de símbolos de concatenación.

**Ejemplo comparando con concatenación tradicional**:
```csharp
string greeting = "Hola, " + name + ". Tienes " + age + " años."; // Concatenación tradicional
```

## 3. **Expresiones Dentro de la Interpolación**
Puedes incluir cualquier expresión válida dentro de las llaves, como llamadas a métodos, cálculos, conversiones de tipo, etc.

**Ejemplo**:
```csharp
double price = 19.99;
int quantity = 3;
string message = $"El total es: {price * quantity}"; // Expresión dentro de la interpolación
Console.WriteLine(message);  // Output: El total es: 59.97
```

## 4. **Formato de Cadenas**
Se puede formatear las expresiones dentro de la interpolación utilizando especificadores de formato, como `C` para moneda, `D` para números enteros, `F` para decimales, etc.

**Ejemplo**:
```csharp
double pi = 3.14159;
string formattedPi = $"El valor de pi es: {pi:F2}"; // Formato con dos decimales
Console.WriteLine(formattedPi);  // Output: El valor de pi es: 3.14
```

## 5. **Interpolación Multilínea**
La interpolación también se puede usar con cadenas de varias líneas utilizando comillas triples (`"""`).

**Ejemplo**:
```csharp
string multiline = $"""
    Nombre: {name}
    Edad: {age}
    Saludo: ¡Bienvenido!
    """;
Console.WriteLine(multiline);
```

## 6. **Uso de `@` para Cadenas Literales de varias líneas**
Cuando se desea preservar el formato de la cadena, incluyendo saltos de línea y espacios, se puede usar la combinación `@$`.

**Ejemplo**:
```csharp
string path = @$"C:\Users\{name}\Documents"; 
Console.WriteLine(path);  // Output: C:\Users\John\Documents
```

---

## Resumen

### Operadores:
- **Aritméticos**: `+`, `-`, `*`, `/`, `%`
- **Relacionales**: `==`, `!=`, `>`, `<`, `>=`, `<=`
- **Lógicos**: `&&`, `||`, `!`
- **Asignación**: `=`, `+=`, `-=`, `*=`, `/=`, `%=` 
- **Incremento y Decremento**: `++`, `--`
- **Condicionales**: `? :`
- **Tipo**: `is`, `as`
- **Bit a bit**: `&`, `|`, `^`, `~`, `<<`, `>>`

### Interpolación de Cadenas:
- La interpolación de cadenas utiliza el `$` para insertar expresiones directamente dentro de una cadena.
- Permite una mayor legibilidad y facilidad de uso en comparación con la concatenación tradicional.
- Se pueden formatear números, fechas y otros valores dentro de la interpolación utilizando especificadores de formato.

Esto hace que C# sea más flexible y claro a la hora de manejar cadenas y operaciones, mejorando la experiencia de desarrollo.