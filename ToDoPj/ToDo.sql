USE [ToDo]
GO
/****** Object:  Table [dbo].[tToDo]    Script Date: 2020/5/25 下午 02:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tToDo](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fTitle] [nvarchar](50) NULL,
	[fImage] [nvarchar](50) NULL,
	[fDate] [date] NULL,
 CONSTRAINT [PK_tToDo] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
