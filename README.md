# 💰 Subsistema Contable de Conciliación Bancaria | C#  

Un **subsistema contable** desarrollado en **C# con SQL Server**, diseñado para **automatizar y optimizar la conciliación bancaria**. Permite **gestionar cuentas bancarias, transacciones internas y generar reportes contables** de manera eficiente y precisa.  

![Pasted image 20250202175210](https://github.com/user-attachments/assets/63a782cc-0d6a-42d1-85c6-fc5552e133f9)


---

## 🚀 Características Principales  
✔ **Gestión de bancos y cuentas bancarias** 🏦  
✔ **Registro de transacciones internas (débito/crédito)** 🔄  
✔ **Conciliación bancaria automática** 📊  
✔ **Detección de discrepancias en saldos** ⚠️  
✔ **Consultas y reportes avanzados** 📑  
✔ **Seguridad con control de usuarios y roles** 🔐  

---

## 🛠️ Tecnologías Utilizadas  
🔹 **C# (.NET Framework)** - Desarrollo de la aplicación  
🔹 **SQL Server** - Almacenamiento de datos  
🔹 **Entity Framework** - Manejo de base de datos  
🔹 **Windows Forms (WinForms)** - Interfaz de usuario  
🔹 **Crystal Reports** - Generación de reportes  

---

## 📂 Estructura del Proyecto  
```
📂 Subsistema-Conciliacion-Bancaria/
│── 📂 DataAccess/         # Conexión y manejo de base de datos  
│── 📂 UI/                 # Interfaz gráfica (Windows Forms)  
│── 📂 Reports/            # Generación de reportes contables  
│── 📜 Program.cs          # Archivo principal de ejecución  
│── 📜 Banco.cs            # Modelo de bancos y organizaciones  
│── 📜 CuentaBancaria.cs   # Modelo de cuentas bancarias  
│── 📜 Transaccion.cs      # Modelo de transacciones internas  
│── 📜 Conciliacion.cs     # Lógica de conciliación bancaria  
│── 📜 app.config          # Configuración de la aplicación  
│── 📜 conciliacion.sql    # Script de la base de datos  
```

---

## 🔢 Base de Datos  
📌 **Entidades Principales:**  
- **Bancos y Organizaciones**: Registra las instituciones bancarias.  
- **Cuentas Bancarias**: Almacena información de cuentas por banco.  
- **Transacciones Internas**: Guarda registros de ingresos y egresos.  
- **Conciliación Bancaria**: Compara los saldos bancarios vs. contables.  
- **Usuarios y Roles**: Control de acceso y permisos.  

📌 **Proceso de Conciliación:**  
1️⃣ **Obtener los saldos bancarios** desde las cuentas registradas.  
2️⃣ **Calcular los saldos contables** a partir de las transacciones internas.  
3️⃣ **Comparar los saldos** y detectar diferencias.  
4️⃣ **Registrar la conciliación** y generar reportes de discrepancias.  

---

## 📊 Módulos del Sistema  
🔹 **Mantenimiento**  
   - Bancos y Organizaciones  
   - Cuentas Bancarias  
   - Transacciones Internas  
   - Usuarios y Empresas  
   - Catálogos  

🔹 **Proceso**  
   - Conciliación Bancaria  

🔹 **Consultas y Reportes**  
   - Reporte de conciliación bancaria  
   - Reporte de transacciones no conciliadas  
   - Reporte de discrepancias en saldos  

---

## 📥 Instalación y Uso  
1️⃣ **Clonar el repositorio:**  
```bash
git clone https://github.com/tu-usuario/subsistema-conciliacion.git
```
2️⃣ **Configurar la base de datos en SQL Server:**  
- Importar `conciliacion.sql` en SQL Server.  
- Configurar la cadena de conexión en `app.config`.  

3️⃣ **Ejecutar el proyecto en Visual Studio** (`F5`).  
4️⃣ **Acceder al módulo de conciliación bancaria** y gestionar transacciones.  

---

## 🔍 Código Destacado: Conciliación Bancaria  
```csharp
public void ConciliarCuenta(int cuentaID)
{
    var saldoBancario = ObtenerSaldoBancario(cuentaID);
    var saldoContable = ObtenerSaldoContable(cuentaID);
    var diferencia = saldoContable - saldoBancario;

    RegistrarConciliacion(cuentaID, saldoContable, saldoBancario, diferencia);
}
```

---

## 🏗️ Futuras Mejoras  
✔ Implementación de interfaz web con **ASP.NET** 🌐  
✔ Integración con API bancaria para validación en tiempo real 🔗  
✔ Generación automática de alertas y notificaciones ⚡  

---

## 📜 Licencia  
Este proyecto está bajo la licencia **MIT**, puedes modificarlo y adaptarlo libremente.  

📌 **¡Optimiza la conciliación bancaria con este poderoso sistema contable!** 🚀 
