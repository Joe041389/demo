USE [Demo]
GO
/****** Object:  Table [dbo].[dt]    Script Date: 2020/5/7 下午 01:34:00 ******/
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
/****** Object:  Table [dbo].[dt_value]    Script Date: 2020/5/7 下午 01:34:25 ******/
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
/****** Object:  StoredProcedure [dbo].[add_dt]    Script Date: 2020/5/7 下午 01:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_dt]    
(    
	@dt datetime
)    
As 
DECLARE @CountItems int   
Begin 
 
SELECT @CountItems = Count(id) FROM dt WHERE dt=@dt;
IF @CountItems = 0 
	Insert into dbo.dt(dt) values(@dt) select SCOPE_IDENTITY() as id;
End  
GO
/****** Object:  StoredProcedure [dbo].[add_dt_value]    Script Date: 2020/5/7 下午 01:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[add_dt_value]    
(    
    @dt_id int,
	@location_code nvarchar(10),
	@location_value float
)    
As  
Begin 
 
	Insert into dt_value(dt_id,location_code,location_value) values(@dt_id,@location_code,@location_value);
End  
GO
