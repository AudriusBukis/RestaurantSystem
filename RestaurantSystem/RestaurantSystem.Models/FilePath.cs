namespace RestaurantSystem.Models
{ 
    public class FilePath
    {
        public string FileName { get; private set; }
        internal string Path { get; }
        public FilePath(string fileName)
        {
            FileName = fileName;
            Path = $@"C:\Users\audri\Documents\Code_Academy_mokymai\ExamWork2\RestaurantSystem\RestaurantSystem\{FileName}";

        }
    }
}
