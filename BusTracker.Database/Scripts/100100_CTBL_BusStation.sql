IF NOT EXISTS (
	SELECT 1
	FROM [sys].[objects] o
	WHERE o.[object_id] = OBJECT_ID(N'[dbo].[busstation]')
		AND o.[type] = N'U'
	)
BEGIN

PRINT 'Creating Table [dbo].[busstation]'

CREATE TABLE [dbo].[busstation](
	 [id]					INT IDENTITY (1, 1) NOT NULL
	,[internal_place_id]	NVARCHAR (300) NOT NULL
	,[name]					NVARCHAR (300) NOT NULL
	,[location]				GEOMETRY NOT NULL
	,CONSTRAINT [pk_busstation] PRIMARY KEY CLUSTERED ([id] ASC)
)

END

GO