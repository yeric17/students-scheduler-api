# StudentScheduler

## Introducción

Bienvenido al proyecto **StudentScheduler**. Este proyecto está desarrollado en .NET y utiliza Entity Framework Core para manejar la base de datos. A continuación, se explican los pasos necesarios para configurar el entorno y realizar las migraciones de la base de datos.

---

## Configuración inicial

Antes de realizar cualquier acción, asegúrate de tener instalado lo siguiente en tu máquina:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) (opcional, para gestionar la base de datos)

---

## 1. Configurar la cadena de conexión

El proyecto utiliza una cadena de conexión para conectarse a la base de datos MySQL. Esta cadena puede configurarse de dos maneras:

### Opción 1: Usar User Secrets
1. Abre la terminal y navega al directorio del proyecto `StudentScheduler.WebAPI`.
2. Inicializa los User Secrets si aún no están configurados:
```bash
dotnet user-secrets init
```
```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=your_server;Database=your_database;User=your_user;Password=your_password;"
```
### Opción 1: Etitar el archivo appsettings.json
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=your_database;User=your_user;Password=your_password;"
}
```
## 2. Ejecutar la migración de la base de datos

Ejecuta el siguiente comando:
```bash
dotnet ef database update -p ./StudentScheduler.Infrastructure -s ./StudentScheduler.WebAPI
```

