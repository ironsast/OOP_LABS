using System;
using System.Linq;
using Task2;
class Program
{
    static void Main(string[] args)
    {
        // ����� 1: �������� ������ Numbers
        Numbers num1 = new Numbers(36, 60);
        num1.Print();
        Console.WriteLine($"���: {num1.Nod()}");
        Console.WriteLine($"���: {num1.Nok()}");

        num1.NewK(15, 45);
        num1.Print();
        Console.WriteLine($"���: {num1.Nod()}");
        Console.WriteLine($"���: {num1.Nok()}");

        // ����� 2: �������� ������ Student
        Student[] students = new Student[]
        {
            new Student { LastName = "������", FirstName = "����", MiddleName = "��������", BirthDate = new DateTime(2000, 5, 15), Faculty = "������", Course = 3 },
            new Student { LastName = "������", FirstName = "����", MiddleName = "��������", BirthDate = new DateTime(1999, 8, 22), Faculty = "����������", Course = 2 },
            new Student { LastName = "�������", FirstName = "�����", MiddleName = "���������", BirthDate = new DateTime(2001, 12, 5), Faculty = "������", Course = 1 },
            new Student { LastName = "��������", FirstName = "�������", MiddleName = "����������", BirthDate = new DateTime(2002, 3, 18), Faculty = "����������", Course = 3 }
        };

        Console.WriteLine("\n�������� ���������� '������':");
        Student.FilterByFaculty(students, "������");

        Console.WriteLine("\n��������, ���������� ����� 2000 ����:");
        Student.FilterByYear(students, 2000);

        // ����� 3: �������� ������ Rectangle
        Rectangle rect1 = new Rectangle(5, 10);
        rect1.Print();

        rect1.A = 8;
        rect1.B = 8;
        rect1.Print();

        // ����� 4: �������� ������ Triangle
        try
        {
            Triangle triangle1 = new Triangle(3, 4, 5);
            triangle1.Print();
            Console.WriteLine($"����� ����������� ������: {triangle1.MedianIntersection()}");

            // ����������� � ������������� ���������
            Triangle triangle2 = new Triangle(1, 2, 8);  // ������
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
