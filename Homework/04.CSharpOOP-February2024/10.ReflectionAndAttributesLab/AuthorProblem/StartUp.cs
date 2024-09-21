namespace AuthorProblem
{
    [Author("Victor")]
    class StartUp
    {
        [Author("George")]
        static void Main()
        {
            // 06.Code Tracker
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("John")]
        public void TestMethod()
        {

        }
    }
}
