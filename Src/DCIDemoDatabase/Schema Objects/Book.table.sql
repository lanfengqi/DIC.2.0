CREATE TABLE [dbo].[Book]
(
	[Id] [varchar](50) NOT NULL,
	[BookName] [varchar](50) NULL,
	[Author] [varchar](50) NULL,
	[Publisher] [varchar](50) NULL,
	[ISBN] [varchar](50) NULL,
	[Description] [varchar](50) NULL,CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

