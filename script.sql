USE [master]
GO
/****** Object:  Database [Art_Social]    Script Date: 16/07/2023 2:33:26 CH ******/
CREATE DATABASE [Art_Social]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Art_Social', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Art_Social.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Art_Social_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Art_Social_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Art_Social] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Art_Social].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Art_Social] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Art_Social] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Art_Social] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Art_Social] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Art_Social] SET ARITHABORT OFF 
GO
ALTER DATABASE [Art_Social] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Art_Social] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Art_Social] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Art_Social] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Art_Social] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Art_Social] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Art_Social] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Art_Social] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Art_Social] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Art_Social] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Art_Social] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Art_Social] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Art_Social] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Art_Social] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Art_Social] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Art_Social] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Art_Social] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Art_Social] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Art_Social] SET  MULTI_USER 
GO
ALTER DATABASE [Art_Social] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Art_Social] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Art_Social] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Art_Social] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Art_Social] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Art_Social] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Art_Social] SET QUERY_STORE = OFF
GO
USE [Art_Social]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [char](100) NOT NULL,
	[Password] [char](100) NOT NULL,
	[FullName] [nvarchar](500) NULL,
	[Avatar] [nvarchar](max) NULL,
	[AvatarPath] [nvarchar](max) NULL,
	[Wallet] [int] NULL,
	[MoTa] [ntext] NULL,
	[isAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblArtProduct]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArtProduct](
	[ArtID] [int] IDENTITY(1,1) NOT NULL,
	[ArtName] [nvarchar](500) NULL,
	[CategoryID] [int] NULL,
	[Abstract] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[UserID] [int] NULL,
	[Description] [ntext] NULL,
	[Image] [nvarchar](500) NULL,
	[Prices] [int] NULL,
	[Accept] [bit] NULL,
	[Selled] [bit] NULL,
 CONSTRAINT [PK_tblArtProduct] PRIMARY KEY CLUSTERED 
(
	[ArtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_DetailProduct]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DetailProduct]
AS
SELECT        dbo.tblArtProduct.ArtID, dbo.tblArtProduct.ArtName, dbo.tblArtProduct.CategoryID, dbo.tblArtProduct.Abstract, dbo.tblArtProduct.CreatedDate, dbo.tblArtProduct.UserID, dbo.tblArtProduct.Image, dbo.tblArtProduct.Description, 
                         dbo.tblArtProduct.Prices, dbo.tblUser.FullName, dbo.tblUser.AvatarPath, dbo.tblUser.isAdmin, dbo.tblCategory.CategoryName, dbo.tblArtProduct.Accept, dbo.tblArtProduct.Selled
FROM            dbo.tblArtProduct INNER JOIN
                         dbo.tblCategory ON dbo.tblArtProduct.CategoryID = dbo.tblCategory.CategoryID INNER JOIN
                         dbo.tblUser ON dbo.tblArtProduct.UserID = dbo.tblUser.UserID
GO
/****** Object:  Table [dbo].[tblComment]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblComment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ArtID] [int] NULL,
	[CommentText] [ntext] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblComment_1] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_ListComments]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ListComments]
AS
SELECT        dbo.tblComment.CommentID, dbo.tblComment.UserID, dbo.tblComment.ArtID, dbo.tblComment.CommentText, dbo.tblComment.CreatedDate, dbo.tblUser.UserName, dbo.tblUser.FullName, dbo.tblUser.AvatarPath
FROM            dbo.tblComment INNER JOIN
                         dbo.tblUser ON dbo.tblComment.UserID = dbo.tblUser.UserID
GO
/****** Object:  Table [dbo].[tblMyCart]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMyCart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[UserBuyID] [int] NOT NULL,
	[ArtID] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblMyCart_1] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_MyCart]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_MyCart]
AS
SELECT        dbo.tblMyCart.CartID, dbo.tblMyCart.UserBuyID, dbo.tblMyCart.ArtID, dbo.tblArtProduct.ArtName, dbo.tblArtProduct.Abstract, dbo.tblArtProduct.Image, dbo.tblArtProduct.Prices
FROM            dbo.tblArtProduct INNER JOIN
                         dbo.tblMyCart ON dbo.tblArtProduct.ArtID = dbo.tblMyCart.ArtID INNER JOIN
                         dbo.tblUser ON dbo.tblMyCart.UserBuyID = dbo.tblUser.UserID
GO
/****** Object:  Table [dbo].[tblAdminMenu]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdminMenu](
	[MenuID] [int] NOT NULL,
	[MenuName] [nvarchar](50) NULL,
	[MenuOrder] [int] NULL,
	[ParentID] [int] NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[Position] [int] NULL,
	[Link] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMenu]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMenu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](50) NULL,
	[MenuOrder] [int] NULL,
	[ParentID] [int] NULL,
	[Position] [int] NULL,
	[Link] [nvarchar](50) NULL,
	[ofAdmin] [bit] NULL,
 CONSTRAINT [PK_tblMenu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPost]    Script Date: 16/07/2023 2:33:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPost](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[PostContent] [nvarchar](500) NULL,
	[Imagecontent] [varbinary](max) NULL,
	[Imagemimetype] [nvarchar](500) NULL,
	[ImagePath] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblPost] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblArtProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblArtProduct_tblCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tblCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[tblArtProduct] CHECK CONSTRAINT [FK_tblArtProduct_tblCategory]
GO
ALTER TABLE [dbo].[tblArtProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblArtProduct_tblUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUser] ([UserID])
GO
ALTER TABLE [dbo].[tblArtProduct] CHECK CONSTRAINT [FK_tblArtProduct_tblUser]
GO
ALTER TABLE [dbo].[tblComment]  WITH CHECK ADD  CONSTRAINT [FK_tblComment_tblArtProduct] FOREIGN KEY([ArtID])
REFERENCES [dbo].[tblArtProduct] ([ArtID])
GO
ALTER TABLE [dbo].[tblComment] CHECK CONSTRAINT [FK_tblComment_tblArtProduct]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[57] 4[23] 2[4] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblCategory"
            Begin Extent = 
               Top = 52
               Left = 50
               Bottom = 190
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblUser"
            Begin Extent = 
               Top = 50
               Left = 631
               Bottom = 309
               Right = 896
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblArtProduct"
            Begin Extent = 
               Top = 35
               Left = 300
               Bottom = 323
               Right = 534
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3030
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DetailProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DetailProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblComment"
            Begin Extent = 
               Top = 105
               Left = 72
               Bottom = 308
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tblUser"
            Begin Extent = 
               Top = 75
               Left = 370
               Bottom = 316
               Right = 540
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ListComments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ListComments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblArtProduct"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblUser"
            Begin Extent = 
               Top = 14
               Left = 553
               Bottom = 183
               Right = 723
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "tblMyCart"
            Begin Extent = 
               Top = 26
               Left = 293
               Bottom = 236
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MyCart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MyCart'
GO
USE [master]
GO
ALTER DATABASE [Art_Social] SET  READ_WRITE 
GO
