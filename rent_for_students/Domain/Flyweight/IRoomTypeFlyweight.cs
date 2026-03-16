using rent_for_students.Domain.Entities;

namespace rent_for_students.Domain.Flyweight
{
    public interface IRoomTypeFlyweight
    {
        RoomType Type { get; }
        string DisplayName { get; }
        string Description { get; }
        int TypicalCapacity { get; }
        string CssClass { get; }
    }
}
