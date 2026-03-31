# Журнал промптів (індекс)

## Призначення
Короткий індекс AI-сесій та їх результатів.
Деталі архітектурних рішень — в `docs/AI_Context/decisions/ADR-*.md`.
Деталі змін коду — в git history (`git log`, `git diff`).

## Формат запису
- Дата
- Тема
- Режим (`Швидкий` / `Архітектурний`)
- Версія ToT / версія зміни
- Статус
- Короткий результат

## Записи

### 2026-03-31 — Database Migration v1.6: SQLite → SQL Server + Stored Procedures
- Режим: `Архітектурний`
- Версія: `1.6`
- Статус: `Активний`
- Результат: Мігровано БД з SQLite на SQL Server (Windows Auth). Видалено старі міграції (V11, V13), додано `20260324192913_InitialSqlServerV16`. Реалізовано 16 CRUD Stored Procedures у 3 SQL-скриптах (`SQL/StoredProcedures/`), додано SP-репозиторії (`SpHousingRepository`, `SpRentalApplicationRepository`, `SpRentalApplicationProfileRepository`), UML DB-діаграми (`UML/Database/`). Оновлено `appsettings.json`, `appsettings.Production.json`, `Program.cs`, `rent_for_students.csproj`. Flyweight оновлено під нову схему.

### 2026-03-16 — Актуалізація контексту після Flyweight v1.5
- Режим: `Швидкий`
- Версія: `1.5`
- Статус: `Активний`
- Результат: Оновлено `project-context.md` (додано Flyweight, Domain/Flyweight шар, IRentalApplicationProfileRepository), `patterns.md` (додано секцію Flyweight v1.5), `PROMPT_HISTORY.md`. ADR-004 вже існував. Flyweight повністю інтегрований: Factory (Singleton), Views (@inject), Controller.

### 2026-03-16 — Реалізація Flyweight v1.5 (RoomType як багатий Flyweight)
- Режим: `Архітектурний`
- Версія: `1.5`
- Статус: `Активний`
- Результат: Реалізовано Variant 1A — `IRoomTypeFlyweight` + `RoomTypeFlyweight` (ConcreteFlyweight) + `RoomTypeFlyweightFactory` (Singleton, pre-populated cache). Інтегровано у всі Views (Create, Edit, Index, Details) через `@inject`. Створено ADR-004 та UML-діаграми (class + component). Коміт: `0e9e6af`.

### 2026-03-06 — Реалізація Prototype v1.4 (baseline interface-based)
- Режим: `Архітектурний`
- Версія: `1.4`
- Статус: `Активний`
- Результат: Реалізовано `IRentalApplicationPrototype` + `Clone()` у `RentalApplicationProfile`, переведено репозиторії/mediator/команди/controller/view на interface-based flow, оновлено контекст (`patterns.md`, `project-context.md`, ADR-003), `dotnet test` -> `7/7 passed`.

### 2026-03-06 — UML: v1.4 new commands + prototype refactor focus
- Режим: `Швидкий`
- Версія: `1.4`
- Статус: `В розробці`
- Результат: Створено цільову діаграму `UML/Prototype/StudentRent-ClassDiagram-v1_4-prototype-refactor-focus.puml` і актуалізовано повний набір `v1_4` (`core`, `new-commands-focus`, `part1`, `part2`, `part3`) з інтерфейсною формою Prototype (`IRentalApplicationPrototype` + `Clone()`).

### 2026-03-04 — UML: new commands focus v1.3
- Режим: `Швидкий`
- Версія: `1.3`
- Статус: `Активний`
- Результат: Створено фокусну діаграму `UML/Command_Mediator/StudentRent-ClassDiagram-v1_3-new-commands-focus.puml` лише для нових команд та прямо повʼязаних елементів.

### 2026-03-04 — UML: part2 + part3 v1.3 (Prototype domain/infrastructure)
- Режим: `Швидкий`
- Версія: `1.3`
- Статус: `Активний`
- Результат: Додано дві UML-діаграми: `UML/Command_Mediator/StudentRent-ClassDiagram-v1_3-part2-domain-prototype.puml` і `UML/Command_Mediator/StudentRent-ClassDiagram-v1_3-part3-infrastructure-integration.puml` для завершення п.3/п.4 плану.

### 2026-03-04 — UML: core v1.4 + part1 v1.3 (Prototype update)
- Режим: `Швидкий`
- Версія: `1.3`
- Статус: `Активний`
- Результат: Створено дві нові UML-діаграми для показу: `UML/Command_Mediator/StudentRent-ClassDiagram-core-v1_4.puml` і `UML/Command_Mediator/StudentRent-ClassDiagram-v1_3-part1-controllers-application.puml` з урахуванням `Prototype v1.3`.

### 2026-03-03 — Застосування міграції Prototype v1.3 до БД
- Режим: `Швидкий`
- Версія: `1.3`
- Статус: `Активний`
- Результат: Після корекції автогенерованої міграції застосовано `dotnet ef database update`; активні міграції: `20260221170000_InitialSchemaV11`, `20260303220918_AddRentalApplicationProfilesV13`.

### 2026-03-03 — Перегенерація міграції через `dotnet ef` для Prototype v1.3
- Режим: `Швидкий`
- Версія: `1.3`
- Статус: `Активний`
- Результат: Видалено ручну pending-міграцію і згенеровано нову через `dotnet ef migrations add`; фінальна версія перед `database update` — `20260303220918_AddRentalApplicationProfilesV13`.

### 2026-03-03 — Реалізація Prototype v1.3 (V3.1-A)
- Режим: `Архітектурний`
- Версія: `1.3`
- Статус: `Активний`
- Результат: Реалізовано typed prototype `RentalApplicationProfile` та нові сценарії profile-create/profile-apply-from-profile через `Command` + `ApplicationUseCaseMediator`, додано EF міграцію `20260303220918_AddRentalApplicationProfilesV13`, тести `6/6 passed`.

### 2026-03-03 — Вибір ToT для Prototype v1.3 (ADR-002)
- Режим: `Архітектурний`
- Версія: `1.3`
- Статус: `В розробці`
- Результат: Зафіксовано ToT для інтеграції `Prototype`; обрано `V3.1-A` (typed prototype для профілів заявок), створено `ADR-002`, оновлено `project-context.md` і `patterns.md`.

### 2026-03-03 — Синхронізація коду з Template Method v1.2
- Режим: `Архітектурний`
- Версія: `1.2`
- Статус: `Активний`
- Результат: `BaseUseCaseMediator` переведено на класичний Template Method (`ExecuteListingCreateTemplateAsync`, `ExecuteApplyTemplateAsync`), `ListingUseCaseMediator` та `ApplicationUseCaseMediator` переведено на `override` required-кроків/hooks, `dotnet test rent_for_students.slnx` -> `4/4 passed`.

### 2026-02-26 — Реалізація Template Method v1.2 (класичний TM у BaseUseCaseMediator)
- Режим: `Архітектурний`
- Версія: `1.2`
- Статус: `Активний`
- Результат: Реалізовано класичний Template Method у BaseUseCaseMediator; mediator-и переведено на override required-кроків/hooks, nested template-класи прибрано, тести 4/4 passed.

### 2026-02-25 — Рефакторинг Template Method (pragmatic template-flow)
- Режим: `Архітектурний`
- Версія: `1.1`
- Статус: `Застарілий`
- Результат: Проміжний рефакторинг Template Method до pragmatic template-flow; додано `OperationValidationResult` і виправлено нотифікації/success-message. Надалі замінено класичною реалізацією `v1.2`.

### 2026-02-24 — Інтеграція Template Method у UseCaseMediator (V2)
- Режим: `Архітектурний`
- Версія ToT: `1.0` (Варіант V2)
- Статус: `Активний`
- Результат: Обрано варіант V2 (Template Method у UseCaseMediator), оновлено patterns.md, project-context.md, створено ADR-001, реалізовано BaseUseCaseMediator, рефакторено ListingUseCaseMediator та ApplicationUseCaseMediator. Всі тести прошли (4/4). Обратна сумісність 100%. Дублювання коду скорочено на ~45%.

### 2026-02-23 — Налаштування AI-середовища
- Режим: `Архітектурний`
- Версія: `1.0`
- Статус: `Активний`
- Результат: Підготовлено план оновлення AI-інструкцій, ToT-схеми, логування та контексту.

---

## Шаблон нового запису (копіювати нижче)
### YYYY-MM-DD — [Тема]
- Режим: `Швидкий` / `Архітектурний`
- Версія: `1.0` / `1.1` / `1.0.1` / ...
- Статус: `Не реалізований` / `В розробці` / `Активний` / `Застарілий`
- Результат: [1-2 речення]
