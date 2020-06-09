ALTER PROCEDURE PA_INS_HISEQUI(@idequi INT ,@idusu INT,@idlug INT ,@idedo INT, @evento VARCHAR(20), @fecentradan DATETIME, @fecsalida DATETIME)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 
	 -- SI es una entrada lo dejo activo con estado 0
	IF(@evento='Entrada')
	BEGIN

		-- actualizo los estados anteriores 
		UPDATE
			historiaequipo
		SET 
			activo=1
		WHERE 
			idequipo=@idequi
			
		INSERT INTO historiaequipo (idequipo,idusuario,idlugar,idestado,fecentrada,fecsalida,activo)
		VALUES (@idequi,@idusu,@idlug,@idedo,@fecentradan,@fecsalida,0)		
	END
	ELSE
	BEGIN 			
	
	DECLARE @usoequi AS INT;
	
	-- verifico que el equipo no este en uso
	SELECT 
	      @usoequi=COUNT(*)
	FROM 
		historiaequipo
	WHERE 
		idequipo=@idequi
	AND 
		idestado=7
	AND 
		activo=0
	
		-- si el elemento ya fue asignado no lo debe dejar pasar
		IF(@usoequi=1)
		BEGIN 
		     SELECT 'El equipo ya fue asignado' AS coderror
		END 
		ELSE
		BEGIN
			INSERT INTO historiaequipo (idequipo,idusuario,idlugar,idestado,fecentrada,fecsalida,activo)
			VALUES (@idequi,@idusu,@idlug,@idedo,@fecentradan,@fecsalida,1)			
		END 

	END 
		
END