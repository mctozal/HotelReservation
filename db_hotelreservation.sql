USE [master]
GO
/****** Object:  Database [hotel_reservation]    Script Date: 29.04.2019 19:36:18 ******/
CREATE DATABASE [hotel_reservation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hotel_reservation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\hotel_reservation.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'hotel_reservation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\hotel_reservation_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [hotel_reservation] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hotel_reservation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hotel_reservation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hotel_reservation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hotel_reservation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hotel_reservation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hotel_reservation] SET ARITHABORT OFF 
GO
ALTER DATABASE [hotel_reservation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [hotel_reservation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hotel_reservation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hotel_reservation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hotel_reservation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hotel_reservation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hotel_reservation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hotel_reservation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hotel_reservation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hotel_reservation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [hotel_reservation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hotel_reservation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hotel_reservation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hotel_reservation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hotel_reservation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hotel_reservation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hotel_reservation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hotel_reservation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hotel_reservation] SET  MULTI_USER 
GO
ALTER DATABASE [hotel_reservation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hotel_reservation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hotel_reservation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hotel_reservation] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [hotel_reservation] SET DELAYED_DURABILITY = DISABLED 
GO
USE [hotel_reservation]
GO
/****** Object:  Table [dbo].[CreditCard]    Script Date: 29.04.2019 19:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCard](
	[CreditCardID] [int] IDENTITY(1,1) NOT NULL,
	[CardType] [nvarchar](50) NOT NULL,
	[CardNumber] [nvarchar](25) NOT NULL,
	[ExpMonth] [tinyint] NOT NULL,
	[ExpYear] [smallint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CreditCardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[guest]    Script Date: 29.04.2019 19:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[guest](
	[id] [int] NOT NULL,
	[first_name] [varchar](80) NOT NULL,
	[last_name] [varchar](80) NULL,
	[e_mail] [varchar](50) NULL,
	[phone_number] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reservation]    Script Date: 29.04.2019 19:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reservation](
	[id] [int] NOT NULL,
	[date_in] [date] NOT NULL,
	[date_out] [date] NOT NULL,
	[status] [varchar](20) NOT NULL,
	[made_by] [varchar](20) NOT NULL,
	[guest_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[room]    Script Date: 29.04.2019 19:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[room](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[number] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[status] [varchar](10) NOT NULL,
	[smoke] [bit] NOT NULL,
	[room_type_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[room_type]    Script Date: 29.04.2019 19:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[room_type](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[description] [varchar](80) NULL,
	[max_capacity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[reservation]  WITH CHECK ADD FOREIGN KEY([guest_id])
REFERENCES [dbo].[guest] ([id])
GO
ALTER TABLE [dbo].[room]  WITH CHECK ADD FOREIGN KEY([room_type_id])
REFERENCES [dbo].[room_type] ([id])
GO
USE [master]
GO
ALTER DATABASE [hotel_reservation] SET  READ_WRITE 
GO
