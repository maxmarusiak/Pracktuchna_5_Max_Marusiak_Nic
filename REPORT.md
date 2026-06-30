## 1. Наслідування
Механізм, коли один клас успадковує властивості й методи іншого.
Переваги: менше дублювання, логічна структура, поліморфізм.
Недоліки: сильна зв’язаність, складні ієрархії, ризик неправильного override/new.
## 2. Приклади base
Конструктор:
public Student(...) : base(name, age) { }
Метод:
public override void PrintInfo() {
    base.PrintInfo();
}
## 3. virtual / override / new
virtual — дозволяє перевизначення.
override — перевизначає virtual метод.
new — приховує метод, НЕ дає поліморфізму.
## 4. Абстрактні класи
Потрібні для спільного контракту та поліморфізму.
Використано:
public abstract class UniversityMember
## 5. sealed
Забороняє наслідування або перевизначення.
Використано:
public sealed class HonorsStudent
## 6. Поліморфізм
Список базового типу + override методи:
List<UniversityMember> members;
m.PrintInfo();
## 7. Труднощі та рішення
Розподіл полів між Person / Student.
Де ставити virtual/override/new.
Уникнення дублювання.
Рішення: абстракція, спільні базові класи, чітка ієрархія.
## 8. Що нового дізнався
Правильне наслідування.
Робота virtual/override/new.
Абстракція та sealed.
Реалізація поліморфізму.
Побудова чистої ієрархії класів.
## 9. Посилання на GitHub репозиторій
https://github.com/maxmarusiak/Pracktuchna_5_Max_Marusiak_Nic
