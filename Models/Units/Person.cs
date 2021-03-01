namespace Models
{
    public class Person: Unit
    {
        private string firstName;
        private string lastName;

        public Person(string firstName="",string lastName="")
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public string FirstName => firstName;

        public string LastName => lastName;

        public override string ToString()
        {
            return $"First name : {firstName}, Last name : {lastName}";
        }
    }
}