﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Module32MVCFinal2.Models.Db.Entities
{
    /// <summary>
    /// модель запроса
    /// </summary>
    //[Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Url { get; set; }
    }
}
