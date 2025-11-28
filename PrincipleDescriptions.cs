using System;

namespace SOLID101
{
    /// <summary>
    /// Proporciona descripciones detalladas de cada principio SOLID.
    /// </summary>
    public static class PrincipleDescriptions
    {
        public static void DisplayDetails(int principleIndex)
        {
            switch (principleIndex)
            {
                case 0:
                    DisplaySRP();
                    break;
                case 1:
                    DisplayOCP();
                    break;
                case 2:
                    DisplayLSP();
                    break;
                case 3:
                    DisplayISP();
                    break;
                case 4:
                    DisplayDIP();
                    break;
            }
        }

        private static void DisplaySRP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  SRP - Single Responsibility Principle                   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📖 QUÉ ES:");
            Console.WriteLine("Una clase debe tener una única razón para cambiar.");
            Console.WriteLine("Esto significa que una clase debe tener una sola responsabilidad.");
            Console.WriteLine();

            Console.WriteLine("❌ PROBLEMA SIN SRP:");
            Console.WriteLine("Una clase que valida usuarios, los persiste en BD y envía emails");
            Console.WriteLine("→ Cambia si cambia la lógica de validación");
            Console.WriteLine("→ Cambia si cambia el formato de persistencia");
            Console.WriteLine("→ Cambia si cambia el servidor de email");
            Console.WriteLine();

            Console.WriteLine("✅ SOLUCIÓN CON SRP:");
            Console.WriteLine("• UserValidator: Solo valida datos (1 responsabilidad)");
            Console.WriteLine("• UserRepository: Solo persiste datos (1 responsabilidad)");
            Console.WriteLine("• UserCreator: Orquesta ambas acciones (coordina responsabilidades)");
            Console.WriteLine();

            Console.WriteLine("💡 BENEFICIOS:");
            Console.WriteLine("✓ Código más mantenible y fácil de testear");
            Console.WriteLine("✓ Cambios aislados en una sola responsabilidad");
            Console.WriteLine("✓ Mayor reutilización de clases");
            Console.WriteLine("✓ Mejor claridad en la estructura del código");
        }

        private static void DisplayOCP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  OCP - Open/Closed Principle                             ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📖 QUÉ ES:");
            Console.WriteLine("El software debe estar ABIERTO para extensión");
            Console.WriteLine("pero CERRADO para modificación.");
            Console.WriteLine();

            Console.WriteLine("❌ PROBLEMA SIN OCP:");
            Console.WriteLine("Para agregar un nuevo formato de exportación (ej: XML),");
            Console.WriteLine("necesitas modificar la clase que gestiona exportaciones.");
            Console.WriteLine("→ Riesgo de romper funcionalidad existente");
            Console.WriteLine("→ Violación del principio 'Don't Modify Working Code'");
            Console.WriteLine();

            Console.WriteLine("✅ SOLUCIÓN CON OCP:");
            Console.WriteLine("• Clase base abstracta: FileExporter");
            Console.WriteLine("• Derivadas específicas: CsvFileExporter, JsonFileExporter, ExcelFileExporter");
            Console.WriteLine("• Agregar XML: Solo creas XmlFileExporter, SIN modificar código existente");
            Console.WriteLine();

            Console.WriteLine("💡 BENEFICIOS:");
            Console.WriteLine("✓ Nuevas funcionalidades sin riesgo");
            Console.WriteLine("✓ Código polimórfico y flexible");
            Console.WriteLine("✓ Extensión segura mediante herencia/interfaces");
            Console.WriteLine("✓ Facilita el testing de código nuevo");
        }

        private static void DisplayLSP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  LSP - Liskov Substitution Principle                     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📖 QUÉ ES:");
            Console.WriteLine("Las subclases deben poder sustituir a sus clases base");
            Console.WriteLine("sin romper la funcionalidad del programa.");
            Console.WriteLine();

            Console.WriteLine("❌ PROBLEMA SIN LSP:");
            Console.WriteLine("Ambas clases derivan de Vehicle, pero ElectricCar NO tiene motor.");
            Console.WriteLine("Si fuerzas a ElectricCar a implementar StartEngine():");
            Console.WriteLine("→ Viola el principio (no es sustituible en contextos que usan IEnginePowered)");
            Console.WriteLine("→ Código confuso: ¿qué hace StartEngine() en un auto eléctrico?");
            Console.WriteLine();

            Console.WriteLine("✅ SOLUCIÓN CON LSP:");
            Console.WriteLine("• Car: Implementa Vehicle + IEnginePowered");
            Console.WriteLine("• ElectricCar: Solo implementa Vehicle");
            Console.WriteLine("• Se usan como IEnginePowered solo cuando es apropiado");
            Console.WriteLine();

            Console.WriteLine("💡 BENEFICIOS:");
            Console.WriteLine("✓ Jerarquías de clases correctas y significativas");
            Console.WriteLine("✓ Código más predecible y menos sorpresas");
            Console.WriteLine("✓ Respeta contratos de interfaces");
            Console.WriteLine("✓ Polimorfismo seguro");
        }

        private static void DisplayISP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  ISP - Interface Segregation Principle                   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📖 QUÉ ES:");
            Console.WriteLine("Los clientes NO deben verse forzados a depender de");
            Console.WriteLine("interfaces que no utilizan.");
            Console.WriteLine();

            Console.WriteLine("❌ PROBLEMA SIN ISP:");
            Console.WriteLine("Una interfaz gigante: IOrder con métodos de email, factura, etiqueta");
            Console.WriteLine("→ OnlineOrder debe implementar PrintLabel() (no lo necesita)");
            Console.WriteLine("→ InStoreOrder debe implementar SendEmail() (no lo necesita)");
            Console.WriteLine("→ Acoplamiento innecesario");
            Console.WriteLine();

            Console.WriteLine("✅ SOLUCIÓN CON ISP:");
            Console.WriteLine("• IEmailSender: SendConfirmationEmail()");
            Console.WriteLine("• IInvoiceGenerator: GenerateInvoice()");
            Console.WriteLine("• ILabelPrinter: PrintLabel()");
            Console.WriteLine("• OnlineOrder: Implementa IEmailSender + IInvoiceGenerator");
            Console.WriteLine("• InStoreOrder: Implementa ILabelPrinter");
            Console.WriteLine();

            Console.WriteLine("💡 BENEFICIOS:");
            Console.WriteLine("✓ Interfaces específicas y coherentes");
            Console.WriteLine("✓ Las clases solo implementan lo que necesitan");
            Console.WriteLine("✓ Menor acoplamiento");
            Console.WriteLine("✓ Código más flexible y reutilizable");
        }

        private static void DisplayDIP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  DIP - Dependency Inversion Principle                    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📖 QUÉ ES:");
            Console.WriteLine("Los módulos de alto nivel NO deben depender de módulos de bajo nivel.");
            Console.WriteLine("Ambos deben depender de abstracciones (interfaces).");
            Console.WriteLine();

            Console.WriteLine("❌ PROBLEMA SIN DIP:");
            Console.WriteLine("UserController depende directamente de la clase Database.");
            Console.WriteLine("→ Si cambias de BD a File Storage, debes modificar UserController");
            Console.WriteLine("→ Acoplamiento fuerte entre módulos");
            Console.WriteLine("→ Difícil de testear (no puedes usar mocks fácilmente)");
            Console.WriteLine();

            Console.WriteLine("✅ SOLUCIÓN CON DIP:");
            Console.WriteLine("• UserController depende de IDataStorage (abstracción)");
            Console.WriteLine("• Database implementa IDataStorage");
            Console.WriteLine("• Puedes cambiar a cualquier almacenamiento sin tocar UserController");
            Console.WriteLine();

            Console.WriteLine("💡 BENEFICIOS:");
            Console.WriteLine("✓ Código desacoplado y flexible");
            Console.WriteLine("✓ Fácil cambiar implementaciones sin recompilar");
            Console.WriteLine("✓ Testing simplificado (inyecta mocks)");
            Console.WriteLine("✓ Arquitectura escalable y mantenible");
        }
    }
}
