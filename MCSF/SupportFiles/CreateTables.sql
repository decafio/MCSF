CREATE TABLE [dbo].[AdditionalChildrens] (
    [ChildCount] [int] NOT NULL IDENTITY,
    [Multiplier] [decimal](5, 4) NOT NULL,
    CONSTRAINT [PK_dbo.AdditionalChildrens] PRIMARY KEY ([ChildCount])
)
CREATE TABLE [dbo].[GeneralCareSupports] (
    [SupportBracketId] [int] NOT NULL IDENTITY,
    [ChildCount] [smallint] NOT NULL,
    [BasePercent] [decimal](8, 2) NOT NULL,
    [BaseSupport] [decimal](18, 2) NOT NULL,
    [MarginalPercent] [decimal](5, 4) NOT NULL,
    [IncomeBracket_IncomeBracketId] [int],
    CONSTRAINT [PK_dbo.GeneralCareSupports] PRIMARY KEY ([SupportBracketId])
)
CREATE INDEX [IX_IncomeBracket_IncomeBracketId] ON [dbo].[GeneralCareSupports]([IncomeBracket_IncomeBracketId])
CREATE TABLE [dbo].[IncomeBrackets] (
    [IncomeBracketId] [int] NOT NULL IDENTITY,
    [IncomeMin] [int] NOT NULL,
    [IncomeMax] [int] NOT NULL,
    CONSTRAINT [PK_dbo.IncomeBrackets] PRIMARY KEY ([IncomeBracketId])
)
CREATE TABLE [dbo].[LowIncomeThresholds] (
    [LowIncomeThresholdId] [int] NOT NULL IDENTITY,
    [Amount] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LowIncomeThresholds] PRIMARY KEY ([LowIncomeThresholdId])
)
CREATE TABLE [dbo].[OrdinaryMedExps] (
    [ChildCount] [int] NOT NULL IDENTITY,
    [AnnualAmount] [decimal](18, 2) NOT NULL,
    [MonthlyAmount] [decimal](8, 2) NOT NULL,
    CONSTRAINT [PK_dbo.OrdinaryMedExps] PRIMARY KEY ([ChildCount])
)
CREATE TABLE [dbo].[TransitionAdjustments] (
    [TransitionAdjustmentId] [int] NOT NULL IDENTITY,
    [ChildCount] [smallint] NOT NULL,
    [Multiplier] [decimal](3, 2) NOT NULL,
    CONSTRAINT [PK_dbo.TransitionAdjustments] PRIMARY KEY ([TransitionAdjustmentId])
)
ALTER TABLE [dbo].[GeneralCareSupports] ADD CONSTRAINT [FK_dbo.GeneralCareSupports_dbo.IncomeBrackets_IncomeBracket_IncomeBracketId] FOREIGN KEY ([IncomeBracket_IncomeBracketId]) REFERENCES [dbo].[IncomeBrackets] ([IncomeBracketId])