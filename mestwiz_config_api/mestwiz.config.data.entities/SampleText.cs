

namespace mestwiz.config.data.entities
{
    public class SampleText
    {
        public SamplePageConfiguration configuration { get; set; }
        public List<SampleTextLine> lines { get; set; }
        public int actual_page { get; set; }

        public SampleText()
        {
            configuration = new SamplePageConfiguration();
            lines = new List<SampleTextLine>();
        }
    }

    public class SampleTextLine
    {
        public int index { get; set; }
        public string text { get; set; }
    }
   
    public class SampleTextConfiguration
    {
        public int total_pages { get; set; }       
        public int lines_page { get; set; }
        public string type { get; set; }
    }

    public class SamplePageConfiguration
    {
        public string height { get; set; }
        public string width { get; set; }
        public string margin_left { get; set; }
        public string margin_right { get; set; }
        public string margin_top { get; set;}
        public string margin_bottom { get; set;}
    }
}
