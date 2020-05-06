namespace WebApplication1
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Users : DbContext
    {
        // Your context has been configured to use a 'Users' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication1.Users' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Users' 
        // connection string in the application configuration file.
        public Users()
            : base("name=Users")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
    }
}