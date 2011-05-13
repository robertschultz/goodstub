USE [master]
GO

/****** Object:  Database [Mongrala]    Script Date: 03/12/2011 10:23:57 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Mongrala')
DROP DATABASE [Mongrala]
GO

USE [master]
GO

/****** Object:  Database [Mongrala]    Script Date: 03/12/2011 10:23:58 ******/
CREATE DATABASE [Mongrala] ON  PRIMARY 
( NAME = N'Mongrala', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Mongrala.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mongrala_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Mongrala_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Mongrala] SET COMPATIBILITY_LEVEL = 90
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mongrala].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Mongrala] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Mongrala] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Mongrala] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Mongrala] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Mongrala] SET ARITHABORT OFF 
GO

ALTER DATABASE [Mongrala] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Mongrala] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Mongrala] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Mongrala] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Mongrala] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Mongrala] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Mongrala] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Mongrala] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Mongrala] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Mongrala] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Mongrala] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Mongrala] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Mongrala] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Mongrala] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Mongrala] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Mongrala] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Mongrala] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Mongrala] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Mongrala] SET  READ_WRITE 
GO

ALTER DATABASE [Mongrala] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Mongrala] SET  MULTI_USER 
GO

ALTER DATABASE [Mongrala] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Mongrala] SET DB_CHAINING OFF 
GO

