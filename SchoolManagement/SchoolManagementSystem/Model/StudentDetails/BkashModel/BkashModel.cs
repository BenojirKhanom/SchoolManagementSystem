using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class BkashModel
    {
        [Key]
        public int Id { get; set; }
        public string paymentID { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
        public string trxID { get; set; }
        public string transactionStatus { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string merchantInvoiceNumber { get; set; }
    }
}
