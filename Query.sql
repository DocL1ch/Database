USE [CategoriesProducts]
GO

SELECT Products.Name as "Товар"
	  ,Categories.Name as "Категория"
  FROM [dbo].[Products]
  LEFT JOIN CategoryProduct ON CategoryProduct.ProductsId = Id
  LEFT JOIN Categories ON CategoryProduct.CategoriesId = Categories.Id
GO




