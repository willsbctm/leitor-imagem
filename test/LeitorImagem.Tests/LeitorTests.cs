using FluentAssertions;

namespace LeitorImagem.Tests;

public class LeitorTests
{
    [Test]
    public void DeveLerImagemPeloDiretorio()
    {
        var leitorImagem = new Leitor();

        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "teste.png");
        var texto = leitorImagem.Ler(caminho);

        var textoEsperado = "WSsICOOB\n\nComprovante de envio\nPix\n\nR$ 474,01\n\nTransferido em 22/12/2024 às\n17:52:54\n\nconfraternizacao\n\nO Comprovante para\nsimples conferência\ngerado em\n22/12/2024 às\n17:52:55\n\nRecebedor\n\nNome\n\nCPF/CNPJ\n** **8.528/0001-**\n\nInstituição\n\nCC CREDIVAR\n\nPagador\n\nNome\n\nCPF/CNPJ\n*% ,44,422/0001-**\n\nInstituição\n\nCC CREDIVAR\n\n|D da Transação:\nE25798596202412222052N\n";
        texto.Should().Be(textoEsperado);
    }

    [Test]
    public void DeveLerImagemPeloStream()
    {
        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "teste.png");
        using var fileStream = new FileStream(caminho, FileMode.Open);
        using var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);

        var leitorImagem = new Leitor();
        var texto = leitorImagem.Ler(memoryStream);

        var textoEsperado = "WSsICOOB\n\nComprovante de envio\nPix\n\nR$ 474,01\n\nTransferido em 22/12/2024 às\n17:52:54\n\nconfraternizacao\n\nO Comprovante para\nsimples conferência\ngerado em\n22/12/2024 às\n17:52:55\n\nRecebedor\n\nNome\n\nCPF/CNPJ\n** **8.528/0001-**\n\nInstituição\n\nCC CREDIVAR\n\nPagador\n\nNome\n\nCPF/CNPJ\n*% ,44,422/0001-**\n\nInstituição\n\nCC CREDIVAR\n\n|D da Transação:\nE25798596202412222052N\n";
        texto.Should().Be(textoEsperado);
    }
}