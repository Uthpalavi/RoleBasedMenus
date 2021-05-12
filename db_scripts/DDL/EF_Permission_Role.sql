USE [EFRole]
GO

/****** Object:  Table [dbo].[EF_Permission_Role]    Script Date: 5/12/2021 6:16:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EF_Permission_Role](
	[permission_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_EF_Permission_Role] PRIMARY KEY CLUSTERED 
(
	[permission_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EF_Permission_Role]  WITH CHECK ADD  CONSTRAINT [FK_EF_Permission_Role_EF_Permission] FOREIGN KEY([permission_id])
REFERENCES [dbo].[EF_Permission] ([id])
GO

ALTER TABLE [dbo].[EF_Permission_Role] CHECK CONSTRAINT [FK_EF_Permission_Role_EF_Permission]
GO

ALTER TABLE [dbo].[EF_Permission_Role]  WITH CHECK ADD  CONSTRAINT [FK_EF_Permission_Role_EF_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[EF_Role] ([id])
GO

ALTER TABLE [dbo].[EF_Permission_Role] CHECK CONSTRAINT [FK_EF_Permission_Role_EF_Role]
GO


