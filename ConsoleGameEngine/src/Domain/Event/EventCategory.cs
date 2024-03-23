
namespace ConsoleGameEngine.Domain.Events
{
    // бинарные значиния фыступает в роле флага
    public enum EventCategory : byte
    {
        None = 0,
        InputEvent = 1,
        ApplicationEvent = 2,
        MouseEvent = 4
    }
}
