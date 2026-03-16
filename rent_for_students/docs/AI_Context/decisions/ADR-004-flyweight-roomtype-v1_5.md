# ADR-004: Flyweight v1.5 — RoomType як багатий Flyweight

## Статус
`Прийнято` (2026-03-11)

## Дата
`2026-03-11`

## Контекст
У проєкті `RoomType` — простий enum із 4 значеннями (`Studio`, `OneBedroom`, `TwoBedroom`, `ThreeBedroom`).
На практиці кожен тип кімнати несе додаткову семантику, яка повторюється при кожному використанні:
- відображувана назва (UI);
- опис типу для студентів;
- типова місткість;
- CSS-клас для стилізації.

Без Flyweight ці дані або дублюються в кожному View (switch/case у Razor), або розкидані по різних шарах.

Патерн **Flyweight** дозволяє:
- винести спільний (intrinsic) стан типу кімнати в один об'єкт, що розділяється між усіма оголошеннями;
- зберігати унікальний (extrinsic) стан (`Id`, `Title`, `Price`, `Area`, ...) окремо в кожному оголошенні;
- централізувати метадані `RoomType` в одному місці замість дублювання.

## Рішення
Обраний **Варіант 1A: RoomType як багатий Flyweight**.

### Структура
- `Domain/Flyweight/IRoomTypeFlyweight.cs` — інтерфейс flyweight із intrinsic-властивостями.
- `Domain/Flyweight/RoomTypeFlyweight.cs` — `ConcreteFlyweight`, immutable об'єкт з метаданими типу кімнати.
- `Domain/Flyweight/RoomTypeFlyweightFactory.cs` — фабрика, яка кешує та повертає flyweight-об'єкти за `RoomType`-ключем.

### Розподіл стану
| Стан | Тип | Де зберігається |
|---|---|---|
| `RoomType` (enum) | Intrinsic (ключ flyweight) | `RoomTypeFlyweight` |
| `DisplayName` ("Studio", "1-Bedroom") | Intrinsic | `RoomTypeFlyweight` |
| `Description` (опис для студентів) | Intrinsic | `RoomTypeFlyweight` |
| `TypicalCapacity` (1, 2, 3, 4) | Intrinsic | `RoomTypeFlyweight` |
| `CssClass` ("room-studio", ...) | Intrinsic | `RoomTypeFlyweight` |
| `Id`, `Title`, `City`, `Price`, `Area`, ... | Extrinsic | `HousingListing` (Context) |
| `HousingListing.RoomType` | Flyweight reference | `HousingListing` → Factory → Flyweight |

> `HousingListing.RoomType` — це **посилання на flyweight** (аналог `Context.flyweight` у класичній схемі),
> через яке Context отримує доступ до спільного intrinsic стану. Сам enum є частиною intrinsic стану flyweight-а.

### Інтеграція з архітектурою (Варіант A — Factory → Controllers напряму)
- `HousingListing` зберігає `RoomType` enum як і раніше (EF Core mapping не змінюється).
- `RoomTypeFlyweightFactory` реєструється в DI як **Singleton**.
- Controller = **Client** у термінах патерну — інжектить Factory через конструктор.
- Views також інжектять Factory через `@inject` для доступу до flyweight-метаданих при відображенні.
- `ListingSearchCriteria` та фільтрація не змінюються.

> **Варіант B (Factory → через Mediator/Service шар)** відхилений на поточному етапі:
> консистентний з потоком `Controller → Command → Mediator`, але надлишковий для простого кешованого lookup метаданих.
> Якщо в майбутньому доменна логіка потребуватиме flyweight-метаданих — можна мігрувати до варіанту B без ламання API.

## Наслідки
### Плюси
- Централізація метаданих `RoomType` в одному місці.
- Усунення дублювання switch/case у Views та Controllers.
- Канонічна демонстрація патерну Flyweight з чітким поділом intrinsic/extrinsic.
- Мінімальний вплив на існуючу архітектуру (EF Core mapping не змінюється).
- Immutable flyweight-об'єкти — thread-safe, підходять для Singleton.

### Компроміси
- Додатковий шар абстракції для 4 об'єктів (overhead мінімальний, але існує).
- Factory потрібно оновлювати при додаванні нових `RoomType` значень.

## Альтернативи, які розглядалися

### Відхилені (відкладені на майбутнє)
1. **Варіант 1B: City + District Location Flyweight** — кешування повторюваних комбінацій міста/району. Хороший для реальної економії пам'яті, але складніша інтеграція з EF Core.
2. **Варіант 1C: Composite Flyweight (RoomType + Location)** — максимальна економія, але найвища складність інтеграції.
3. **Варіант 4: ApplicationStatus Flyweight** — аналогічний підхід для статусів заявок (Pending/Approved/Rejected із DisplayName, CssClass, UserMessage, переходи). Простий, але менш показовий за 1A.
4. **Варіант 5: SearchPresets Flyweight** — кешування типових пошукових фільтрів студентів ("Бюджетна студія в Києві"). Цікавий UX-варіант, нестандартне застосування патерну.

## Пов'язані матеріали
- `docs/AI_Context/patterns.md`
- `docs/AI_Context/project-context.md`
- `docs/AI_Context/decisions/ADR-003-prototype-baseline-interface-v1_4.md`
