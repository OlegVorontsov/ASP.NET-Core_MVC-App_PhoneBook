# PhoneBook

Приложение телефонной книги основано на шаблоне ASP.NET CORE Framework и состоит из двух частей: веб-приложения и базы данных. Обе части взаимодействуют с использованием ядра Entity Framework (EF).

Используемые технологии и библиотеки
- ASP.NET CORE
- шаблон Model-View-Controller (MVC)
- Razor pages
- Bootstrap
- HTML, CSS, JS
- LINQ
- MS SQL Server
- Entity Framework (EF)
- ASP.NET Identity (система аутентификации и авторизации)

## База Данных
Все объекты хранятся в базе данных Microsoft SQL Server.

## Веб-приложение
Веб-приложение основано на шаблоне Model-View-Controller (MVC). Модели между базой данных и представлением сопоставляются вручную. Все представления используют Razor pages и Bootstrap.

## Права
### Администратор имеет следующие права:
- редактирование / добавление / удаление любых записей - контакты / инфо контактов / пользователи / права / предоставление прав.

### Зарегистрированный пользователь имеет следующие права:
- редактирование / добавление / удаление записей контактов и инфо контактов.

### Незарегистрированный пользователь имеет следующие права:
- просмотр контактов и инфо контактов.

### Все пользователи могут:
- искать пользователей по имени;
- скачивать телефонную книгу в фомате .txt.


Для тестирования области администратора, пожалуйста, используйте следующие данные:
Электронная почта администратора = "admin@gmail.com"; Пароль администратора = "booMER86@".

### Запуск приложения
Для запуска приложения рекомендуется использовать Visual Studio 2019.

## Home page

![home](https://github.com/OlegVorontsov/ASP.NET-Core_MVC-App_PhoneBook/assets/102809790/fa80685b-2a3a-42ae-800c-96304ac6693e)

## All contacts page

![contact](https://github.com/OlegVorontsov/ASP.NET-Core_MVC-App_PhoneBook/assets/102809790/44e6a2c8-6ccc-4d6b-934b-7a43f983d453)

## Contact page

![profile](https://github.com/OlegVorontsov/ASP.NET-Core_MVC-App_PhoneBook/assets/102809790/b77746d5-198c-4a72-b890-65094b8b0176)

## Edit users page

![edit users](https://github.com/OlegVorontsov/ASP.NET-Core_MVC-App_PhoneBook/assets/102809790/6b0032e9-5a07-4fb5-ad1b-f06e5d079aa1)
