using System;
using StudentGroupSystem.Models;
using StudentGroupSystem.Services;
using StudentGroupSystem.Features;

namespace StudentGroupSystem
{
    class Program
    {
        static void Main()
        {
            var group = new StudentGroup();
            var textProcessor = new TextProcessor();
            var logger = new AdvancedLogger();
            var notesEditor = new NotesEditor();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Student Group Management System ===");
                Console.WriteLine("1. Додати студента");
                Console.WriteLine("2. Видалити студента");
                Console.WriteLine("3. Вивести всіх студентів");
                Console.WriteLine("4. Пошук студента");
                Console.WriteLine("5. Редагування даних студента");
                Console.WriteLine("6. Відмінники / < 6 балів");
                Console.WriteLine("7. Статистика групи");
                Console.WriteLine("8. Зберегти дані");
                Console.WriteLine("9. Завантажити дані");
                Console.WriteLine("10. Пошук за фрагментом ПІБ");
                Console.WriteLine("11. Згенерувати повний звіт групи");
                Console.WriteLine("12. Нормалізувати нотатки всіх студентів");
                Console.WriteLine("13. Перевірити паліндроми в нотатках");
                Console.WriteLine("14. Експорт групи у CSV");
                Console.WriteLine("15. Імпорт студентів з текстового блоку");
                Console.WriteLine("16. Переглянути логи системи");
                Console.WriteLine("17. Порівняти продуктивність string vs StringBuilder");
                Console.WriteLine("18. Обробка тексту (реверс, підрахунок слів тощо)");
                Console.WriteLine("19. Вийти");
                Console.Write("\nВаш вибір: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть ПІБ студента: ");
                        var name = Console.ReadLine();
                        try
                        {
                            var student = new Student(name);
                            group.AddStudent(student);
                            logger.Log("INFO", $"Додано студента {name}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.Write("Введіть ID студента: ");
                        if (Guid.TryParse(Console.ReadLine(), out var id))
                        {
                            group.RemoveStudent(id);
                            logger.Log("INFO", $"Видалено студента {id}");
                        }
                        break;

                    case "3":
                        foreach (var s in group.Students)
                            Console.WriteLine(s.GetFormattedInfo());
                        break;

                    case "4":
                        Console.Write("Введіть ключове слово: ");
                        var keyword = Console.ReadLine();
                        foreach (var s in group.Students)
                            if (s.ContainsKeyword(keyword))
                                Console.WriteLine(s.GetFormattedInfo());
                        break;

                    case "5":
                        Console.Write("Введіть ID студента: ");
                        if (Guid.TryParse(Console.ReadLine(), out var editId))
                        {
                            var st = group.Students.Find(s => s.Id == editId);
                            if (st != null)
                            {
                                Console.Write("Нові нотатки: ");
                                st.Notes = Console.ReadLine();
                                logger.Log("INFO", $"Оновлено нотатки студента {editId}");
                            }
                        }
                        break;

                    case "6":
                        Console.WriteLine("Відмінники:");
                        foreach (var s in group.Students)
                            if (s.LabGrades.Length > 0 && s.LabGrades[0] >= 10)
                                Console.WriteLine(s.FullName);

                        Console.WriteLine("\nМенше 6 балів:");
                        foreach (var s in group.Students)
                            if (s.LabGrades.Length > 0 && s.LabGrades[0] < 6)
                                Console.WriteLine(s.FullName);
                        break;

                    case "7":
                        Console.WriteLine($"Кількість студентів: {group.Students.Count}");
                        break;

                    case "8":
                        System.IO.File.WriteAllText("students.json",
                            System.Text.Json.JsonSerializer.Serialize(group));
                        logger.Log("INFO", "Дані збережено");
                        break;

                    case "9":
                        if (System.IO.File.Exists("students.json"))
                        {
                            var json = System.IO.File.ReadAllText("students.json");
                            group = System.Text.Json.JsonSerializer.Deserialize<StudentGroup>(json);
                            logger.Log("INFO", "Дані завантажено");
                        }
                        break;

                    case "10":
                        Console.Write("Фрагмент ПІБ: ");
                        Console.WriteLine(group.SearchByNameFragment(Console.ReadLine()));
                        break;

                    case "11":
                        Console.WriteLine(textProcessor.BuildGroupReport(group));
                        break;

                    case "12":
                        foreach (var s in group.Students)
                            s.Notes = textProcessor.Normalize(s.Notes);
                        logger.Log("INFO", "Нотатки нормалізовано");
                        break;

                    case "13":
                        foreach (var s in group.Students)
                            if (textProcessor.IsPalindrome(s.Notes))
                                Console.WriteLine($"{s.FullName}: паліндром");
                        break;

                    case "14":
                        var csv = group.ExportToCsv();
                        System.IO.File.WriteAllText("group.csv", csv);
                        logger.Log("INFO", "CSV експортовано");
                        break;

                    case "15":
                        Console.WriteLine("Введіть текст:");
                        var raw = Console.ReadLine();
                        group.ImportStudentsFromText(raw);
                        logger.Log("INFO", "Імпорт студентів виконано");
                        break;

                    case "16":
                        Console.WriteLine(logger.GetLast(50));
                        break;

                    case "17":
                        Console.Write("Кількість ітерацій: ");
                        int iter = int.Parse(Console.ReadLine());
                        Console.WriteLine(textProcessor.ComparePerformance(iter));
                        break;

                    case "18":
                        Console.Write("Введіть текст: ");
                        var txt = Console.ReadLine();
                        Console.WriteLine($"Reverse: {textProcessor.Reverse(txt)}");
                        Console.WriteLine($"Words: {textProcessor.CountWords(txt)}");
                        Console.WriteLine($"Chars: {textProcessor.CountCharacters(txt)}");
                        break;

                    case "19":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }

                Console.WriteLine("\nНатисніть Enter...");
                Console.ReadLine();
            }
        }
    }
}
