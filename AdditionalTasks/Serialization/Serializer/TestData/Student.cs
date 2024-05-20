namespace Serializer.TestData
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public double[] Scores { get; set; }
        public bool IsGraduated { get; set; }
        public Dictionary<string, int> Courses { get; set; }
        public Cat Cat { get; set; }
    }
}
