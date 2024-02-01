namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members = new();

        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = new();

            foreach (Person member in Members)
            {
                if (member.Age > oldestMember.Age)
                {
                    oldestMember = member;
                }
            }

            return oldestMember;
        }
    }
}
