public class Person
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PersonalEmail { get; set; }
    public string Notes { get; set; }

    public Person(string fullName, DateTime dob, string email)
    {
        FullName = fullName;
        DateOfBirth = dob;
        PersonalEmail = email;
    }

    public virtual string GetInfo()
    {
        return $"{FullName} ({DateOfBirth:dd.MM.yyyy}) — {PersonalEmail}";
    }
}
