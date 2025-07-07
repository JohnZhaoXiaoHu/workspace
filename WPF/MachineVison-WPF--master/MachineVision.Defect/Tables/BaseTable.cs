﻿using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Tables
{
    public class BaseTable
    {
        /// <summary>
        /// Id
        /// </summary>
        [Column(IsPrimary =true, IsIdentity = true)]
        public int Id { get; set;}

        public DateTime CreateTime { get; set; } = DateTime.Now;


        public DateTime UpdateTime { get; set; } = DateTime.Now;


    }
}
