IF NOT EXISTS (
	SELECT 1
	FROM [sys].[objects] o
	WHERE o.[object_id] = OBJECT_ID(N'[dbo].[vehicle]')
		AND o.[type] = N'U'
	)
BEGIN

PRINT 'Creating Table [dbo].[vehicle]'

CREATE TABLE [dbo].[vehicle](
	 [id]					INT IDENTITY (1, 1) NOT NULL
	,[tracking_device_id]	INT NOT NULL
	,[route_id]				INT NOT NULL
	,[brand]				NVARCHAR (100) NOT NULL
	,[quality]				TINYINT NULL
	,[has_low_landing]		BIT NULL
	,[has_hinge_connection]	BIT NULL
	,[has_climate_control]	BIT NULL
	,[has_payment_device]	BIT NULL
	,CONSTRAINT [pk_vehicle] PRIMARY KEY CLUSTERED ([id] ASC)
)

END

GO