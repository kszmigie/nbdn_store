﻿using System;

namespace nothinbutdotnetstore.model
{
    public class Department : Identity 
    {
        public bool has_products;

        public Department(int id) : this(id, "")
        {
        }

        public Department(int id, string name) : this(id, name, -1)
        {
        }

        public Department(int id, string name, int parent_id)
        {
            this.id = id;
            parent_department_id = parent_id;
            this.name = name;
        }

        public int id { get; set; }
        public int parent_department_id { get; set; }
        public string name { get; set; }

        public bool has_parent_department { get { return parent_department_id != -1; } }

        public override string ToString()
        {
            return name ?? "(null)";
        }
    }
}