# Capa de persistencia:
Para el desarrollo del aplicativo se diseñó una capa de persistencia desacoplada, implementada como una librería independiente en .NET, cuyo propósito es centralizar y abstraer el acceso a datos. Esta librería encapsula todas las clases relacionadas con las entidades del dominio, así como su configuración y mapeo hacia la base de datos.

### Script de base de datos
create table Vehiculo(

	secuencial  int identity (1,1) not null,
	placa varchar(10) not null unique,
	detalle varchar(50) not null,
	fechaRegistro dateTime2 not null default GETDATE(),
	fechaActualiza dateTime2 null,
	activo bit not null default 'TRUE',
	usuarioRegistra varchar(10) not null,
	usuarioActualiza varchar(10) null,
	constraint  PK_Vehiculo primary key CLUSTERED  (secuencial)
)
go

create table Cita(
	secuencial int identity not null,
	fechaCita dateTime2 not null,
	descripcion varchar(500),
	secuencialVehiculo int not null,
	fechaRegistro dateTime2 not null default GETDATE(),
	fechaActualiza dateTime2  null,
	activo bit not null default 'TRUE',
	usuarioRegistra varchar(10) not null,
	usuarioActualiza varchar(10)  null,
	constraint PK_Cita primary key CLUSTERED  (secuencial),
	constraint FK_Cita_Vehiculo foreign key (secuencialVehiculo) references Vehiculo (secuencial)
)
go
