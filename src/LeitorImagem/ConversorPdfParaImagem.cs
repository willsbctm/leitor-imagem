using Syncfusion.PdfToImageConverter;

namespace LeitorImagem;

public class ConversorPdfParaImagem
{
    public void ConverterPdfParaImagem(string pdfName, string output)
    {
        using var stream = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
        using var memoryStream = ConverterPdfParaImagem(pdfName, stream);
    }

    public Stream ConverterPdfParaImagem(string pdfName, Stream stream)
    {
        using var imageConverter = new PdfToImageConverter();
        using var inputStream = new FileStream(pdfName, FileMode.Open, FileAccess.ReadWrite);
        imageConverter.Load(inputStream);
        var outputStream = imageConverter.Convert(0,imageConverter.PageCount-1,false,false);

        var image = Syncfusion.Drawing.Image.FromStream(outputStream[0]);
        byte[] data = image.ImageData;
        stream.Write(data, 0, data.Length);

        return stream;
    }
}
