namespace rekrutacja_contact
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using rekrutacja_contact.Models;

    public partial class ContactDBModel : DbContext, IDBContext
    {
        public ContactDBModel()
            : base( "ContactModel")
        {
        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public void MarkAsModified(Contact item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
