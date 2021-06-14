#  UNLa Library

Sitio web de gestión de material de estudio universitario

### Vista Previa

![Captura](https://i.ibb.co/DWYvWSM/Captura-de-pantalla-28.png)

## Comenzando 🚀

Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo o pruebas.

### Pre-requisitos 📋

 - SQL Server
 - Visual Studio con los paquetes de NET CORE y C# instalados
 - Microsoft SQL Server Managment Studio
 
### Instalación 🔧

Una vez descargado el proyecto y abierto como solución con Visual Studio verificar que la cadena de conexión a la base de datos del proyecto coincida con el nombre del servidor instalado en su computadora. Si desea puede cambiar el nombre del servidor en la cadena de conexión del proyecto la cual está ubicada en _UnlaLibrary.UI.Web/appsettings.json_ y en _ConsoleApp1/Context.cs_ para que coincida con el de su computadora. O bien cambiar el nombre del servidor local a _DESKTOP-FOMFU6L_

> Correr el proyecto de inicio _UnlaLibrary.UI.WEB_ para que corra los scripts de la base de datos, creandola e insertandole los datos.
 
> Correr el proyecto _ConsoleApp1_ para que cargue los materiales de estudio

> Volver a correr _UNLaLibrary.UI.Web_ y ya se tendrá el programa corriendo con todos los datos cargados

Accede al puerto [5001](http://localhost:5001) para ver el sitio web corriendo de manera local

## Construido con 🛠️

- Net Core
- SQL Server
- Jquery

### Autores ✒️

- [Nehuen Verges](https://github.com/NehuenV)
- [Cristian Villafañe](https://github.com/gazapus)

--- 
💯
