# Tablas Oracle - DAE2026

```sql
CREATE TABLE COMPUTADOR (
    codigo              NUMBER PRIMARY KEY,
    marca               VARCHAR2(100) NOT NULL,
    fechaFabricacion    TIMESTAMP NOT NULL,
    estado              VARCHAR2(50) NOT NULL,
    portatil            NUMBER(1) DEFAULT 0 NOT NULL CHECK (portatil IN (0,1)),
    costoMantenimiento  NUMBER(10,2) CHECK (costoMantenimiento >= 0),
    activo              NUMBER(1) DEFAULT 1 NOT NULL CHECK (activo IN (0,1))
);

CREATE TABLE PERIFERICO (
    id                  NUMBER PRIMARY KEY,
    nombre              VARCHAR2(100) NOT NULL,
    tipo                VARCHAR2(50) NOT NULL,
    activo              NUMBER(1) DEFAULT 1 NOT NULL CHECK (activo IN (0,1)),
    computador_codigo   NUMBER NOT NULL,
    CONSTRAINT fk_periferico_computador
        FOREIGN KEY (computador_codigo)
        REFERENCES COMPUTADOR(codigo)
);

CREATE TABLE SOFTWARE (
    id                  NUMBER PRIMARY KEY,
    codigo_computador   NUMBER NOT NULL,
    nombre              VARCHAR2(150) NOT NULL,
    version             VARCHAR2(50) NOT NULL,
    tipo                VARCHAR2(80) NOT NULL,
    precio              NUMBER(10,2) NOT NULL CHECK (precio >= 0),
    fecha_instalacion   TIMESTAMP NOT NULL,
    activo              NUMBER(1) DEFAULT 1 NOT NULL CHECK (activo IN (0,1))
);

```
