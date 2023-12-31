USE [master]
GO
/****** Object:  Database [FamilyDB]    Script Date: 8/28/2023 12:02:48 PM ******/
CREATE DATABASE [FamilyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FamilyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FamilyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FamilyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FamilyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FamilyDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FamilyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FamilyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FamilyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FamilyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FamilyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FamilyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FamilyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FamilyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FamilyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FamilyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FamilyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FamilyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FamilyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FamilyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FamilyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FamilyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FamilyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FamilyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FamilyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FamilyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FamilyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FamilyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FamilyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FamilyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FamilyDB] SET  MULTI_USER 
GO
ALTER DATABASE [FamilyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FamilyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FamilyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FamilyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FamilyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FamilyDB] SET QUERY_STORE = OFF
GO
USE [FamilyDB]
GO
/****** Object:  Table [dbo].[Applicant]    Script Date: 8/28/2023 12:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicant](
	[ApplicantId] [int] IDENTITY(1000,1) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Applicant] PRIMARY KEY CLUSTERED 
(
	[ApplicantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberDetails]    Script Date: 8/28/2023 12:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberDetails](
	[MemberId] [int] IDENTITY(1000,1) NOT NULL,
	[MemberName] [nvarchar](50) NOT NULL,
	[MemberMiddleName] [nvarchar](50) NULL,
	[MemberLastName] [nvarchar](50) NOT NULL,
	[Suffix] [int] NULL,
	[DateOfBirth] [smalldatetime] NOT NULL,
	[Gender] [int] NOT NULL,
	[ApplicantId] [int] NOT NULL,
	[RelationId] [int] NOT NULL,
 CONSTRAINT [PK_MemberDetails] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelationMst]    Script Date: 8/28/2023 12:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelationMst](
	[RelationId] [int] IDENTITY(1,1) NOT NULL,
	[RelationName] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_RelationMst] PRIMARY KEY CLUSTERED 
(
	[RelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 8/28/2023 12:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](70) NULL,
	[Email] [nvarchar](40) NULL,
	[Password] [nvarchar](50) NULL,
	[UserType] [varchar](15) NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Applicant] ON 

INSERT [dbo].[Applicant] ([ApplicantId], [UserId]) VALUES (1000, 1)
INSERT [dbo].[Applicant] ([ApplicantId], [UserId]) VALUES (1001, 2)
SET IDENTITY_INSERT [dbo].[Applicant] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberDetails] ON 

INSERT [dbo].[MemberDetails] ([MemberId], [MemberName], [MemberMiddleName], [MemberLastName], [Suffix], [DateOfBirth], [Gender], [ApplicantId], [RelationId]) VALUES (1000, N'Ajinkya', N'Vishnu', N'Bhosale', 1, CAST(N'1992-03-22T00:00:00' AS SmallDateTime), 1, 1001, 1)
INSERT [dbo].[MemberDetails] ([MemberId], [MemberName], [MemberMiddleName], [MemberLastName], [Suffix], [DateOfBirth], [Gender], [ApplicantId], [RelationId]) VALUES (1001, N'Sonali', N'AJinkya', N'Bhosale', 2, CAST(N'1999-10-02T00:00:00' AS SmallDateTime), 2, 1001, 2)
INSERT [dbo].[MemberDetails] ([MemberId], [MemberName], [MemberMiddleName], [MemberLastName], [Suffix], [DateOfBirth], [Gender], [ApplicantId], [RelationId]) VALUES (1002, N'Rani', N'Shiv', N'Bhosale', 2, CAST(N'2010-01-02T00:00:00' AS SmallDateTime), 2, 1001, 4)
INSERT [dbo].[MemberDetails] ([MemberId], [MemberName], [MemberMiddleName], [MemberLastName], [Suffix], [DateOfBirth], [Gender], [ApplicantId], [RelationId]) VALUES (1003, N'Rani', N'Shiv', N'Bhosale', 2, CAST(N'2010-01-02T00:00:00' AS SmallDateTime), 2, 1001, 4)
SET IDENTITY_INSERT [dbo].[MemberDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[RelationMst] ON 

INSERT [dbo].[RelationMst] ([RelationId], [RelationName]) VALUES (1, N'Father')
INSERT [dbo].[RelationMst] ([RelationId], [RelationName]) VALUES (2, N'Mother')
INSERT [dbo].[RelationMst] ([RelationId], [RelationName]) VALUES (3, N'Son')
INSERT [dbo].[RelationMst] ([RelationId], [RelationName]) VALUES (4, N'Daughter')
SET IDENTITY_INSERT [dbo].[RelationMst] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetails] ON 

INSERT [dbo].[UserDetails] ([UserId], [UserName], [Email], [Password], [UserType]) VALUES (1, N'ajinkya', N'abc@gmail.com', N'123456', N'Applicant')
INSERT [dbo].[UserDetails] ([UserId], [UserName], [Email], [Password], [UserType]) VALUES (2, N'Shivansh', N'shiv@gmail.com', N'123456', N'Applicant')
INSERT [dbo].[UserDetails] ([UserId], [UserName], [Email], [Password], [UserType]) VALUES (4, N'Admin', N'Admin@gmail.com', N'admin1', N'Admin')
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
GO
USE [master]
GO
ALTER DATABASE [FamilyDB] SET  READ_WRITE 
GO
