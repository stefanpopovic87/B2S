namespace B2S.Contract.Client
{
    public class GetCourseDetailsResponse
    {
        public int _code { get; set; }
        public string _name { get; set; }
        public string _desc { get; set; }
        public double _rating { get; set; }
        public string _level { get; set; }
        public List<string> _lectures { get; set; }
    }
}
