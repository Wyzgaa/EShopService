﻿namespace EShopService.Models
{
    public class BaseModel
    {
        public bool deleted { get; set; }
        public Guid created_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid updated_by { get; set; }
    }
}
