create proc insertar_usuario

-- se puede insertar el as para declarar los datos o no, no es obligatorio -->

@Usuario as varchar(MAX),
@Pass varchar(MAX),
@Icono image,
@Estado varchar(MAX)
as 
if Exists (Select Usuario from Usuarios where Usuario= @Usuario)
Raiserror('Usuario ya registrado',16,1)
else
insert into Usuarios
values(@Usuario, @Pass, @Icono, @Estado)


create proc mostrar_usuarios
as
SELECT * FROM Usuarios

exec mostrar_usuarios


-- Procedimiento de Editar --
create proc editar_usuarios
@id_Usuario int,
@Usuario as varchar(MAX),
@Pass varchar(MAX),
@Icono image,
@Estado varchar(MAX)
as
if EXISTS(SELECT Usuario from Usuarios Where Usuario = @Usuario AND Id_Usuario <>@id_Usuario )
RAISERROR('Usuario en uso, usa otro nombre de Usuario por favor', 16,1)
else
update Usuarios set Usuario=@Usuario, Pass=@Pass, Icono=@Icono, Estado=@Estado
Where Id_Usuario= @id_Usuario


use CAPAS_USUARIOS

create proc eliminar_usuario
@Id_Usuario int
as
delete from Usuarios where Id_Usuario=@Id_Usuario

create proc buscar_usuarios
@buscador varchar(50)
as
select * from Usuarios
where Usuario+Pass LIKE '%' + @buscador + '%'

exec buscar_usuarios e