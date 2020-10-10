CREATE TABLE [dbo].[SmsMessages]
(
	[SmsMessagesId] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[MessageContent] [varchar](2000) NULL,
	[Result] [int] NULL,
	[DateAdded] [datetime] NULL,
	[DateSent] [datetime] NULL,
	[ResponseDate] [datetime] NULL, 
    CONSTRAINT [PK_Messages] PRIMARY KEY ([SmsMessagesId])
)

GO

ALTER TABLE [dbo].[SmsMessages] ADD  CONSTRAINT [DF_Message_Result]  DEFAULT ((0)) FOR [Result]
GO

ALTER TABLE [dbo].[SmsMessages] ADD  CONSTRAINT [DF_Message_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
