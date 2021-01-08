class Person
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person(string name, string lastName, int age)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Age = age;
    }
}