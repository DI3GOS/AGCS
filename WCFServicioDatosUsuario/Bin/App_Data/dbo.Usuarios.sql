<<<<<<< HEAD
﻿CREATE TABLE [dbo].[Usuarios] (
    [id_usuario] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]     VARCHAR (255) DEFAULT (NULL) NULL,
    [apellido]   VARCHAR (255) DEFAULT (NULL) NULL,
    [rol]        VARCHAR (30)  NOT NULL,
    [login] VARCHAR(60) NOT NULL, 
    [clave] VARCHAR(50) NOT NULL DEFAULT (NULL), 
    PRIMARY KEY CLUSTERED ([id_usuario] ASC),
    CHECK ([rol]='Estudiante' OR [rol]='Docente' OR [rol]='Administrador')
);

=======
﻿CREATE TABLE [dbo].[Usuarios] (
    [id_usuario] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]     VARCHAR (255) DEFAULT (NULL) NULL,
    [apellido]   VARCHAR (255) DEFAULT (NULL) NULL,
    [rol]        VARCHAR (30)  NOT NULL,
    [login] VARCHAR(60) NOT NULL, 
    [clave] VARCHAR(50) NOT NULL DEFAULT (NULL), 
    PRIMARY KEY CLUSTERED ([id_usuario] ASC),
    CHECK ([rol]='Estudiante' OR [rol]='Docente' OR [rol]='Administrador')
);

>>>>>>> 2ccf1ddfa05b5b9f1a5fc9cd728554ee4c604d11
