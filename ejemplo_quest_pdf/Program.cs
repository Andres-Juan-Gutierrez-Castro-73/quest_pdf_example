using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(document =>
{
    document.Page(page =>
    {

        page.Margin(30);
        //page.Header().Height(100).Background(Colors.Blue.Medium);
        //page.Content().Background(Colors.Yellow.Medium);
        //page.Footer().Height(50).Background(Colors.Red.Medium);

        page.Header().ShowOnce().Row(row =>
        {
            row.ConstantItem(140).Height(60).Placeholder();


            row.RelativeItem().Column(col =>
            {
                col.Item().AlignCenter().Text("IEB").Bold().FontSize(14).FontColor(Colors.Red.Medium);
                col.Item().AlignCenter().Text("Calle 8B n.65-191").FontSize(9);
                col.Item().AlignCenter().Text("Centro Empresarial Puerto Seco").FontSize(9);
                col.Item().AlignCenter().Text("(Entrada 1) Oficina 331").FontSize(9);

            });

            row.RelativeItem().Column(col =>
            {
                col.Item().Border(1).BorderColor(Colors.Green.Medium)
                .AlignCenter().Text("RUC 1111111111");

                col.Item().Background(Colors.Red.Medium).Border(1)
                .BorderColor(Colors.Red.Medium).AlignCenter()
                .Text("Boleta de venta").FontColor("#fff");

                col.Item().Border(1).BorderColor(Colors.Red.Medium).
                AlignCenter().Text("B0001 - 234");


            });
        });

        page.Content().PaddingVertical(10).Column(col1 =>
        {
            col1.Item().Column(col2 =>
            {
                col2.Item().Text("Datos del cliente").Underline().Bold();

                col2.Item().Text(txt =>
                {
                    txt.Span("Nombre: ").SemiBold().FontSize(10);
                    txt.Span("Héctor Fabio Oviedo Rincón").FontSize(10);
                });

                col2.Item().Text(txt =>
                {
                    txt.Span("DNI: ").SemiBold().FontSize(10);
                    txt.Span("10101010101").FontSize(10);
                });

                col2.Item().Text(txt =>
                {
                    txt.Span("Direccion: ").SemiBold().FontSize(10);
                    txt.Span("Medellín").FontSize(10);
                });
            });

            col1.Item().LineHorizontal(0.5f);

            col1.Item().Table(tabla =>
            {
                tabla.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();

                });

                tabla.Header(header =>
                {
                    header.Cell().Background(Colors.Red.Medium)
                    .Padding(2).Text("Producto").FontColor("#fff");

                    header.Cell().Background(Colors.Red.Medium)
                   .Padding(2).Text("Precio Unit").FontColor("#fff");

                    header.Cell().Background(Colors.Red.Medium)
                   .Padding(2).Text("Cantidad").FontColor("#fff");

                    header.Cell().Background(Colors.Red.Medium)
                   .Padding(2).Text("Total").FontColor("#fff");
                });

                foreach (var item in Enumerable.Range(1, 45))
                {
                    var cantidad = Placeholders.Random.Next(1, 10);
                    var precio = Placeholders.Random.Next(5, 15);
                    var total = cantidad * precio;

                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                        .Padding(2).Text(Placeholders.Label()).FontSize(10);

                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                        .Padding(2).Text(cantidad.ToString()).FontSize(10);

                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                        .Padding(2).Text($"S/. {precio}").FontSize(10);

                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                        .Padding(2).AlignRight().Text($"S/. {total}").FontSize(10);
                }

            });

            col1.Item().AlignRight().Text("Total: 1500").FontSize(12);

            if (1 == 1)
                col1.Item().Background(Colors.Grey.Lighten3).Padding(10)
                .Column(column =>
                {
                    column.Item().Text("Comentarios").FontSize(14);
                    column.Item().Text(Placeholders.LoremIpsum());
                    column.Spacing(5);
                });

            col1.Spacing(10);
        });


        page.Footer()
        .AlignRight()
        .Text(txt =>
        {
            txt.Span("Pagina ").FontSize(10);
            txt.CurrentPageNumber().FontSize(10);
            txt.Span(" de ").FontSize(10);
            txt.TotalPages().FontSize(10);
        });
    });
}).ShowInPreviewer();