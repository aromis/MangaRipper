using System;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace MangaRipper.Workflow.Test
{
    public class MangaFoxTests
    {
        private readonly Mock<IDownloader> downloaderMock;
        private readonly Mock<IContentParser> contentParserMock;
        private readonly MangaFox mangaFox;

        public MangaFoxTests()
        {
            downloaderMock = new Mock<IDownloader>();
            contentParserMock = new Mock<IContentParser>();
            mangaFox = new MangaFox(downloaderMock.Object, contentParserMock.Object);
        }

        [Fact]
        public async void GetChapterAsync_Call_DownloadStringAsync()
        {
            var chapters = await mangaFox.GetChapterAsync("xyz");
            downloaderMock.Verify(d => d.DownloadStringAsync("xyz"), Times.Once);
        }

        [Fact]
        public async void GetChapterAsync_Call_Download_Then_Parse()
        {
            downloaderMock.Setup(d => d.DownloadStringAsync("abc")).Returns(Task.FromResult("xyz"));
            var chapters = await mangaFox.GetChapterAsync("abc");
            contentParserMock.Verify(p => p.Parse(It.Is<string>(s => s == "xyz")), Times.Once);
        }
    }
}
