using mestwiz.config.api.entities;
using mestwiz.config.data.entities;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace mestwiz.config.api.logic.Samples
{
    public class LSampleText
    {
        public async Task<Response<SampleTextConfiguration>> GetForShort()
        {
            List<SampleTextLine> shortTxtLns = GetShortTextLines();
            Response<SampleTextConfiguration> response = new();
            response.data.lines_page = shortTxtLns.Count();
            response.data.type = "PLAIN_TEXT";

            decimal tPages = shortTxtLns.Count() / response.data.lines_page;
            int dtPages = shortTxtLns.Count() % response.data.lines_page;

            response.data.total_pages = dtPages > 0 ? Convert.ToInt32(tPages) + 1 : Convert.ToInt32(tPages);

            return await Task.FromResult(response);
        }

        public async Task<Response<SampleTextConfiguration>> GetForLong()
        {
            List<SampleTextLine> shortTxtLns = GetLongTextLines();
            Response<SampleTextConfiguration> response = new();
            response.data.lines_page = 100;
            response.data.type = "PLAIN_TEXT";
            decimal tPages = shortTxtLns.Count() / response.data.lines_page;
            int dtPages = shortTxtLns.Count() % response.data.lines_page;

            response.data.total_pages = dtPages > 0 ? Convert.ToInt32(tPages) + 1 : Convert.ToInt32(tPages);

            return await Task.FromResult(response);
        }

        public List<SampleTextLine> GetShortTextLines() {
            List<string> lines = data.access.Properties.Resources.sample_text_file.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
            int count = 0;

            return lines.Select(x => new SampleTextLine() { index = count+=1, text = x  }).ToList().OrderBy(x=> x.index).ToList();
        }

        public List<SampleTextLine> GetLongTextLines()
        {
            List<string> lines = data.access.Properties.Resources.sample_2mb_text_file.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
            int count = 0;

            return lines.Select(x => new SampleTextLine() { index = count += 1, text = x }).ToList().OrderBy(x => x.index).ToList();
        }

        public async Task<List<SampleText>> GetSampleTextPages(SampleTextConfiguration configuration, List<SampleTextLine> text, int page = 0, bool all =  true)
        {
                    
            List<SampleText> pages = new();
            SampleText _page = new();
            _page.actual_page = !all ? page : 1;

            _page.configuration = new() { height = "auto", width = "auto", margin_left = "10%", margin_right = "10%" };

            int linesC = 0;

            text.Where(x => { return !all ? x.index <= configuration.lines_page * page && x.index >= configuration.lines_page * (page - 1) : true; }).ToList().OrderBy(x => x.index).ToList().ForEach(x => {
                if (x.index == _page.actual_page * configuration.lines_page)
                {
                    pages.Add(_page);
                    _page = new();
                    _page.actual_page = !all ? page : pages.Count();
                    _page.configuration = new() { height = "auto", width = "auto", margin_left = "10%", margin_right = "10%" };
                }

                _page.lines.Add(new SampleTextLine() { index = linesC, text = x.text });
                linesC+=1;
            });

            return await Task.FromResult(pages);
        }


        public async Task<List<SampleText>> GetSampleTextPageForLong(int page)
        {
            List<SampleTextLine> text = GetLongTextLines();
            Response<SampleTextConfiguration> configuration = await GetForLong();
            return await GetSampleTextPages(configuration.data, text, page, false);
        }

        public async Task<List<SampleText>> GetSampleTextPageForShort(int page)
        {
            List<SampleTextLine> text = GetShortTextLines();
            Response<SampleTextConfiguration> configuration = await GetForShort();
            return await GetSampleTextPages(configuration.data, text, page, false);
        }


        public async Task<Response<SampleText>> GetLong(int page)
        {
            Response<SampleText> response = new();

            response.data = new();
         
            try
            {
                List<SampleText> _page = await GetSampleTextPageForLong(page);

                response.data = _page.FirstOrDefault();

            }
            catch (Exception e)
            {

                response.message.AddError(new MessageError() { Error = e.Message });
            }
       
            return await Task.FromResult(response);
        }

        public async Task<Response<SampleText>> GetShort(int page)
        {
            Response<SampleText> response = new();

            response.data = new SampleText() { lines = new() };

            try
            {
                List<SampleText> _page = await GetSampleTextPageForShort(page);

                response.data = _page.FirstOrDefault();
            }
            catch (Exception e)
            {

                response.message.AddError(new MessageError() { Error = e.Message });
            }

            return await Task.FromResult(response);
        }

    }
}
