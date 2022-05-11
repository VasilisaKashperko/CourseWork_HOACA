using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HOAChairmanAssistant.Model;

namespace HOAChairmanAssistant.EF
{
    public class HOAChairmanAssistantContext : DbContext
    {
        // Имя будущей базы данных можно указать через вызов конструктора базового класса
        public HOAChairmanAssistantContext() : base("HOAChairmanAssistant")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Porch> Porches { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
