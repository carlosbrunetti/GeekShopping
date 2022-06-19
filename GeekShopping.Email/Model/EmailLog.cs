using GeekShopping.Email.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Email.Model
{
    [Table("EmailLog")]
    public class EmailLog : BaseEntity
    {
       
        [Column("Email")]
        public string Email { get; set; }

        [Column("Log")]
        public string Log { get; set; }

        [Column("SentDate")]
        public DateTime SentDate { get; set; }
    }
}
