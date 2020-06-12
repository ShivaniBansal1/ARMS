﻿using Arms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arms.Domain.CustomEntities
{

    public class CustomEmployee
    {

        public int Id { get; set; }
        public int? EmployeeDetailId { get; set; }
        public string FirstName { get; set; }
        public Guid UserGuid { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PasswordFormatId { get; set; }
        public string PasswordSalt { get; set; }
        public bool Active { get; set; }
        public string SystemName { get; set; }
        public bool Deleted { get; set; }
        public int? DivisionId { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
    }
}