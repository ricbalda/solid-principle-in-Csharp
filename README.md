# SOLID principle in C#
This repository provides a comprehensive guide and practical examples of implementing the SOLID principles in C#. SOLID is an acronym for five design principles intended to make software designs more understandable, flexible, and maintainable. The principles are:

1.	**Single Responsibility Principle (SRP):** A class should have only one reason to change, meaning it should only have one job or responsibility.
2.	**Open/Closed Principle (OCP):** Software entities should be open for extension but closed for modification.
3.	**Liskov Substitution Principle (LSP):** Objects in a program should be replaceable with instances of their subtypes without altering the correctness of the program.
4.	**Interface Segregation Principle (ISP):** Clients should not be forced to depend on interfaces they do not use.
5.	**Dependency Inversion Principle (DIP):** High-level modules should not depend on low-level modules. Both should depend on abstractions.


Esta aplicación es un proyecto educativo en C# diseñado para demostrar y enseñar los Principios SOLID del diseño de software. No es una aplicación funcional única (como una web o una herramienta de escritorio), sino más bien una colección de ejemplos de código que ilustran cómo escribir código limpio, mantenible y escalable.

Aquí tienes un desglose de lo que hace cada parte del proyecto basándome en los archivos que contiene:

1. SRP - Principio de Responsabilidad Única (Single Responsibility Principle)
En la carpeta SRP, el código separa la lógica de gestión de usuarios en diferentes clases, en lugar de tener una sola clase "Dios" que lo haga todo.

Lo que hace: Divide la creación de usuarios en:
UserValidator.cs
: Se encarga solo de validar los datos del usuario.
UserRepository.cs
: Se encarga solo de guardar/leer datos (probablemente base de datos).
UserCreator.cs
: Orquesta el proceso usando las otras dos clases.
2. OCP - Principio de Abierto/Cerrado (Open/Closed Principle)
En la carpeta OCP, se muestra un sistema de exportación de archivos.

Lo que hace: Permite exportar datos a diferentes formatos (CsvFileExporter, ExcelFileExporter, JsonFileExporter).
El punto clave: Si quieres agregar un nuevo formato (por ejemplo, PDF), puedes crear una nueva clase sin tener que modificar el código existente de FileExporter, cumpliendo con estar "abierto a la extensión pero cerrado a la modificación".
3. LSP - Principio de Sustitución de Liskov (Liskov Substitution Principle)
En la carpeta LSP, se modelan vehículos.

Lo que hace: Trata el problema de la herencia con Car (Coche) y ElectricCar (Coche Eléctrico).
El ejemplo: Muestra cómo manejar comportamientos específicos (como IEnginePowered para motores de combustión) para evitar que un coche eléctrico se vea forzado a implementar métodos que no tienen sentido para él (como "Arrancar Motor" de combustión), asegurando que las subclases puedan sustituir a las clases base sin romper el programa.
4. ISP - Principio de Segregación de la Interfaz (Interface Segregation Principle)
En la carpeta ISP, se gestionan pedidos.

Lo que hace: Divide una interfaz grande de pedidos en interfaces más pequeñas y específicas (IEmailSender, IInvoiceGenerator, ILabelPrinter).
El beneficio: Diferencia entre OnlineOrder (Pedido Online) e InStoreOrder (Pedido en Tienda). Un pedido en tienda no necesita métodos de envío o impresión de etiquetas de correo, por lo que este diseño evita que dependa de interfaces que no usa.
