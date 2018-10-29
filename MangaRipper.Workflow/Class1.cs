using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MangaRipper.Workflow
{
    public class MangaFox
    {
        private readonly IDownloader downloader;
        private readonly IContentParser contentParser;

        public MangaFox(IDownloader downloader, IContentParser contentParser)
        {
            this.downloader = downloader;
            this.contentParser = contentParser;
        }

        public async Task<IEnumerable<Chapter>> GetChapterAsync(string chapterUrl)
        {
            string content = await downloader.DownloadStringAsync(chapterUrl);
            var parsedContents = contentParser.Parse(content);
            return new List<Chapter>();
        }
    }

    public class Chapter
    {
    }

    public interface IDownloader
    {
        Task<string> DownloadStringAsync(string chapterUrl);
    }

    public class Downloader : IDownloader
    {
        public async Task<string> DownloadStringAsync(string chapterUrl)
        {
            throw new NotImplementedException();
        }
    }

    public interface IContentParser
    {
        IEnumerable<string> Parse(string v);
    }

    public class ContentParser : IContentParser
    {
        public IEnumerable<string> Parse(string v)
        {
            throw new NotImplementedException();
        }
    }
}
