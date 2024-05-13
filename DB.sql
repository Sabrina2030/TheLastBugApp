CREATE DATABASE thelastbugdb;

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    PasswordHash VARCHAR(50) NOT NULL,
    Rol NUMERIC(1, 0) NOT NULL,
    FechaAlta DATE,
    FechaModificacion DATE
);

CREATE TABLE Paises (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Regiones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    PaisId INT NOT NULL,
    FOREIGN KEY (PaisId) REFERENCES Paises(Id)
);

CREATE TABLE Comunas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    RegionId INT NOT NULL,
    FOREIGN KEY (RegionId) REFERENCES Regiones(Id)
);

CREATE TABLE AyudasSociales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoAyuda VARCHAR(50) NOT NULL,
    Anio INT NOT NULL,
    ComunaId INT NOT NULL,
    UsuarioId INT NOT NULL,
    FechaAsignacion DATETIME NOT NULL,
    UNIQUE (UsuarioId, TipoAyuda, Anio),
    FOREIGN KEY (ComunaId) REFERENCES Comunas(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE Logs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Accion VARCHAR(255) NOT NULL,
    FechaHora DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Usuarios(Id)
);
