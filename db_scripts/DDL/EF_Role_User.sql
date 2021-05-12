USE [EFRole]
GO

/****** Object:  Table [dbo].[EF_Role_User]    Script Date: 5/12/2021 6:16:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EF_Role_User](
	[role_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_EF_Role_User] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EF_Role_User]  WITH CHECK ADD  CONSTRAINT [FK_EF_role_user_EF_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[EF_Role] ([id])
GO

ALTER TABLE [dbo].[EF_Role_User] CHECK CONSTRAINT [FK_EF_role_user_EF_Role]
GO

ALTER TABLE [dbo].[EF_Role_User]  WITH CHECK ADD  CONSTRAINT [FK_EF_role_user_EF_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[EF_User] ([id])
GO

ALTER TABLE [dbo].[EF_Role_User] CHECK CONSTRAINT [FK_EF_role_user_EF_User]
GO


