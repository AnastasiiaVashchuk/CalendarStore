namespace Models
{
    public class Person: Unit
    {
        public string firstName;
        public string lastName;
        public Person(string firstName="",string lastName="")
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public override string ToString()
        {
            return $"First name : {firstName}, Last name : {lastName}";
        }
    }
}