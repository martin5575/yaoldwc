namespace FootballEstimate.Model
{
    public class SeasonInfo
    {

        public SeasonInfo(string key, string name)
        {
            Key = key;
            Name = name;
        }

        public string Key { get; set; }
        public string Name { get; set; }
    }
}