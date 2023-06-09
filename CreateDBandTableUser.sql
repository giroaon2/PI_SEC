USE [master]
GO
/****** Object:  Database [PI_SEC]    Script Date: 25/04/2023 2:20:10 PM ******/
CREATE DATABASE [PI_SEC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PI_SEC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PI_SEC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PI_SEC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PI_SEC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PI_SEC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PI_SEC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PI_SEC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PI_SEC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PI_SEC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PI_SEC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PI_SEC] SET ARITHABORT OFF 
GO
ALTER DATABASE [PI_SEC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PI_SEC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PI_SEC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PI_SEC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PI_SEC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PI_SEC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PI_SEC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PI_SEC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PI_SEC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PI_SEC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PI_SEC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PI_SEC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PI_SEC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PI_SEC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PI_SEC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PI_SEC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PI_SEC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PI_SEC] SET RECOVERY FULL 
GO
ALTER DATABASE [PI_SEC] SET  MULTI_USER 
GO
ALTER DATABASE [PI_SEC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PI_SEC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PI_SEC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PI_SEC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PI_SEC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PI_SEC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PI_SEC', N'ON'
GO
ALTER DATABASE [PI_SEC] SET QUERY_STORE = OFF
GO
USE [PI_SEC]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25/04/2023 2:20:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [bigint] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [PI_SEC] SET  READ_WRITE 
GO
