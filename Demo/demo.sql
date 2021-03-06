USE [Demo]
GO
/****** Object:  Table [dbo].[dt]    Script Date: 2020/5/27 下午 10:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dt] [datetime] NULL,
 CONSTRAINT [PK_dt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[dt_value]    Script Date: 2020/5/27 下午 10:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_value](
	[dt_id] [int] NOT NULL,
	[location_code] [nvarchar](10) NULL,
	[location_value] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_image]    Script Date: 2020/5/27 下午 10:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](200) NULL,
 CONSTRAINT [PK_tb_image] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
