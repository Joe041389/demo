USE [Customer]
GO
/****** Object:  Table [dbo].[tCustomer]    Script Date: 2020/5/28 下午 02:23:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCustomer](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fName] [nvarchar](50) NULL,
	[fPhone] [nvarchar](50) NULL,
	[fEmail] [nvarchar](50) NULL,
	[fAddress] [nvarchar](100) NULL,
 CONSTRAINT [PK_tCustomer] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
