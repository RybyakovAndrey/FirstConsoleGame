using System;

namespace ConsoleGameEngine.Domain.Events
{
    public abstract class Event
    {

        public abstract EventType GetEventType();
        public virtual byte GetCategoryFlag()
        {
            return (byte)EventCategory.None;
        }


        public bool IsInGategory(EventCategory category)
        {
            return (GetCategoryFlag() & (byte)category) == (byte)category;
        }

    }
}
