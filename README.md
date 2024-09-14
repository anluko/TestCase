## Описание   
Проект тестового задание для компании "Проекти и решения, Центр ифнормационных технологий"  
Приложение написано на WPF C#.  
Использована база данных PostgreSQL

## Инструкция
Для корректной работы программы вам необходимо правильно установить базу данных.  
1. Для начала скачайте (если нет) СУБД PostrgrSQL.
2. В файле Models/AppDbContext.cs необходимо поменять метод OnConfiguring и установить свою строку подключения:
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         optionsBuilder.UseNpgsql("Host=ВАШ_ХОСТ;Port=ВАШ_ПОРТ;Database=НАЗВАНИЕ_БД;Username=ПОЛЬЗОВАТЕЛЬ_БД;Password=ПАРОЛЬ+ПОЛЬЗОВАТЕЛЯ");
    }
4. Загрузить данные из файл, которое прилогается к проекту (InitalData.xlsx). Это можно выполнить в приложении (После запуска нажимаете на иконку настроек -> Загрузить данные -> Выбираете файл)
