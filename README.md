# CRUD Users API

Este proyecto es una API REST desarrollada con .NET 8 que utiliza SQLite como base de datos. Está diseñada para realizar operaciones de búsqueda optimizadas. La API está desplegada y accesible en la siguiente URL:

[https://tarea2arquitecturadesistemas.onrender.com](https://tarea2arquitecturadesistemas.onrender.com)

## Características

- **Framework**: .NET 8
- **Base de datos**: SQLite
- **Despliegue**: Render
- **Servicio principal**: CRUD de usuarios

## Requisitos

- **.NET SDK 8.0** o superior
- **SQLite** 
- **Render** (para el despliegue en la nube)

## Instalación

1. Clona el repositorio:

    ```bash
    git clone https://github.com/Frankoyusta/Tarea2_Arqui.git
    ```

2. Accede al directorio del proyecto:

    ```bash
    cd Tarea2_ArquiSistemas
    ```

3. Restaura las dependencias de NuGet:

    ```bash
    dotnet restore
    ```


4. Ejecuta la aplicación localmente:

    ```bash
    dotnet run
    ```

5. La API estará disponible en `https://localhost:5001` o `http://localhost:5000` o en cualquier puerto que salga en la terminal.

## Despliegue en Render

La API está desplegada en [Render](https://render.com) y puedes accederla en:

[https://tarea2arquitecturadesistemas.onrender.com](https://tarea2arquitecturadesistemas.onrender.com)

## Endpoints

### User Service

- `https://searchservice-1.onrender.com/api/Search/searchStudent/{keyboardEnter}`
- `https://searchservice-1.onrender.com/api/Search/searchByRestriction/{keyboardEnter}`
- `https://searchservice-1.onrender.com/api/Search/searchStudentByGrade/{min},{max}`

## Uso

Puedes utilizar herramientas como [Postman](https://www.postman.com/) o `curl` para interactuar con la API. Ejemplo de una solicitud GET:
