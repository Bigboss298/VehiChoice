using System;

namespace VehiChoice.Models.Entities
{
    public class BaseEntity
    {
        public string Id{get; set;} = Guid.NewGuid().ToString()[..9];
        public bool IsDeleted{get; set;} = false;
        public string DateCreated{get; set;} = DateTime.Now.Date.ToShortDateString();
    }
}