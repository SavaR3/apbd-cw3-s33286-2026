namespace apbd_cw3_s33286_2026.Model;

public class Student: User
{
    public string StudentId { get; set; }
    public override int MaxRentals => 2;
    public override string UserType => "Student";

    public Student(string firstName, string lastName, string studentId)
        : base(firstName, lastName)
    {
        StudentId = studentId;
    }
}