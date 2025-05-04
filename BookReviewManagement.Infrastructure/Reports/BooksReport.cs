namespace BookReviewManagement.Infrastructure.Reports;

public static class BooksReport
{
    public static byte[] GeneratePdfBooks(IEnumerable<BooksReportsModel> books)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(ts => ts.FontSize(10));

                page.Header()
                    .Text("Books")
                    .WordSpacing()
                    .FontSize(24)
                    .Bold()
                    .AlignCenter();

                page
                    .Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Table(t =>
                    {
                        t.ColumnsDefinition(c =>
                        {
                            c.RelativeColumn(500);
                            c.RelativeColumn(500);
                            c.RelativeColumn(500);
                            c.RelativeColumn(500);
                            c.RelativeColumn(500);
                            c.RelativeColumn(500);
                            c.RelativeColumn(500);
                        });                  

                        t.Header(h =>
                        {
                            h.Cell().Row(1).Column(1).Element(Block).Text("Cover");
                            h.Cell().Row(1).Column(2).Element(Block).Text("Isbn");
                            h.Cell().Row(1).Column(3).Element(Block).Text("Title");
                            h.Cell().Row(1).Column(4).Element(Block).Text("Author");
                            h.Cell().Row(1).Column(5).Element(Block).Text("Genre");
                            h.Cell().Row(1).Column(6).Element(Block).Text("Year");
                            h.Cell().Row(1).Column(7).Element(Block).Text("Score");
                        });

                        uint rowIndex = 2;
                        
                        foreach (var book in books)
                        {
                            t.Cell().Row(rowIndex).Column(1).Element(Entry).Image(book.Cover).FitArea();
                            t.Cell().Row(rowIndex).Column(2).Element(Entry).Text(book.Isbn);
                            t.Cell().Row(rowIndex).Column(3).Element(Entry).Text(book.Title);
                            t.Cell().Row(rowIndex).Column(4).Element(Entry).Text(book.Author);
                            t.Cell().Row(rowIndex).Column(5).Element(Entry).Text(Enum.GetName(book.Genre));
                            t.Cell().Row(rowIndex).Column(6).Element(Entry).Text(book.PublishDate.Year.ToString());
                            t.Cell().Row(rowIndex).Column(7).Element(Entry).Text(book.Score.ToString());
                            
                            rowIndex++;
                        }
                    });
            });
        });

        return document.GeneratePdf();
    }
    
    static IContainer Entry(IContainer container)
    {
        return container
            .BorderBottom(2)
            .PaddingBottom(2)
            .PaddingVertical(1)
            .PaddingHorizontal(6)
            .ShowOnce()
            .AlignCenter()
            .AlignMiddle();
    }

    static IContainer Block(IContainer container)
    {
        return container
            .BorderBottom(2)
            .Background(Colors.Grey.Lighten3)
            .ShowOnce()
            .MinWidth(50)
            .MinHeight(20)
            .AlignCenter()
            .AlignMiddle();
    }
}