# PetWallet Backend
Серверная часть приложения для отслеживание финансов.

Приложение в разработке.

Реализованны паттерны:
- Repository, Generic Repository
- UnitOfWork (представленно классом ModelContext)

### Запуск приложения
Запустить БД: `docker run --name petwalletdb -p 54321:5432 -e POSTGRES_PASSWORD=password -d postgres`.

При первом запуске БД заполнится тестовыми записями.

После запустить [фронтенд](https://github.com/belovnow/PetWallet-Frontend).
