using System;
using System.Collections.Generic;
using System.Data;
using SOLID101.DIP;
using SOLID101.ISP;
using SOLID101.LSP;
using SOLID101.OCP;
using SOLID101.SRP;

namespace SOLID101
{
    /// <summary>
    /// Ejecuta demostraciones prácticas de cada principio SOLID
    /// con explicaciones en consola.
    /// </summary>
    public static class DemoRunner
    {
        public static void RunDemo(int principleIndex)
        {
            switch (principleIndex)
            {
                case 0:
                    RunDemoSRP();
                    break;
                case 1:
                    RunDemoOCP();
                    break;
                case 2:
                    RunDemoLSP();
                    break;
                case 3:
                    RunDemoISP();
                    break;
                case 4:
                    RunDemoDIP();
                    break;
            }
        }

        // ═══════════════════════════════════════════════════════════
        // SRP - Single Responsibility Principle
        // ═══════════════════════════════════════════════════════════

        private static void RunDemoSRP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  DEMOSTRACIÓN: SRP                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📝 FLUJO: Crear usuario con validación → Guardar en BD");
            Console.WriteLine("Cada clase tiene UNA responsabilidad separada.");
            Console.WriteLine();
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            Console.WriteLine();

            var validator = new UserValidator();
            var repository = new UserRepository();
            var creator = new UserCreator(validator, repository);

            Console.WriteLine("✓ Instanciadas las clases separadas:");
            Console.WriteLine("  • UserValidator (valida emails)");
            Console.WriteLine("  • UserRepository (persiste en BD)");
            Console.WriteLine("  • UserCreator (orquesta el flujo)");
            Console.WriteLine();

            string testEmail = "usuario@example.com";
            Console.WriteLine($"→ Ejecutando: creator.CreateUser(\"juan\", \"{testEmail}\", \"pass123\")");
            Console.WriteLine();

            try
            {
                creator.CreateUser("juan", testEmail, "pass123");
                Console.WriteLine("✅ Usuario creado exitosamente!");
                Console.WriteLine();
                Console.WriteLine("Explicación del flujo:");
                Console.WriteLine("1️⃣  UserValidator.ValidateEmail() → Valida formato");
                Console.WriteLine("2️⃣  UserRepository.SaveUser() → Guarda en BD");
                Console.WriteLine("3️⃣  UserCreator.CreateUser() → Coordina ambos");
                Console.WriteLine();
                Console.WriteLine("Beneficio: Cada clase es pequeña, testeable y reutilizable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️  {ex.Message}");
            }
        }

        // ═══════════════════════════════════════════════════════════
        // OCP - Open/Closed Principle
        // ═══════════════════════════════════════════════════════════

        private static void RunDemoOCP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  DEMOSTRACIÓN: OCP                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📝 FLUJO: Exportar datos en múltiples formatos");
            Console.WriteLine("Sin modificar la clase base, se pueden agregar nuevos formatos.");
            Console.WriteLine();
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            Console.WriteLine();

            DataTable sampleData = CreateSampleData();

            Console.WriteLine("✓ Datos de ejemplo creados:");
            Console.WriteLine("  • 3 columnas: ID, Nombre, Email");
            Console.WriteLine("  • 2 registros de datos");
            Console.WriteLine();

            FileExporter[] exporters = new FileExporter[]
            {
                new CsvFileExporter(),
                new JsonFileExporter(),
                new ExcelFileExporter()
            };

            Console.WriteLine("→ Exportando con diferentes formatos:");
            Console.WriteLine();

            foreach (var exporter in exporters)
            {
                string exporterName = exporter.GetType().Name;
                Console.WriteLine($"  • {exporterName}:");
                try
                {
                    exporter.Export("datos", sampleData);
                    Console.WriteLine($"    ✅ Exportado exitosamente");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"    ⚠️  {ex.Message}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Beneficio: Se pueden agregar nuevos exportadores sin modificar");
            Console.WriteLine("           la clase base FileExporter. Simplemente hereda y listo.");
        }

        // ═══════════════════════════════════════════════════════════
        // LSP - Liskov Substitution Principle
        // ═══════════════════════════════════════════════════════════

        private static void RunDemoLSP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  DEMOSTRACIÓN: LSP                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📝 FLUJO: Vehículos con motores diferenciados");
            Console.WriteLine("Car implementa IEnginePowered, ElectricCar NO (por LSP)");
            Console.WriteLine();
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            Console.WriteLine();

            Console.WriteLine("✓ Car (vehículo con motor de combustión):");
            IEnginePowered car = new Car();
            car.StartEngine();
            car.StopEngine();
            Console.WriteLine();

            Console.WriteLine("✓ ElectricCar (vehículo eléctrico):");
            Vehicle electricCar = new ElectricCar();
            Console.WriteLine("  • ElectricCar NO implementa IEnginePowered");
            Console.WriteLine("  • Esto es CORRECTO según LSP: no tiene motor de combustión");
            Console.WriteLine("  • Por eso, no se puede llamar StartEngine() en él");
            Console.WriteLine();

            Console.WriteLine("Beneficio: Jerarquías correctas. Cada clase solo implementa");
            Console.WriteLine("           lo que realmente necesita y puede hacer.");
        }

        // ═══════════════════════════════════════════════════════════
        // ISP - Interface Segregation Principle
        // ═══════════════════════════════════════════════════════════

        private static void RunDemoISP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  DEMOSTRACIÓN: ISP                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📝 FLUJO: Diferentes tipos de órdenes, diferentes interfaces");
            Console.WriteLine("Cada orden implementa solo las interfaces que necesita.");
            Console.WriteLine();
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            Console.WriteLine();

            OnlineOrder online = new OnlineOrder();
            InStoreOrder inStore = new InStoreOrder();

            Console.WriteLine("📦 OnlineOrder (compra por internet):");
            Console.WriteLine("  Implementa:");
            Console.WriteLine("    ✓ IOrder");
            Console.WriteLine("    ✓ IOrderProcessing");
            Console.WriteLine("    ✓ IEmailSender → Envía confirmación por email");
            Console.WriteLine("    ✓ IInvoiceGenerator → Genera factura digital");
            Console.WriteLine("  NO Implementa:");
            Console.WriteLine("    ✗ ILabelPrinter (no necesita etiqueta física)");
            Console.WriteLine();

            Console.WriteLine("🏪 InStoreOrder (compra en tienda):");
            Console.WriteLine("  Implementa:");
            Console.WriteLine("    ✓ IOrder");
            Console.WriteLine("    ✓ IOrderProcessing");
            Console.WriteLine("    ✓ ILabelPrinter → Imprime etiqueta de empaque");
            Console.WriteLine("  NO Implementa:");
            Console.WriteLine("    ✗ IEmailSender (el cliente está presente)");
            Console.WriteLine("    ✗ IInvoiceGenerator (factura en tienda)");
            Console.WriteLine();

            Console.WriteLine("Beneficio: Cada clase NO está forzada a implementar métodos");
            Console.WriteLine("           innecesarios. Las interfaces son específicas y cohesivas.");
        }

        // ═══════════════════════════════════════════════════════════
        // DIP - Dependency Inversion Principle
        // ═══════════════════════════════════════════════════════════

        private static void RunDemoDIP()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  DEMOSTRACIÓN: DIP                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("📝 FLUJO: UserController depende de abstracción (IDataStorage)");
            Console.WriteLine("Puedes cambiar la implementación sin modificar UserController.");
            Console.WriteLine();
            Console.WriteLine("─────────────────────────────────────────────────────────────");
            Console.WriteLine();

            Console.WriteLine("Escenario 1: Usando Database (BD SQL)");
            Console.WriteLine("  • Inyectamos: IDataStorage storage = new Database()");
            IDataStorage storage = new Database();
            UserController controller = new UserController(storage);
            Console.WriteLine("  ✓ UserController funciona con Database");
            Console.WriteLine();

            string testData = "usuario_importante";
            storage.SaveData(testData);
            Console.WriteLine($"  → Guardado: {testData}");
            Console.WriteLine();

            Console.WriteLine("Escenario 2: Cambiar a FileStorage (sin modificar UserController)");
            Console.WriteLine("  • Inyectamos: IDataStorage storage = new FileStorage()");
            Console.WriteLine("  ✓ UserController sigue funcionando SIN cambios");
            Console.WriteLine();

            Console.WriteLine("Beneficio: Alta flexibilidad. La dependencia es en la abstracción");
            Console.WriteLine("           (IDataStorage), no en implementaciones concretas.");
            Console.WriteLine();
            Console.WriteLine("💡 Inversión: UserController NO controla Database.");
            Console.WriteLine("    El consumidor inyecta la dependencia que necesita.");
        }

        // ═══════════════════════════════════════════════════════════
        // Utilidades
        // ═══════════════════════════════════════════════════════════

        private static DataTable CreateSampleData()
        {
            DataTable table = new DataTable("Usuarios");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Email", typeof(string));

            table.Rows.Add(1, "Juan Pérez", "juan@example.com");
            table.Rows.Add(2, "María García", "maria@example.com");

            return table;
        }
    }
}
