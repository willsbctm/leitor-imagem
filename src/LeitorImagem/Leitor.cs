using System.Text;
using Tesseract;

namespace LeitorImagem;

public class Leitor
{
    private readonly string _tesseractPath;

    public Leitor() => _tesseractPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");

    public string Ler(MemoryStream stream)
    {
        using var img = Pix.LoadFromMemory(stream.GetBuffer());
        return Ler(img);
    }

    public string Ler(string path)
    {
        using var img = Pix.LoadFromFile(path);
        return Ler(img);
    }

    public string Ler(Pix img)
    {
        using var ocrEngine = new TesseractEngine(_tesseractPath, "por", EngineMode.Default);
        using var page = ocrEngine.Process(img, PageSegMode.Auto);
        var builder = new StringBuilder();
        string text = page.GetText();

        var layout = page.AnalyseLayout();

        return text;
    }
}

