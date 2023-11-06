using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IliasOtsmanConnBBDD
{
    public class Job
    {
        private int jobId;
        private string jobTitle;
        private decimal? minSalary;
        private decimal? maxSalary;

        public int JobId { get { return jobId; } set { jobId = value; } }
        public string JobTitle { get { return jobTitle; } set { jobTitle = value; } }
        public decimal? MinSalary { get { return minSalary; } set { minSalary = value; } }
        public decimal? MaxSalary { get { return maxSalary; } set { maxSalary = value; } }

        public Job(string jTitle, decimal? minSal, decimal? maxSal)
        { 
            jobTitle = jTitle;
            minSalary = minSal;
            maxSalary = maxSal;
        }

        public override string ToString()
        {
            if (MinSalary == null && MaxSalary == null)
                return $"{JobTitle} - ningún salrio está asignado";
            if (MinSalary == null)
                return $"{JobTitle} - con salario máximo: {maxSalary}e";
            if (MaxSalary == null)
                return $"{JobTitle} - con salario mínimo: {minSalary}e";

            return $"{JobTitle} - con salario mínimo: {minSalary}e y salario máximo: {maxSalary}e";
        }
    }
}
