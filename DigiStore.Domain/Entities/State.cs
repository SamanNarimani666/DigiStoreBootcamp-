﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DigiStore.Domain.Entities
{
    public partial class State
    {
        public State()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid Rowguid { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
