USE [master]
GO

/****** Object:  Database [PrograWeb]    Script Date: 9/17/2020 8:15:36 PM ******/
CREATE DATABASE [PrograWeb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PrograWeb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PrograWeb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PrograWeb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PrograWeb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [PrograWeb] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrograWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PrograWeb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PrograWeb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PrograWeb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PrograWeb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PrograWeb] SET ARITHABORT OFF 
GO

ALTER DATABASE [PrograWeb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PrograWeb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PrograWeb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PrograWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PrograWeb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PrograWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PrograWeb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PrograWeb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PrograWeb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PrograWeb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PrograWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PrograWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PrograWeb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PrograWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PrograWeb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PrograWeb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PrograWeb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PrograWeb] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PrograWeb] SET  MULTI_USER 
GO

ALTER DATABASE [PrograWeb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PrograWeb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PrograWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PrograWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [PrograWeb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PrograWeb] SET QUERY_STORE = OFF
GO

ALTER DATABASE [PrograWeb] SET  READ_WRITE 
GO

USE [PrograWeb]
GO

/****** Object:  Table [dbo].[USUARIOS]    Script Date: 9/17/2020 8:19:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USUARIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ROL] [nvarchar](50) NOT NULL,
	[NOMBRE] [nvarchar](50) NOT NULL,
	[CORREO] [nvarchar](50) NOT NULL,
	[DOC_TYPE] [nvarchar](50) NOT NULL,
	[DOCUMENTO] [nvarchar](50) NOT NULL,
	[PASSWORD] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

