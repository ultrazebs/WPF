﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.Models
{
    public class Student
    {
        public int Id { get; set; } 
        public string Nome { get; set; }    
        public string Cognome { get; set; }    
        public DateTime DataNascita { get; set; }    
        public int IdCorso { get; set; }

        public Corso Corso { get; set; }    

        public string cognomeNome;

        public Student()
        {
            
        }

        public Student(DateTime DataNascita)
        {
            this.DataNascita = DataNascita;
        }
    }
}
