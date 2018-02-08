CREATE TABLE [dbo].[Log]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY, 
    [CreatedOn] DATETIME NOT NULL DEFAULT getdate(), 
    [ModifiedOn] DATETIME NOT NULL DEFAULT getdate(), 
    [Exception] NCHAR(45) NULL , 
    [Event] NVARCHAR(MAX) NULL, 
    [Details] NVARCHAR(MAX) NULL
)

GO


CREATE TRIGGER [dbo].[Modified]
    ON [dbo].[Log]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
	    SET NOCOUNT ON;
        Update Log
		Set ModifiedOn = getdate()
		FROM [dbo].[Log] T
		JOIN inserted i ON T.id = i.id
    END