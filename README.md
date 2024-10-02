# Prueba Técnica ArcGIS

Este proyecto es una prueba técnica para demostrar la integración con el ArcGIS REST API, permitiendo realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre las entidades "Mejoras" y "Construcciones" en una base de datos geográfica.

## Descripción

El proyecto consiste en una API desarrollada en .NET, que interactúa con el ArcGIS REST API para gestionar entidades espaciales en un servidor de ArcGIS. El API incluye protección mediante JWT para la autenticación y autorización de las operaciones. Además, el proyecto contiene una interfaz ArcGis Maps SDK .NET WPF App(Esri) que permite interactuar con el API, visualizar la geometría de las entidades y ejecutar operaciones de edición y eliminación.

## Características

- **Operaciones CRUD**: Implementa las cuatro operaciones CRUD (Create, Read, Update, Delete) para las entidades `Mejora` y `Construcción` usando el ArcGIS REST API; pero del CRUD solo estamos haciendo UD (Update, Delete).
- **Autenticación con JWT**: El API está protegido con tokens JWT, los cuales son requeridos para acceder a las operaciones protegidas.
- **Visualización de geometría**: La aplicación permite cargar servicios de ArcGIS y visualizar la geometría de las entidades en un pop-up.
- **Edición y eliminación**: Desde la interfaz ArcGis Maps SDK .NET WPF App(Esri), es posible editar o eliminar `Mejoras` y `Construcciones` existentes.

## Requisitos

- .NET SDK 7.0 o superior
- ArcGIS REST API
- ArcGis Maps SDK .NET WPF App(Esri) Template
- Visual Studio 2022 o superior
- Un servidor ArcGIS configurado para recibir solicitudes POST para la actualización y eliminación de entidades.

## Instalación

1. Clona el repositorio en tu máquina local:
   git clone https://github.com/darioingenierosistemas/PruebaTecnicaArcGIS.git

2. Restaura los paquetes de NuGet: dotnet restore

3. Ejecuta la aplicación: dotnet run

## Datos para probar

- Usuario: @Dario
- Constraseña: Esri1234
- Mapa: El mapa se encuentra centrado en unas coordenadas para poder probar las mejoras.
- Urls: En caso de haber que configurar alguna URL para los enpoinds, el la carpeta "Helpers" del Proyecto "PruebaTecnicaEsri" hay una clase llamada "Urls" que es donde se pueden editar las urls.
- Debug: Se debe configurar para correr los dos proyectos al mismo tiempo.

## Observaciones de la Prueba Tecnica e Inconvenientes

- **Observacion**: Se debe mencionar que para usar la API de ArcGis es necesario crear una cuenta y crear una clave de API para poder usarla, yo por ya haberla trabajado antes sabia que esto era necesario; pero una persona nueva hubiera tenido muchos inconvenientes. Como solo se estan pidiendo para la prueba los enpoint de Mejoras y Construccion, para solo esas capas se realizo el PopUp.

- **Inconvenientes**: El mayor inconveniente fue que se necesitaba era la informacion de Mejoras y Construcciones, para las cuales no se nos dieron unas coordenadas para buscar en el mapa, ya que las Mejoras para poder verlas se debe acercar bastante el mapa y me tomo bastante tiempo poder encontrar unas para hacer pruebas.
                      Otro inconveniente fue la falta de un Json modelo para poder mandar a los servicios de UpdateFeature y DeleteFeature que estaban en el servicio de ArcGis que se dio, debido a esto no pude realizar el Update o el Delete de manera satisfactoria.
