# readme Gestion deudas backend
## Introduccion 

**Backend para la gestion de deudas entre amigos. Esta api esta realizada en .net core 8**

**Instalaciones previas**

-Instalacion de .net core 8

-Potsgress

-Angular cli 17

**Conexion Base de datos**
Para poder conecetarse a la base de datos se necesita tener creada una base de datos y un usuario con permisos de escritura y lectura

**sugerencia para base de datos**

-pgAdmin4

**Run Para correr Api**

Para correr la aplicacion se debe agregar la cadena de conexion dentro del archivo **appsettings.development** en el proyecto ApiGestionDeudas.Api
del proyecto presente. Cada de conexion sugerida : Host=localhost;Port=5432;Database=db_gestion_deudas;Username=su usuario de bd;Password=su contraseña

**Script para creacion de tablas**

-- Table: public.usuarios

-- DROP TABLE IF EXISTS public.usuarios;

CREATE TABLE IF NOT EXISTS public.usuarios
(
    id uuid NOT NULL,
    email text COLLATE pg_catalog."default" NOT NULL,
    pass_hash text COLLATE pg_catalog."default" NOT NULL,
    fecha_creacion timestamp with time zone NOT NULL DEFAULT now(),
    CONSTRAINT usuarios_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.usuarios
    OWNER to postgres;



    -- Table: public.deudas

-- DROP TABLE IF EXISTS public.deudas;

CREATE TABLE IF NOT EXISTS public.deudas
(
    id uuid NOT NULL,
    usuario_id uuid NOT NULL,
    total numeric(12,2) NOT NULL,
    estado integer NOT NULL DEFAULT 1,
    fecha_creacion timestamp with time zone NOT NULL DEFAULT now(),
    fecha_pago timestamp with time zone,
    CONSTRAINT deudas_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.deudas
    OWNER to postgres;

**Con esto ya podemos correr el api.**

**Para poder correr la aplicacion de front debemos ejecutar lo siguiente:**

- cd gestion-deudas
- ng serve --o (para que el proyecto quede corriendo)



