public abstract class UniversityMember : Person
{
    public UniversityMember(string fullName, DateTime dob, string email)
        : base(fullName, dob, email) { }

    public abstract decimal CalculateScholarship();

    public virtual void Enroll()
    {
        Console.WriteLine($"{FullName} був зарахований до університету.");
    }
}
