CREATE VIEW V_REPGEN
AS 
SELECT
	a.idequipo
	, b.marca
	, b.serial
	, a.idusuario
	, c.nombre
	, c.numdoc
	, c.telefono
	, c.direccion
	, a.idlugar
	, d.nombrelugar
	, a.idestado
	, e.estado
	, a.fecentrada
	, a.fecsalida
FROM 
	historiaequipo AS a
INNER JOIN 
	Equipo AS b
ON 
	a.idequipo= b.idequipo
INNER JOIN 
	usuario AS c
ON 
	c.idusuario=a.idusuario
INNER JOIN 
	lugar AS d
ON 
	d.idlugar=a.idlugar
INNER JOIN 
	estado AS e
ON 
	e.idestado=a.idestado	